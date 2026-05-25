export interface User {
  id: number;
  name: string;
  email: string;
  role: string;
  points: number;
  totalPointsEarned: number;
}

export interface Restaurant {
  id: number;
  name: string;
  description: string;
  coverImageUrl: string;
  logoUrl: string;
  accentColor: string;
}

export interface MenuItem {
  id: number;
  name: string;
  description: string;
  price: number;
  category: string;
  imageUrl: string;
  isAvailable: boolean;
  restaurantId: number;
  tags: string;
}

export interface OrderItem {
  menuItemId: number;
  menuItemName: string;
  quantity: number;
  unitPrice: number;
}

export interface Order {
  id: number;
  status: string;
  orderType: string;
  total: number;
  deliveryAddress?: string;
  deliveryNote?: string;
  paidWithPoints: boolean;
  createdAt: string;
  items: OrderItem[];
  customerName: string;
  customerEmail: string;
}

export interface CartItem {
  item: MenuItem;
  quantity: number;
}
