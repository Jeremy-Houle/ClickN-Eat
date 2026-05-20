import { createContext, useContext, useState, type ReactNode } from 'react';
import type { AuthResponse } from '@/features/auth/api/auth';

interface AuthContextType {
  user: AuthResponse | null;
  login: (data: AuthResponse) => void;
  logout: () => void;
  updatePoints: (newPoints: number, newTotalPointsEarned: number) => void;
  updateProfile: (name: string, email: string) => void;
  isAuthenticated: boolean;
}

const AuthContext = createContext<AuthContextType | null>(null);

const STORAGE_KEY = 'clickneat_user';

export function AuthProvider({ children }: { children: ReactNode }) {
  const [user, setUser] = useState<AuthResponse | null>(() => {
    try {
      const saved = localStorage.getItem(STORAGE_KEY);
      if (!saved) return null;
      const parsed = JSON.parse(saved);
      return { ...parsed, points: parsed.points ?? 0, totalPointsEarned: parsed.totalPointsEarned ?? parsed.points ?? 0 };
    } catch {
      localStorage.removeItem(STORAGE_KEY);
      return null;
    }
  });

  const login = (data: AuthResponse) => {
    localStorage.setItem(STORAGE_KEY, JSON.stringify(data));
    setUser(data);
  };

  const logout = () => {
    localStorage.removeItem(STORAGE_KEY);
    setUser(null);
  };

  const updateProfile = (name: string, email: string) => {
    setUser(prev => {
      if (!prev) return prev;
      const updated = { ...prev, name, email };
      localStorage.setItem(STORAGE_KEY, JSON.stringify(updated));
      return updated;
    });
  };

  const updatePoints = (newPoints: number, newTotalPointsEarned: number) => {
    setUser(prev => {
      if (!prev) return prev;
      const updated = { ...prev, points: newPoints, totalPointsEarned: newTotalPointsEarned };
      localStorage.setItem(STORAGE_KEY, JSON.stringify(updated));
      return updated;
    });
  };

  return (
    <AuthContext.Provider value={{ user, login, logout, updatePoints, updateProfile, isAuthenticated: !!user }}>
      {children}
    </AuthContext.Provider>
  );
}

export const useAuth = () => {
  const ctx = useContext(AuthContext);
  if (!ctx) throw new Error('useAuth must be used within AuthProvider');
  return ctx;
};
