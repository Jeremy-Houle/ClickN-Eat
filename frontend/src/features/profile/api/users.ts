import api from '@/shared/api/client';

export const updateProfile = (name: string, email: string) =>
  api.put<{ name: string; email: string }>('/users/me', { name, email }).then(r => r.data);

export const updatePassword = (currentPassword: string, newPassword: string) =>
  api.put('/users/me/password', { currentPassword, newPassword });
