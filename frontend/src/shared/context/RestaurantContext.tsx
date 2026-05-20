import { createContext, useContext, useState } from 'react';
import type { Restaurant } from '@/features/menu/api/restaurants';

interface RestaurantContextType {
  restaurant: Restaurant | null;
  setRestaurant: (r: Restaurant | null) => void;
}

const RestaurantContext = createContext<RestaurantContextType>({
  restaurant: null,
  setRestaurant: () => {},
});

export function RestaurantProvider({ children }: { children: React.ReactNode }) {
  const [restaurant, setRestaurant] = useState<Restaurant | null>(null);
  return (
    <RestaurantContext.Provider value={{ restaurant, setRestaurant }}>
      {children}
    </RestaurantContext.Provider>
  );
}

export const useRestaurant = () => useContext(RestaurantContext);
