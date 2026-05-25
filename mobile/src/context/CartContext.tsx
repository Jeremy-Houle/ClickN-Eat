import React, { createContext, useContext, useState } from 'react';
import { CartItem, MenuItem } from '../types';

interface CartContextValue {
  items: CartItem[];
  restaurantId: number | null;
  add: (item: MenuItem) => void;
  remove: (itemId: number) => void;
  clear: () => void;
  total: number;
  count: number;
}

const CartContext = createContext<CartContextValue | null>(null);

export function CartProvider({ children }: { children: React.ReactNode }) {
  const [items, setItems] = useState<CartItem[]>([]);
  const [restaurantId, setRestaurantId] = useState<number | null>(null);

  const add = (item: MenuItem) => {
    if (restaurantId && restaurantId !== item.restaurantId) {
      setItems([{ item, quantity: 1 }]);
      setRestaurantId(item.restaurantId);
      return;
    }
    setRestaurantId(item.restaurantId);
    setItems(prev => {
      const existing = prev.find(c => c.item.id === item.id);
      if (existing) return prev.map(c => c.item.id === item.id ? { ...c, quantity: c.quantity + 1 } : c);
      return [...prev, { item, quantity: 1 }];
    });
  };

  const remove = (itemId: number) => {
    setItems(prev => {
      const next = prev.map(c => c.item.id === itemId ? { ...c, quantity: c.quantity - 1 } : c).filter(c => c.quantity > 0);
      if (next.length === 0) setRestaurantId(null);
      return next;
    });
  };

  const clear = () => { setItems([]); setRestaurantId(null); };

  const total = items.reduce((s, c) => s + c.item.price * c.quantity, 0);
  const count = items.reduce((s, c) => s + c.quantity, 0);

  return (
    <CartContext.Provider value={{ items, restaurantId, add, remove, clear, total, count }}>
      {children}
    </CartContext.Provider>
  );
}

export function useCart() {
  const ctx = useContext(CartContext);
  if (!ctx) throw new Error('useCart must be used within CartProvider');
  return ctx;
}
