import { api } from './client';
import { Restaurant } from '../types';

export const getRestaurants = () =>
  api.get<Restaurant[]>('/api/restaurants').then(r => r.data);
