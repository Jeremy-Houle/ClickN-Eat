import { useEffect, useState } from 'react';
import { useParams, useNavigate } from 'react-router-dom';
import { getOrder } from '../api/orders';
import type { Order } from '../types';

export default function ConfirmationPage() {
  const { id } = useParams<{ id: string }>();
  const [order, setOrder] = useState<Order | null>(null);
  const navigate = useNavigate();

  useEffect(() => {
    if (id) getOrder(Number(id)).then(setOrder).catch(() => {});
  }, [id]);

  if (!order) return <main className="container center"><p>Chargement...</p></main>;

  return (
    <main className="container center">
      <div className="confirmation-card">
        <div className="confirmation-icon">✅</div>
        <h1>Commande confirmée!</h1>
        <p>Merci {order.customerName}, votre commande #{order.id} a été reçue.</p>
        <div className="order-summary">
          {order.items.map(item => (
            <div key={item.id} className="order-summary-row">
              <span>{item.menuItemName} × {item.quantity}</span>
              <span>{(item.unitPrice * item.quantity).toFixed(2)} $</span>
            </div>
          ))}
          <div className="order-summary-row total">
            <strong>Total</strong>
            <strong>{order.total.toFixed(2)} $</strong>
          </div>
        </div>
        <p className="status-badge">Statut: {order.status}</p>
        <button className="btn-primary" onClick={() => navigate('/')}>Retour au menu</button>
      </div>
    </main>
  );
}
