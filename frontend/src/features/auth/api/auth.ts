import api from '@/shared/api/client';

export interface AuthResponse {
  token: string;
  name: string;
  email: string;
  role: string;
  points: number;
  totalPointsEarned: number;
}

export const register = (name: string, email: string, password: string) =>
  api.post<AuthResponse>('/auth/register', { name, email, password }).then(r => r.data);

export const login = (email: string, password: string) =>
  api.post<AuthResponse>('/auth/login', { email, password }).then(r => r.data);
