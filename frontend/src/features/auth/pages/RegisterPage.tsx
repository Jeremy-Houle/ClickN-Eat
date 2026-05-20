import { useState } from 'react';
import { useNavigate, Link } from 'react-router-dom';
import { register as apiRegister } from '@/features/auth/api/auth';
import { useAuth } from '@/shared/context/AuthContext';
import { useLanguage } from '@/shared/context/LanguageContext';
import { translateApiError } from '@/shared/utils/apiError';

export default function RegisterPage() {
  const [form, setForm] = useState({ name: '', email: '', password: '', confirm: '' });
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);
  const { login } = useAuth();
  const { t } = useLanguage();
  const navigate = useNavigate();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (form.password !== form.confirm) { setError(t('register.mismatch')); return; }
    if (form.password.length < 8) { setError(t('register.tooShort')); return; }
    setLoading(true);
    setError('');
    try {
      const data = await apiRegister(form.name, form.email, form.password);
      login(data);
      navigate('/');
    } catch (err: any) {
      const data = err?.response?.data;
      setError(translateApiError(data, t, t('register.emailTaken')));
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="auth-bg">
      <form className="auth-form" onSubmit={handleSubmit}>
        <div className="auth-title">🍔 ClickN'Eat</div>
        <h2>{t('register.title')}</h2>
        <div className="auth-divider" />
        <input
          type="text" placeholder={t('register.fullName')} required autoComplete="off"
          value={form.name} onChange={e => setForm(f => ({ ...f, name: e.target.value }))}
        />
        <input
          type="email" placeholder={t('register.email')} required autoComplete="off"
          value={form.email} onChange={e => setForm(f => ({ ...f, email: e.target.value }))}
        />
        <input
          type="password" placeholder={t('register.passwordHint')} required autoComplete="new-password"
          value={form.password} onChange={e => setForm(f => ({ ...f, password: e.target.value }))}
        />
        <input
          type="password" placeholder={t('register.confirmPassword')} required autoComplete="new-password"
          value={form.confirm} onChange={e => setForm(f => ({ ...f, confirm: e.target.value }))}
        />
        {error && <p className="error">{error}</p>}
        <button type="submit" className="btn-primary" disabled={loading}>
          {loading ? t('register.creating') : t('register.submit')}
        </button>
        <p className="auth-switch">
          {t('register.alreadyAccount')} <Link to="/login">{t('register.signIn')}</Link>
        </p>
      </form>
    </div>
  );
}
