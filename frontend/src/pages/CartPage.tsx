import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useCart } from '../context/CartContext';
import { createOrder } from '../api/orders';

export default function CartPage() {
  const { items, removeItem, updateQuantity, clearCart, total } = useCart();
  const navigate = useNavigate();
  const [form, setForm] = useState({ name: '', email: '', phone: '' });
  const [submitting, setSubmitting] = useState(false);
  const [error, setError] = useState('');

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (items.length === 0) return;
    setSubmitting(true);
    setError('');
    try {
      const order = await createOrder({
        customerName: form.name,
        customerEmail: form.email,
        customerPhone: form.phone,
        items: items.map(i => ({ menuItemId: i.menuItem.id, quantity: i.quantity })),
      });
      clearCart();
      navigate(`/confirmation/${order.id}`);
    } catch {
      setError('Erreur lors de la commande. Réessayez.');
    } finally {
      setSubmitting(false);
    }
  };

  if (items.length === 0) {
    return (
      <main className="container center">
        <h1>Votre panier est vide</h1>
        <button className="btn-primary" onClick={() => navigate('/')}>Voir le menu</button>
      </main>
    );
  }

  return (
    <main className="container">
      <h1 className="page-title">Votre Panier</h1>
      <div className="cart-layout">
        <div className="cart-items">
          {items.map(({ menuItem, quantity }) => (
            <div key={menuItem.id} className="cart-item">
              <div className="cart-item-info">
                <span className="cart-item-name">{menuItem.name}</span>
                <span className="cart-item-price">{(menuItem.price * quantity).toFixed(2)} $</span>
              </div>
              <div className="cart-item-controls">
                <button onClick={() => updateQuantity(menuItem.id, quantity - 1)}>−</button>
                <span>{quantity}</span>
                <button onClick={() => updateQuantity(menuItem.id, quantity + 1)}>+</button>
                <button className="btn-remove" onClick={() => removeItem(menuItem.id)}>🗑️</button>
              </div>
            </div>
          ))}
          <div className="cart-total">Total: {total.toFixed(2)} $</div>
        </div>

        <form className="checkout-form" onSubmit={handleSubmit}>
          <h2>Informations</h2>
          <input
            type="text" placeholder="Nom complet" required
            value={form.name} onChange={e => setForm(f => ({ ...f, name: e.target.value }))}
          />
          <input
            type="email" placeholder="Courriel" required
            value={form.email} onChange={e => setForm(f => ({ ...f, email: e.target.value }))}
          />
          <input
            type="tel" placeholder="Téléphone" required
            value={form.phone} onChange={e => setForm(f => ({ ...f, phone: e.target.value }))}
          />
          {error && <p className="error">{error}</p>}
          <button type="submit" className="btn-primary" disabled={submitting}>
            {submitting ? 'Traitement...' : 'Commander'}
          </button>
        </form>
      </div>
    </main>
  );
}
