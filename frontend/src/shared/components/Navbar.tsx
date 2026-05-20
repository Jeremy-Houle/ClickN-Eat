import { Link, useNavigate, useLocation } from 'react-router-dom';
import { useCart } from '@/features/cart/context/CartContext';
import { useAuth } from '@/shared/context/AuthContext';
import { useRestaurant } from '@/shared/context/RestaurantContext';
import { useTheme } from '@/shared/context/ThemeContext';
import { useLanguage } from '@/shared/context/LanguageContext';
import { getTier } from '@/shared/utils/tiers';

export default function Navbar() {
  const { count } = useCart();
  const { user, logout, isAuthenticated } = useAuth();
  const { restaurant, setRestaurant } = useRestaurant();
  const { theme, toggleTheme } = useTheme();
  const { t } = useLanguage();
  const navigate = useNavigate();
  const location = useLocation();

  const handleLogout = () => {
    logout();
    setRestaurant(null);
    navigate('/login');
  };

  const onMenu = location.pathname === '/menu' || location.pathname === '/cart';
  const tier = user ? getTier(user.totalPointsEarned ?? 0) : null;

  return (
    <nav className="navbar">
      <div className="navbar-left">
        <Link to="/" className="navbar-brand">🍔 ClickN'Eat</Link>
        {restaurant && onMenu && (
          <button className="navbar-restaurant-switch" onClick={() => { setRestaurant(null); navigate('/'); }}>
            ◀ {restaurant.name}
          </button>
        )}
      </div>
      <div className="navbar-right">
        <button className="theme-toggle" onClick={toggleTheme} title={t('nav.changeTheme')}>
          {theme === 'dark' ? '☀️' : '🌙'}
        </button>
        {isAuthenticated ? (
          <>
            {user!.role === 'Admin' && (
              <Link to="/admin" className="navbar-admin">⚙️ Admin</Link>
            )}
            {user!.role !== 'Admin' && tier && (
              <span className="navbar-points" title={t('nav.rank', { label: tier.label })} style={{ borderColor: `${tier.color}44`, color: tier.color, background: `${tier.color}14` }}>
                {tier.icon} {(user!.points ?? 0).toLocaleString()} pts
              </span>
            )}
            <Link to="/profile" className="navbar-user">👤 {user!.name}</Link>
            <Link to="/cart" className="navbar-cart">
              🛒 {count > 0 && <span key={count} className="cart-badge">{count}</span>}
            </Link>
            <button className="btn-logout" onClick={handleLogout}>{t('nav.logout')}</button>
          </>
        ) : (
          <Link to="/login" className="btn-login">{t('nav.login')}</Link>
        )}
      </div>
    </nav>
  );
}
