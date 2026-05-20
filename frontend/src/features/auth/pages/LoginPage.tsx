import { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { login as apiLogin } from '@/features/auth/api/auth';
import { useAuth } from '@/shared/context/AuthContext';
import { useLanguage } from '@/shared/context/LanguageContext';
import { translateApiError } from '@/shared/utils/apiError';

export default function LoginPage() {
  const [form, setForm] = useState({ email: '', password: '' });
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);
  const { login } = useAuth();
  const { t } = useLanguage();
  const navigate = useNavigate();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setLoading(true);
    setError('');
    try {
      const data = await apiLogin(form.email, form.password);
      login(data);
      navigate('/');
    } catch (err: any) {
      const data = err?.response?.data;
      const fallback = err?.response?.status === 403 ? t('login.disabled') : t('login.invalid');
      setError(translateApiError(data, t, fallback));
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="auth-bg">
      <form className="auth-form" onSubmit={handleSubmit}>
        <div className="auth-title">🍔 ClickN'Eat</div>
        <h2>{t('login.title')}</h2>
        <div className="auth-divider" />
        <input
          type="email" placeholder={t('login.email')} required autoComplete="email"
          value={form.email} onChange={e => setForm(f => ({ ...f, email: e.target.value }))}
        />
        <input
          type="password" placeholder={t('login.password')} required autoComplete="current-password"
          value={form.password} onChange={e => setForm(f => ({ ...f, password: e.target.value }))}
        />
        {error && <p className="error">{error}</p>}
        <button type="submit" className="btn-primary" disabled={loading}>
          {loading ? t('login.loggingIn') : t('login.submit')}
        </button>
        <p className="auth-switch">
          {t('login.noAccount')} <Link to="/register">{t('login.signUp')}</Link>
        </p>
      </form>
    </div>
  );
}
