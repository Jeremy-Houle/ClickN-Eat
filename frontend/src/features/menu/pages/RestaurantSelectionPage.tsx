import { useNavigate } from 'react-router-dom';
import { useQuery } from '@tanstack/react-query';
import { getRestaurants } from '@/features/menu/api/restaurants';
import type { Restaurant } from '@/features/menu/api/restaurants';
import { useRestaurant } from '@/shared/context/RestaurantContext';
import { useCart } from '@/features/cart/context/CartContext';
import { useLanguage } from '@/shared/context/LanguageContext';

export default function RestaurantSelectionPage() {
  const { restaurant, setRestaurant } = useRestaurant();
  const { switchRestaurant } = useCart();
  const { t } = useLanguage();
  const navigate = useNavigate();

  const { data: restaurants = [], isLoading } = useQuery({
    queryKey: ['restaurants'],
    queryFn: getRestaurants,
  });

  const handleSelect = (r: Restaurant) => {
    switchRestaurant(restaurant?.id ?? null, r.id);
    setRestaurant(r);
    navigate('/menu');
  };

  return (
    <main className="restaurant-selection-page">
      <div className="restaurant-selection-hero">
        <h1 className="restaurant-selection-title">🍔 {t('restaurant.title')}</h1>
        <p className="restaurant-selection-sub">{t('restaurant.subtitle')}</p>
      </div>

      {isLoading ? (
        <div className="restaurant-grid">
          {[1, 2].map(i => <div key={i} className="restaurant-card-skeleton" />)}
        </div>
      ) : (
        <div className="restaurant-grid">
          {restaurants.map((r, i) => (
            <button
              key={r.id}
              className="restaurant-card"
              onClick={() => handleSelect(r)}
              style={{ animationDelay: `${i * 0.1}s` }}
            >
              <div
                className="restaurant-card-cover"
                style={{ backgroundImage: `url(${r.coverImageUrl})` }}
              >
                <div
                  className="restaurant-card-overlay"
                  style={{ background: `linear-gradient(to top, ${r.accentColor}cc 0%, transparent 60%)` }}
                />
              </div>
              <div className="restaurant-card-body">
                <div className="restaurant-card-accent" style={{ background: r.accentColor }} />
                <div className="restaurant-card-info">
                  <div className="restaurant-card-header">
                    {r.logoUrl ? (
                      <img src={r.logoUrl} alt={r.name} className="restaurant-card-logo" />
                    ) : (
                      <div className="restaurant-card-logo-placeholder" style={{ background: r.accentColor }}>
                        {r.name.charAt(0)}
                      </div>
                    )}
                    <h2 className="restaurant-card-name">{r.name}</h2>
                  </div>
                  <p className="restaurant-card-desc">{r.description}</p>
                </div>
                <span className="restaurant-card-cta" style={{ color: r.accentColor }}>
                  {t('common.seeMenu')}
                </span>
              </div>
            </button>
          ))}
        </div>
      )}
    </main>
  );
}
