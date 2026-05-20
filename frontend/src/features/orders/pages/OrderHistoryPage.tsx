import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useQuery } from '@tanstack/react-query';
import { getMyOrders } from '@/features/orders/api/orders';
import { useLanguage } from '@/shared/context/LanguageContext';

const STATUS_COLORS: Record<string, string> = {
  Pending:   '#f59e0b',
  Confirmed: '#6366f1',
  Preparing: '#3b82f6',
  Ready:     '#4ade80',
  Delivered: '#22c55e',
  Cancelled: '#f87171',
};

const PAGE_SIZE = 20;

export default function OrderHistoryPage() {
  const [page, setPage] = useState(1);
  const { t } = useLanguage();
  const navigate = useNavigate();

  const { data, isLoading } = useQuery({
    queryKey: ['myOrders', page],
    queryFn: () => getMyOrders(page, PAGE_SIZE),
    placeholderData: prev => prev,
  });

  const orders = data?.items ?? [];

  if (isLoading && !data) return (
    <main className="container"><p className="loading-text">{t('orders.loading')}</p></main>
  );

  return (
    <main className="container">
      <div className="page-header">
        <h1 className="page-title">{t('orders.title')}</h1>
        <button className="btn-secondary" onClick={() => navigate('/')}>{t('orders.newRestaurant')}</button>
      </div>

      {orders.length === 0 && !isLoading ? (
        <div className="empty-state">
          <p>{t('orders.noOrders')}</p>
          <button className="btn-primary" onClick={() => navigate('/')}>{t('orders.orderNow')}</button>
        </div>
      ) : (
        <>
          <div className="order-history-list">
            {orders.map(order => {
              const color = STATUS_COLORS[order.status] ?? '#94a3b8';
              const statusLabel = t(`status.${order.status}`) || order.status;
              return (
                <div key={order.id} className="order-history-card">
                  <div className="order-history-top">
                    <div>
                      <span className="order-history-id">{t('common.orderNumber', { id: order.id })}</span>
                      <span className="order-history-date">
                        {new Date(order.createdAt).toLocaleDateString(t('common.locale'), { day: 'numeric', month: 'long', year: 'numeric', hour: '2-digit', minute: '2-digit' })}
                      </span>
                    </div>
                    <div className="order-history-right">
                      <span className="order-type-badge">
                        {order.orderType === 'Delivery' ? t('orders.delivery') : t('orders.pickup')}
                      </span>
                      <span className="order-status-badge" style={{ background: `${color}22`, color, borderColor: `${color}44` }}>
                        {statusLabel}
                      </span>
                      {order.paidWithPoints && <span className="order-points-badge">⭐ Points</span>}
                    </div>
                  </div>

                  {order.orderType === 'Delivery' && order.deliveryAddress && (
                    <div className="order-history-address">
                      📍 {order.deliveryAddress}
                      {order.deliveryNote && <span> · 💬 {order.deliveryNote}</span>}
                    </div>
                  )}
                  <div className="order-history-items">
                    {order.items.map(item => (
                      <div key={item.id} className="order-history-item">
                        <span>{item.menuItemName} × {item.quantity}</span>
                        <span>{(item.unitPrice * item.quantity).toFixed(2)} $</span>
                      </div>
                    ))}
                  </div>

                  <div className="order-history-footer">
                    <span className="order-history-total">
                      {t('orders.total')}: <strong>{order.total.toFixed(2)} $</strong>
                      {order.paidWithPoints && (
                        <span className="order-points-note"> ({t('orders.paidWith', { pts: Math.round(order.total * 100).toLocaleString() })})</span>
                      )}
                    </span>
                    {!order.paidWithPoints && (
                      <span className="order-points-earned">{t('orders.pointsEarned', { pts: Math.round(order.total * 100).toLocaleString() })}</span>
                    )}
                  </div>
                </div>
              );
            })}
          </div>

          {(data?.totalPages ?? 1) > 1 && (
            <div className="pagination" style={{ display: 'flex', justifyContent: 'center', gap: '0.5rem', marginTop: '1.5rem' }}>
              <button className="btn-secondary" onClick={() => setPage(p => p - 1)} disabled={!data?.hasPrev}>
                ← Précédent
              </button>
              <span style={{ padding: '8px 12px', color: 'var(--text-muted)', fontSize: '0.875rem' }}>
                {page} / {data?.totalPages}
              </span>
              <button className="btn-secondary" onClick={() => setPage(p => p + 1)} disabled={!data?.hasNext}>
                Suivant →
              </button>
            </div>
          )}
        </>
      )}
    </main>
  );
}
