import { createContext, useContext, useState, type ReactNode } from 'react';
import type { CartItem, MenuItem } from '@/shared/types';

interface CartContextType {
  items: CartItem[];
  addItem: (menuItem: MenuItem) => void;
  removeItem: (menuItemId: number) => void;
  updateQuantity: (menuItemId: number, quantity: number) => void;
  clearCart: () => void;
  switchRestaurant: (oldId: number | null, newId: number) => void;
  total: number;
  count: number;
}

const CartContext = createContext<CartContextType | null>(null);

const cartKey = (id: number) => `cart_${id}`;

function loadCart(restaurantId: number): CartItem[] {
  try {
    const raw = localStorage.getItem(cartKey(restaurantId));
    return raw ? JSON.parse(raw) : [];
  } catch {
    return [];
  }
}

function saveCart(restaurantId: number | null, items: CartItem[]) {
  if (restaurantId === null) return;
  if (items.length === 0) localStorage.removeItem(cartKey(restaurantId));
  else localStorage.setItem(cartKey(restaurantId), JSON.stringify(items));
}

export function CartProvider({ children }: { children: ReactNode }) {
  const [items, setItems] = useState<CartItem[]>([]);
  const [restaurantId, setRestaurantId] = useState<number | null>(null);

  const addItem = (menuItem: MenuItem) => {
    setItems(prev => {
      const existing = prev.find(i => i.menuItem.id === menuItem.id);
      const next = existing
        ? prev.map(i => i.menuItem.id === menuItem.id ? { ...i, quantity: i.quantity + 1 } : i)
        : [...prev, { menuItem, quantity: 1 }];
      saveCart(restaurantId, next);
      return next;
    });
  };

  const removeItem = (menuItemId: number) => {
    setItems(prev => {
      const next = prev.filter(i => i.menuItem.id !== menuItemId);
      saveCart(restaurantId, next);
      return next;
    });
  };

  const updateQuantity = (menuItemId: number, quantity: number) => {
    if (quantity <= 0) return removeItem(menuItemId);
    setItems(prev => {
      const next = prev.map(i => i.menuItem.id === menuItemId ? { ...i, quantity } : i);
      saveCart(restaurantId, next);
      return next;
    });
  };

  const clearCart = () => {
    setItems([]);
    if (restaurantId !== null) localStorage.removeItem(cartKey(restaurantId));
  };

  const switchRestaurant = (oldId: number | null, newId: number) => {
    saveCart(oldId, items);
    const saved = loadCart(newId);
    setItems(saved);
    setRestaurantId(newId);
  };

  const total = items.reduce((sum, i) => sum + i.menuItem.price * i.quantity, 0);
  const count = items.reduce((sum, i) => sum + i.quantity, 0);

  return (
    <CartContext.Provider value={{ items, addItem, removeItem, updateQuantity, clearCart, switchRestaurant, total, count }}>
      {children}
    </CartContext.Provider>
  );
}

export const useCart = () => {
  const ctx = useContext(CartContext);
  if (!ctx) throw new Error('useCart must be used within CartProvider');
  return ctx;
};
