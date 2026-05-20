import { BrowserRouter, Routes, Route, Navigate } from 'react-router-dom';
import { CartProvider } from '@/features/cart/context/CartContext';
import { AuthProvider, useAuth } from '@/shared/context/AuthContext';
import { RestaurantProvider } from '@/shared/context/RestaurantContext';
import { ToastProvider } from '@/shared/context/ToastContext';
import { ThemeProvider } from '@/shared/context/ThemeContext';
import { LanguageProvider } from '@/shared/context/LanguageContext';
import Navbar from '@/shared/components/Navbar';
import ErrorBoundary from '@/shared/components/ErrorBoundary';
import RestaurantSelectionPage from '@/features/menu/pages/RestaurantSelectionPage';
import MenuPage from '@/features/menu/pages/MenuPage';
import CartPage from '@/features/cart/pages/CartPage';
import ConfirmationPage from '@/features/cart/pages/ConfirmationPage';
import LoginPage from '@/features/auth/pages/LoginPage';
import RegisterPage from '@/features/auth/pages/RegisterPage';
import AdminPage from '@/features/admin/pages/AdminPage';
import ProfilePage from '@/features/profile/pages/ProfilePage';
import OrderHistoryPage from '@/features/orders/pages/OrderHistoryPage';
import NotFoundPage from '@/shared/pages/NotFoundPage';
import './App.css';

function ProtectedRoute({ children }: { children: React.ReactNode }) {
  const { isAuthenticated } = useAuth();
  return isAuthenticated ? <>{children}</> : <Navigate to="/login" replace />;
}

function AdminRoute({ children }: { children: React.ReactNode }) {
  const { user, isAuthenticated } = useAuth();
  if (!isAuthenticated) return <Navigate to="/login" replace />;
  if (user?.role !== 'Admin') return <Navigate to="/" replace />;
  return <>{children}</>;
}

function AppRoutes() {
  return (
    <>
      <Navbar />
      <Routes>
        <Route path="/login" element={<LoginPage />} />
        <Route path="/register" element={<RegisterPage />} />
        <Route path="/" element={<ProtectedRoute><RestaurantSelectionPage /></ProtectedRoute>} />
        <Route path="/menu" element={<ProtectedRoute><MenuPage /></ProtectedRoute>} />
        <Route path="/cart" element={<ProtectedRoute><CartPage /></ProtectedRoute>} />
        <Route path="/confirmation/:id" element={<ProtectedRoute><ConfirmationPage /></ProtectedRoute>} />
        <Route path="/profile" element={<ProtectedRoute><ProfilePage /></ProtectedRoute>} />
        <Route path="/orders" element={<ProtectedRoute><OrderHistoryPage /></ProtectedRoute>} />
        <Route path="/admin" element={<AdminRoute><AdminPage /></AdminRoute>} />
        <Route path="*" element={<NotFoundPage />} />
      </Routes>
    </>
  );
}

export default function App() {
  return (
    <ErrorBoundary>
      <ThemeProvider>
        <ToastProvider>
          <AuthProvider>
            <LanguageProvider>
              <RestaurantProvider>
                <CartProvider>
                  <BrowserRouter>
                    <AppRoutes />
                  </BrowserRouter>
                </CartProvider>
              </RestaurantProvider>
            </LanguageProvider>
          </AuthProvider>
        </ToastProvider>
      </ThemeProvider>
    </ErrorBoundary>
  );
}
