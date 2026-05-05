import { useEffect, useState } from 'react';
import { getMenuItems, getCategories } from '../api/menuItems';
import MenuItemCard from '../components/MenuItemCard';
import type { MenuItem } from '../types';

export default function MenuPage() {
  const [items, setItems] = useState<MenuItem[]>([]);
  const [categories, setCategories] = useState<string[]>([]);
  const [selected, setSelected] = useState<string | undefined>();
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState('');

  useEffect(() => {
    getCategories().then(setCategories).catch(() => {});
  }, []);

  useEffect(() => {
    setLoading(true);
    getMenuItems(selected)
      .then(setItems)
      .catch(() => setError('Impossible de charger le menu. Vérifiez que le backend est démarré.'))
      .finally(() => setLoading(false));
  }, [selected]);

  return (
    <main className="container">
      <h1 className="page-title">Notre Menu</h1>

      <div className="category-bar">
        <button
          className={`category-btn ${!selected ? 'active' : ''}`}
          onClick={() => setSelected(undefined)}
        >
          Tout
        </button>
        {categories.map(cat => (
          <button
            key={cat}
            className={`category-btn ${selected === cat ? 'active' : ''}`}
            onClick={() => setSelected(cat)}
          >
            {cat}
          </button>
        ))}
      </div>

      {error && <p className="error">{error}</p>}
      {loading ? (
        <p className="loading">Chargement...</p>
      ) : (
        <div className="menu-grid">
          {items.map(item => (
            <MenuItemCard key={item.id} item={item} />
          ))}
        </div>
      )}
    </main>
  );
}
