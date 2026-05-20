import api from '@/shared/api/client';
import type { PagedResult } from '@/shared/types';

export interface AdminStats {
  todayOrderCount: number;
  todayRevenue: number;
  totalOrderCount: number;
  totalRevenue: number;
  pendingCount: number;
  topItem: string;
  totalUsers: number;
}

export interface AdminUser {
  id: number;
  name: string;
  email: string;
  role: string;
  points: number;
  totalPointsEarned: number;
  isActive: boolean;
  createdAt: string;
}

export const getAdminStats = () =>
  api.get<AdminStats>('/admin/stats').then(r => r.data);

export const getAdminUsers = (page = 1, pageSize = 50) =>
  api.get<PagedResult<AdminUser>>('/admin/users', { params: { page, pageSize } }).then(r => r.data);

export const toggleUserStatus = (id: number) =>
  api.patch<{ id: number; isActive: boolean }>(`/admin/users/${id}/status`).then(r => r.data);

export const deleteUser = (id: number) =>
  api.delete(`/admin/users/${id}`);
