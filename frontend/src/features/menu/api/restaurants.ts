import api from '@/shared/api/client';

export interface Restaurant {
  id: number;
  name: string;
  description: string;
  coverImageUrl: string;
  accentColor: string;
  logoUrl: string;
}

export const getRestaurants = () =>
  api.get<Restaurant[]>('/restaurants').then(r => r.data);
