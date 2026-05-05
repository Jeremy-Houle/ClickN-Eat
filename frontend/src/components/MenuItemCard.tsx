import type { MenuItem } from '../types';
import { useCart } from '../context/CartContext';

interface Props {
  item: MenuItem;
}

export default function MenuItemCard({ item }: Props) {
  const { addItem, items } = useCart();
  const cartItem = items.find(i => i.menuItem.id === item.id);

  return (
    <div className="menu-card">
      <div className="menu-card-image">
        {item.imageUrl ? (
          <img src={item.imageUrl} alt={item.name} />
        ) : (
          <div className="menu-card-placeholder">🍽️</div>
        )}
      </div>
      <div className="menu-card-body">
        <h3>{item.name}</h3>
        <p className="menu-card-desc">{item.description}</p>
        <div className="menu-card-footer">
          <span className="menu-card-price">{item.price.toFixed(2)} $</span>
          <button className="btn-add" onClick={() => addItem(item)}>
            {cartItem ? `+ Ajouter (${cartItem.quantity})` : '+ Ajouter'}
          </button>
        </div>
      </div>
    </div>
  );
}
