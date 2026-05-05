import api from './client';
import type { MenuItem } from '../types';

export const getMenuItems = (category?: string) =>
  api.get<MenuItem[]>('/menuitems', { params: category ? { category } : {} }).then(r => r.data);

export const getCategories = () =>
  api.get<string[]>('/menuitems/categories').then(r => r.data);
