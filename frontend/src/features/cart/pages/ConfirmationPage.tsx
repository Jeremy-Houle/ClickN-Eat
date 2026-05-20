import { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { getOrder } from '@/features/orders/api/orders';
import { estimateTime } from '@/shared/utils/estimate';
import { useLanguage } from '@/shared/context/LanguageContext';
import type { Order } from '@/shared/types';

export default function ConfirmationPage() {
  const { id } = useParams<{ id: string }>();
  const [order, setOrder] = useState<Order | null>(null);
  const { t } = useLanguage();
  const navigate = useNavigate();

  useEffect(() => {
    if (id) getOrder(Number(id)).then(setOrder).catch(() => {});
  }, [id]);

  if (!order) return <main className="container center"><p>{t('confirmation.loading')}</p></main>;

  const isDelivery = order.orderType === 'Delivery';
  const totalItems = order.items.reduce((s, i) => s + i.quantity, 0);
  const eta = estimateTime(totalItems, order.orderType);

  return (
    <main className="container center">
      <div className="confirmation-card">
        <div className="confirmation-icon">{isDelivery ? '🛵' : '✅'}</div>
        <h1>{t('confirmation.title')}</h1>
        <p>{t('confirmation.thanks', { name: order.customerName, id: order.id })}</p>

        <div className="confirmation-eta">
          <span className="eta-label">{isDelivery ? t('confirmation.estimatedDelivery') : t('confirmation.readyIn')}</span>
          <span className="eta-time">{eta}</span>
        </div>

        {isDelivery && order.deliveryAddress && (
          <div className="confirmation-delivery">
            <span className="confirmation-delivery-label">{t('confirmation.deliveryAddress')}</span>
            <span className="confirmation-delivery-addr">{order.deliveryAddress}</span>
            {order.deliveryNote && (
              <span className="confirmation-delivery-note">💬 {order.deliveryNote}</span>
            )}
          </div>
        )}

        <div className="order-summary">
          {order.items.map(item => (
            <div key={item.id} className="order-summary-row">
              <span>{item.menuItemName} × {item.quantity}</span>
              <span>{(item.unitPrice * item.quantity).toFixed(2)} $</span>
            </div>
          ))}
          <div className="order-summary-row total">
            <strong>{t('confirmation.total')}</strong>
            <strong>{order.total.toFixed(2)} $</strong>
          </div>
        </div>

        <p className="status-badge">{t('confirmation.status')} : {t(`status.${order.status}`) || order.status}</p>
        <button className="btn-primary" onClick={() => navigate('/')}>{t('confirmation.backToMenu')}</button>
      </div>
    </main>
  );
}
