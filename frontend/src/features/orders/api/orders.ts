import api from '@/shared/api/client';
import type { Order, PagedResult, CreateOrderDto } from '@/shared/types';

export const createOrder = (dto: CreateOrderDto) =>
  api.post<{ order: Order; newPoints: number; newTotalPointsEarned: number }>('/orders', dto).then(r => r.data);

export const getOrder = (id: number) =>
  api.get<Order>(`/orders/${id}`).then(r => r.data);

export const getMyOrders = (page = 1, pageSize = 20) =>
  api.get<PagedResult<Order>>('/orders/my', { params: { page, pageSize } }).then(r => r.data);

export const getAllOrders = (page = 1, pageSize = 50) =>
  api.get<PagedResult<Order>>('/orders', { params: { page, pageSize } }).then(r => r.data);

export const updateOrderStatus = (id: number, status: string) =>
  api.patch<Order>(`/orders/${id}/status`, { status }).then(r => r.data);
