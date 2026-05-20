import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useCart } from '@/features/cart/context/CartContext';
import { useAuth } from '@/shared/context/AuthContext';
import { useLanguage } from '@/shared/context/LanguageContext';
import { createOrder } from '@/features/orders/api/orders';
import { estimateTime } from '@/shared/utils/estimate';
import { translateApiError } from '@/shared/utils/apiError';

export default function CartPage() {
  const { items, removeItem, updateQuantity, clearCart, total, count } = useCart();
  const { user, updatePoints } = useAuth();
  const { t } = useLanguage();
  const navigate = useNavigate();

  const [form, setForm] = useState({ name: user?.name ?? '', email: user?.email ?? '', phone: '' });
  const [orderType, setOrderType] = useState<'Pickup' | 'Delivery'>('Pickup');
  const [deliveryAddress, setDeliveryAddress] = useState('');
  const [deliveryNote, setDeliveryNote] = useState('');
  const [usePoints, setUsePoints] = useState(false);
  const [submitting, setSubmitting] = useState(false);
  const [error, setError] = useState('');

  const pointsRequired = Math.round(total * 100);
  const hasEnoughPoints = (user?.points ?? 0) >= pointsRequired;
  const eta = estimateTime(count, orderType);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (items.length === 0) return;
    if (orderType === 'Delivery' && !deliveryAddress.trim()) {
      setError(t('cart.addressRequired'));
      return;
    }
    setSubmitting(true);
    setError('');
    try {
      const result = await createOrder({
        customerName: form.name,
        customerEmail: form.email,
        customerPhone: form.phone,
        items: items.map(i => ({ menuItemId: i.menuItem.id, quantity: i.quantity })),
        usePoints,
        orderType,
        deliveryAddress: orderType === 'Delivery' ? deliveryAddress : undefined,
        deliveryNote: orderType === 'Delivery' ? deliveryNote : undefined,
      });
      updatePoints(result.newPoints, result.newTotalPointsEarned);
      clearCart();
      navigate(`/confirmation/${result.order.id}`);
    } catch (err: any) {
      const data = err?.response?.data;
      if (typeof data === 'string') {
        setError(translateApiError(data, t, t('cart.orderError')));
      } else if (data?.errors) {
        const fieldErrors = Object.entries(data.errors as Record<string, string[]>)
          .map(([field, msgs]) => `${field}: ${msgs.join(', ')}`)
          .join(' | ');
        setError(fieldErrors || data?.title || t('cart.orderError'));
      } else {
        setError(data?.title || data?.detail || t('cart.orderError'));
      }
    } finally {
      setSubmitting(false);
    }
  };

  if (items.length === 0) {
    return (
      <main className="container center">
        <h1>{t('cart.empty')}</h1>
        <button className="btn-primary" onClick={() => navigate('/')}>{t('cart.seeMenu')}</button>
      </main>
    );
  }

  return (
    <main className="container">
      <h1 className="page-title">{t('cart.title')}</h1>
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
                <input
                  type="number"
                  className="qty-input"
                  min="1"
                  max="9999"
                  key={quantity}
                  defaultValue={quantity}
                  onBlur={e => {
                    const v = parseInt(e.target.value, 10);
                    if (isNaN(v) || v < 1) updateQuantity(menuItem.id, 1);
                    else if (v > 9999) updateQuantity(menuItem.id, 9999);
                    else updateQuantity(menuItem.id, v);
                  }}
                  onKeyDown={e => { if (e.key === 'Enter') (e.target as HTMLInputElement).blur(); }}
                />
                <button onClick={() => updateQuantity(menuItem.id, quantity + 1)}>+</button>
                <button className="btn-remove" onClick={() => removeItem(menuItem.id)}>🗑️</button>
              </div>
            </div>
          ))}
          <div className="cart-total">{t('cart.total')}: {total.toFixed(2)} $</div>

          <div className="points-payment-box">
            <div className="points-payment-header">
              <span>{t('cart.payWithPoints')}</span>
              <button
                type="button"
                className={`points-toggle${usePoints ? ' active' : ''}`}
                onClick={() => setUsePoints(v => !v)}
                disabled={!hasEnoughPoints}
              >
                {usePoints ? 'ON' : 'OFF'}
              </button>
            </div>
            <p className="points-payment-info">
              {t('cart.balance')}: <strong>{(user?.points ?? 0).toLocaleString()} pts</strong>
              &nbsp;·&nbsp; {t('cart.cost')}: <strong>{pointsRequired.toLocaleString()} pts</strong>
            </p>
            {usePoints ? (
              <p className="points-payment-note points-spending">
                {t('cart.willSpend', { pts: pointsRequired.toLocaleString() })}
              </p>
            ) : (
              <p className="points-payment-note points-earning">
                {t('cart.willEarn', { pts: pointsRequired.toLocaleString() })}
              </p>
            )}
            {!hasEnoughPoints && (
              <p className="points-payment-note points-insufficient">
                {t('cart.notEnough', { pts: (pointsRequired - (user?.points ?? 0)).toLocaleString() })}
              </p>
            )}
          </div>
        </div>

        <form className="checkout-form" onSubmit={handleSubmit}>
          <h2>{t('cart.info')}</h2>
          <input
            type="text" placeholder={t('cart.fullName')} required
            value={form.name} onChange={e => setForm(f => ({ ...f, name: e.target.value }))}
          />
          <input
            type="email" placeholder={t('cart.email')} required
            value={form.email} onChange={e => setForm(f => ({ ...f, email: e.target.value }))}
          />
          <input
            type="tel" placeholder={t('cart.phone')} required
            value={form.phone} onChange={e => setForm(f => ({ ...f, phone: e.target.value }))}
          />

          <div className="order-type-toggle">
            <button
              type="button"
              className={`order-type-btn${orderType === 'Pickup' ? ' active' : ''}`}
              onClick={() => setOrderType('Pickup')}
            >
              {t('cart.pickup')}
            </button>
            <button
              type="button"
              className={`order-type-btn${orderType === 'Delivery' ? ' active' : ''}`}
              onClick={() => setOrderType('Delivery')}
            >
              {t('cart.delivery')}
            </button>
          </div>

          {orderType === 'Delivery' && (
            <div className="delivery-fields">
              <input
                type="text"
                placeholder={t('cart.deliveryAddress')}
                required
                value={deliveryAddress}
                onChange={e => setDeliveryAddress(e.target.value)}
              />
              <textarea
                placeholder={t('cart.deliveryNote')}
                rows={2}
                value={deliveryNote}
                onChange={e => setDeliveryNote(e.target.value)}
              />
            </div>
          )}

          <div className="eta-box">
            <span className="eta-label">{orderType === 'Delivery' ? t('cart.estimatedDelivery') : t('cart.readyIn')}</span>
            <span className="eta-time">{eta}</span>
          </div>

          {error && <p className="error">{error}</p>}
          <button type="submit" className="btn-primary" disabled={submitting}>
            {submitting ? t('cart.processing') : orderType === 'Delivery' ? t('cart.orderDelivery') : t('cart.orderPickup')}
          </button>
        </form>

      </div>
    </main>
  );
}
