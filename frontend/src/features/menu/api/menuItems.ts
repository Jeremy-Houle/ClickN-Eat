import api from '@/shared/api/client';
import type { MenuItem } from '@/shared/types';

export const getMenuItems = (restaurantId: number, category?: string) =>
  api.get<MenuItem[]>('/menuitems', { params: { restaurantId, ...(category ? { category } : {}) } }).then(r => r.data);

export const getCategories = (restaurantId: number) =>
  api.get<string[]>('/menuitems/categories', { params: { restaurantId } }).then(r => r.data);

export const getAllMenuItems = (restaurantId?: number) =>
  api.get<MenuItem[]>('/menuitems', { params: { includeAll: true, ...(restaurantId ? { restaurantId } : {}) } }).then(r => r.data);

export const getAllCategories = (restaurantId?: number) =>
  api.get<string[]>('/menuitems/categories', { params: { includeAll: true, ...(restaurantId ? { restaurantId } : {}) } }).then(r => r.data);

export const createMenuItem = (item: Omit<MenuItem, 'id'>) =>
  api.post<MenuItem>('/menuitems', item).then(r => r.data);

export const updateMenuItem = (id: number, item: MenuItem) =>
  api.put<void>(`/menuitems/${id}`, item);

export const deleteMenuItem = (id: number) =>
  api.delete(`/menuitems/${id}`);
