import api from '@/shared/api/client';

export interface Restaurant {
  id: number;
  name: string;
  description: string;
  coverImageUrl: string;
  accentColor: string;
  logoUrl: string;
}

export interface UpdateRestaurantDto {
  name: string;
  description: string;
  coverImageUrl?: string;
  logoUrl?: string;
  accentColor?: string;
}

export const getRestaurants = () =>
  api.get<Restaurant[]>('/restaurants').then(r => r.data);

export const updateRestaurant = (id: number, dto: UpdateRestaurantDto) =>
  api.put<Restaurant>(`/restaurants/${id}`, dto).then(r => r.data);
