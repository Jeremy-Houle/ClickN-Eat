import { useState } from 'react';
import { useNavigate } from 'react-router-dom';
import { useAuth } from '@/shared/context/AuthContext';
import { useToast } from '@/shared/context/ToastContext';
import { useLanguage } from '@/shared/context/LanguageContext';
import type { Lang } from '@/shared/context/LanguageContext';
import { updateProfile as apiUpdateProfile, updatePassword } from '@/features/profile/api/users';
import { getTier, TIERS } from '@/shared/utils/tiers';
import { translateApiError } from '@/shared/utils/apiError';

const LANG_FLAGS: Record<Lang, string> = { fr: '🇫🇷', en: '🇬🇧', es: '🇪🇸', de: '🇩🇪' };

export default function ProfilePage() {
  const { user, logout, updateProfile } = useAuth();
  const { toast } = useToast();
  const { t, lang, setLang } = useLanguage();
  const navigate = useNavigate();

  const [editingProfile, setEditingProfile] = useState(false);
  const [profileForm, setProfileForm] = useState({ name: user?.name ?? '', email: user?.email ?? '' });
  const [profileLoading, setProfileLoading] = useState(false);
  const [profileError, setProfileError] = useState('');

  const [editingPassword, setEditingPassword] = useState(false);
  const [pwForm, setPwForm] = useState({ current: '', next: '', confirm: '' });
  const [pwLoading, setPwLoading] = useState(false);
  const [pwError, setPwError] = useState('');

  if (!user) { navigate('/login'); return null; }

  const tierPoints = user.totalPointsEarned ?? 0;
  const tier = getTier(tierPoints);
  const progress = tier.next
    ? Math.min(((tierPoints - tier.min) / (tier.next - tier.min)) * 100, 100)
    : 100;

  const handleProfileSave = async (e: React.FormEvent) => {
    e.preventDefault();
    setProfileLoading(true);
    setProfileError('');
    try {
      const updated = await apiUpdateProfile(profileForm.name, profileForm.email);
      updateProfile(updated.name, updated.email);
      toast(t('profile.profileUpdated'));
      setEditingProfile(false);
    } catch (err: any) {
      const data = err?.response?.data;
      setProfileError(translateApiError(data, t, t('profile.updateError')));
    } finally {
      setProfileLoading(false);
    }
  };

  const handlePasswordSave = async (e: React.FormEvent) => {
    e.preventDefault();
    if (pwForm.next !== pwForm.confirm) { setPwError(t('profile.passwordMismatch')); return; }
    if (pwForm.next.length < 8) { setPwError(t('profile.passwordTooShort')); return; }
    setPwLoading(true);
    setPwError('');
    try {
      await updatePassword(pwForm.current, pwForm.next);
      toast(t('profile.passwordUpdated'));
      setEditingPassword(false);
      setPwForm({ current: '', next: '', confirm: '' });
    } catch (err: any) {
      const data = err?.response?.data;
      setPwError(translateApiError(data, t, t('profile.passwordError')));
    } finally {
      setPwLoading(false);
    }
  };

  return (
    <main className="container profile-page">
      <h1 className="page-title">{t('profile.title')}</h1>

      <div className="profile-grid">

        <div className="profile-card profile-info-card">
          <div className="profile-avatar">{user.name.charAt(0).toUpperCase()}</div>
          <div className="profile-details" style={{ flex: 1 }}>
            {editingProfile ? (
              <form onSubmit={handleProfileSave} className="profile-edit-form">
                <input
                  type="text" placeholder={t('profile.fullName')} required
                  value={profileForm.name} onChange={e => setProfileForm(f => ({ ...f, name: e.target.value }))}
                />
                <input
                  type="email" placeholder={t('profile.email')} required
                  value={profileForm.email} onChange={e => setProfileForm(f => ({ ...f, email: e.target.value }))}
                />
                {profileError && <p className="error" style={{ marginTop: 0 }}>{profileError}</p>}
                <div style={{ display: 'flex', gap: '0.5rem' }}>
                  <button type="submit" className="btn-primary" disabled={profileLoading} style={{ flex: 1, padding: '8px' }}>
                    {profileLoading ? '...' : t('profile.save')}
                  </button>
                  <button type="button" className="btn-secondary" onClick={() => { setEditingProfile(false); setProfileError(''); setProfileForm({ name: user.name, email: user.email }); }} style={{ padding: '8px' }}>
                    {t('profile.cancel')}
                  </button>
                </div>
              </form>
            ) : (
              <>
                <h2>{user.name}</h2>
                <p>{user.email}</p>
                <span className="profile-role">{user.role === 'Admin' ? t('profile.roleAdmin') : t('profile.roleClient')}</span>
              </>
            )}
          </div>
          {!editingProfile && (
            <button className="btn-icon btn-edit-icon" title={t('profile.editProfile')} onClick={() => setEditingProfile(true)}>✏️</button>
          )}
        </div>

        {user.role !== 'Admin' && (
          <div className="profile-card profile-points-card">
            <div className="profile-points-header">
              <span>{t('profile.loyalty')}</span>
              <span className="profile-tier" style={{ color: tier.color }}>
                {tier.icon} {tier.label}
              </span>
            </div>

            <div className="profile-points-value">
              ⭐ <strong>{user.points.toLocaleString()}</strong> {t('profile.availablePoints')}
            </div>
            <div style={{ fontSize: '0.8rem', color: 'var(--text-muted)' }}>
              {tierPoints.toLocaleString()} {t('profile.lifetimePts')}
            </div>

            {tier.next ? (
              <>
                <div className="profile-progress-bar">
                  <div className="profile-progress-fill" style={{ width: `${progress}%`, background: tier.color }} />
                </div>
                <p className="profile-progress-label">
                  {(tier.next - tierPoints).toLocaleString()} {t('profile.ptsToNext')} {TIERS[TIERS.indexOf(tier) + 1].icon} {TIERS[TIERS.indexOf(tier) + 1].label}
                </p>
              </>
            ) : (
              <p className="profile-progress-label" style={{ color: tier.color }}>
                {tier.icon} {t('profile.maxRank')}
              </p>
            )}

            <div className="profile-tiers-list">
              {TIERS.map(t2 => (
                <div key={t2.label} className={`profile-tier-row${t2.label === tier.label ? ' current' : ''}${tierPoints >= t2.min ? ' unlocked' : ''}`}>
                  <span className="profile-tier-icon">{t2.icon}</span>
                  <span className="profile-tier-name">{t2.label}</span>
                  <span className="profile-tier-req">{t2.min.toLocaleString()} pts</span>
                </div>
              ))}
            </div>

            <div className="profile-points-legend">
              <span>{t('profile.pointsRule1')}</span>
              <span>{t('profile.pointsRule2')}</span>
            </div>
          </div>
        )}

        <div className="profile-card">
          <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
            <h3 style={{ fontSize: '0.85rem', fontWeight: 700, color: 'var(--text-muted)', textTransform: 'uppercase', letterSpacing: '0.5px' }}>
              {t('profile.password')}
            </h3>
            {!editingPassword && (
              <button className="btn-secondary" style={{ padding: '6px 14px', fontSize: '0.82rem' }} onClick={() => setEditingPassword(true)}>
                {t('profile.modify')}
              </button>
            )}
          </div>

          {editingPassword ? (
            <form onSubmit={handlePasswordSave} className="profile-edit-form">
              <input type="password" placeholder={t('profile.currentPassword')} required value={pwForm.current} onChange={e => setPwForm(f => ({ ...f, current: e.target.value }))} />
              <input type="password" placeholder={t('profile.newPassword')} required value={pwForm.next} onChange={e => setPwForm(f => ({ ...f, next: e.target.value }))} />
              <input type="password" placeholder={t('profile.confirmNewPassword')} required value={pwForm.confirm} onChange={e => setPwForm(f => ({ ...f, confirm: e.target.value }))} />
              {pwError && <p className="error" style={{ marginTop: 0 }}>{pwError}</p>}
              <div style={{ display: 'flex', gap: '0.5rem' }}>
                <button type="submit" className="btn-primary" disabled={pwLoading} style={{ flex: 1, padding: '8px' }}>
                  {pwLoading ? '...' : t('profile.save')}
                </button>
                <button type="button" className="btn-secondary" onClick={() => { setEditingPassword(false); setPwError(''); setPwForm({ current: '', next: '', confirm: '' }); }} style={{ padding: '8px' }}>
                  {t('profile.cancel')}
                </button>
              </div>
            </form>
          ) : (
            <p style={{ fontSize: '0.85rem', color: 'var(--text-muted)' }}>••••••••</p>
          )}
        </div>

        <div className="profile-card">
          <h3 style={{ fontSize: '0.85rem', fontWeight: 700, color: 'var(--text-muted)', textTransform: 'uppercase', letterSpacing: '0.5px', marginBottom: '0.75rem' }}>
            {t('profile.language')}
          </h3>
          <div style={{ display: 'flex', gap: '0.5rem' }}>
            {(['fr', 'en', 'es', 'de'] as Lang[]).map(l => (
              <button
                key={l}
                onClick={() => setLang(l)}
                className={lang === l ? 'btn-primary' : 'btn-secondary'}
                style={{ flex: 1, padding: '8px', fontSize: '0.9rem' }}
              >
                {LANG_FLAGS[l]} {t(`settings.${l}`)}
              </button>
            ))}
          </div>
        </div>

        <div className="profile-card profile-actions-card">
          <h3>{t('profile.quickActions')}</h3>
          <button className="profile-action-btn" onClick={() => navigate('/')}>
            {t('profile.chooseRestaurant')}
          </button>
          {user.role !== 'Admin' && (
            <button className="profile-action-btn" onClick={() => navigate('/orders')}>
              {t('profile.myOrders')}
            </button>
          )}
          {user.role === 'Admin' && (
            <button className="profile-action-btn" onClick={() => navigate('/admin')}>
              {t('profile.administration')}
            </button>
          )}
          <button className="profile-action-btn profile-action-logout" onClick={() => { logout(); navigate('/login'); }}>
            {t('profile.signOut')}
          </button>
        </div>

      </div>
    </main>
  );
}
