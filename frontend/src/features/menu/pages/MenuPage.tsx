import { useState, useMemo } from 'react';
import { useNavigate } from 'react-router-dom';
import { useQuery } from '@tanstack/react-query';
import { getMenuItems, getCategories } from '@/features/menu/api/menuItems';
import MenuItemCard from '@/features/menu/components/MenuItemCard';
import { useRestaurant } from '@/shared/context/RestaurantContext';
import { useLanguage } from '@/shared/context/LanguageContext';
import type { MenuItem } from '@/shared/types';

export default function MenuPage() {
  const { restaurant } = useRestaurant();
  const { t, tCat } = useLanguage();
  const navigate = useNavigate();
  const [selected, setSelected] = useState<string | undefined>();
  const [search, setSearch] = useState('');

  const { data: categories = [] } = useQuery({
    queryKey: ['categories', restaurant?.id],
    queryFn: () => getCategories(restaurant!.id),
    enabled: !!restaurant,
  });

  const { data: items = [], isLoading, isError } = useQuery({
    queryKey: ['menuItems', restaurant?.id, selected],
    queryFn: () => getMenuItems(restaurant!.id, selected),
    enabled: !!restaurant,
  });

  if (!restaurant) { navigate('/'); return null; }

  const filtered = useMemo(() => {
    if (!search.trim()) return items;
    const q = search.toLowerCase();
    return items.filter(i => i.name.toLowerCase().includes(q) || i.description.toLowerCase().includes(q));
  }, [items, search]);

  const grouped: Record<string, MenuItem[]> = selected
    ? { [selected]: filtered }
    : filtered.reduce<Record<string, MenuItem[]>>((acc, item) => {
        (acc[item.category] ??= []).push(item);
        return acc;
      }, {});

  return (
    <main className="container">
      <div className="menu-hero">
        <h1>{restaurant.name}</h1>
        <p>{restaurant.description ?? t('menu.defaultDesc')}</p>
      </div>

      <div className="menu-search-bar">
        <input
          type="search"
          placeholder={t('menu.search')}
          value={search}
          onChange={e => setSearch(e.target.value)}
          className="menu-search-input"
        />
        {search && <button className="menu-search-clear" onClick={() => setSearch('')}>✕</button>}
      </div>

      <div className="category-bar">
        <button className={`category-btn ${!selected ? 'active' : ''}`} onClick={() => setSelected(undefined)}>
          {t('menu.all')}
        </button>
        {categories.map(cat => (
          <button
            key={cat}
            className={`category-btn ${selected === cat ? 'active' : ''}`}
            onClick={() => setSelected(cat)}
          >
            {tCat(cat)}
          </button>
        ))}
      </div>

      {isError && <p className="error">{t('menu.loadError')}</p>}

      {isLoading ? (
        <div className="loading">
          {[...Array(6)].map((_, i) => <div key={i} className="loading-card" style={{ animationDelay: `${i * 0.1}s` }} />)}
        </div>
      ) : (
        <div className="menu-sections">
          {Object.entries(grouped).map(([cat, catItems]) => (
            <section key={cat} className="menu-section">
              <h2 className="menu-section-title">{tCat(cat)}</h2>
              <div className="menu-grid">
                {catItems.map((item, i) => (
                  <div key={item.id} style={{ animationDelay: `${i * 0.05}s` }}>
                    <MenuItemCard item={item} />
                  </div>
                ))}
              </div>
            </section>
          ))}
        </div>
      )}
    </main>
  );
}
