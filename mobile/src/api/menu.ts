import { api } from './client';
import { MenuItem } from '../types';

export const getMenuItems = (restaurantId: number) =>
  api.get<MenuItem[]>(`/api/menuitems?restaurantId=${restaurantId}`).then(r => r.data);

export const getCategories = (restaurantId: number) =>
  api.get<string[]>(`/api/menuitems/categories?restaurantId=${restaurantId}`).then(r => r.data);
