import type { MenuItem } from '@/shared/types';
import { useCart } from '@/features/cart/context/CartContext';
import { useLanguage } from '@/shared/context/LanguageContext';

interface Props {
  item: MenuItem;
}

export default function MenuItemCard({ item }: Props) {
  const { addItem, items } = useCart();
  const { t } = useLanguage();
  const cartItem = items.find(i => i.menuItem.id === item.id);
  const tags = item.tags ? item.tags.split(',').filter(Boolean) : [];

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
        {tags.length > 0 && (
          <div className="menu-card-tags">
            {tags.map(tag => (
              <span key={tag} className="menu-tag">{t(`card.tags.${tag}`) || tag}</span>
            ))}
          </div>
        )}
        <div className="menu-card-footer">
          <span className="menu-card-price">{item.price.toFixed(2)} $</span>
          <button className="btn-add" onClick={() => addItem(item)}>
            {cartItem ? t('card.addWithQty', { qty: cartItem.quantity }) : t('card.add')}
          </button>
        </div>
      </div>
    </div>
  );
}
