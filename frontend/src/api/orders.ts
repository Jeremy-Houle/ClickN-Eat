import api from './client';
import type { Order, CreateOrderDto } from '../types';

export const createOrder = (dto: CreateOrderDto) =>
  api.post<Order>('/orders', dto).then(r => r.data);

export const getOrder = (id: number) =>
  api.get<Order>(`/orders/${id}`).then(r => r.data);
