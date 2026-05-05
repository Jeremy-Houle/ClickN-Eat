import { Link } from 'react-router-dom';
import { useCart } from '../context/CartContext';

export default function Navbar() {
  const { count } = useCart();
  return (
    <nav className="navbar">
      <Link to="/" className="navbar-brand">🍔 ClickN'Eat</Link>
      <Link to="/cart" className="navbar-cart">
        🛒 Panier {count > 0 && <span className="cart-badge">{count}</span>}
      </Link>
    </nav>
  );
}
