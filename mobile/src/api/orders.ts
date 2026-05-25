import { api } from './client';
import { Order } from '../types';

export interface CreateOrderDto {
  restaurantId: number;
  orderType: 'Pickup' | 'Delivery';
  deliveryAddress?: string;
  deliveryNote?: string;
  paidWithPoints: boolean;
  items: { menuItemId: number; quantity: number }[];
}

export const createOrder = (dto: CreateOrderDto) =>
  api.post<Order>('/api/orders', dto).then(r => r.data);

export const getMyOrders = () =>
  api.get<Order[]>('/api/orders/my').then(r => r.data);
