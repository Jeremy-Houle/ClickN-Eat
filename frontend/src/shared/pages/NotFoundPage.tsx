import { useNavigate } from 'react-router-dom';
import { useLanguage } from '@/shared/context/LanguageContext';

export default function NotFoundPage() {
  const navigate = useNavigate();
  const { t } = useLanguage();

  return (
    <main className="not-found-page">
      <div className="not-found-code">404</div>
      <h1 className="not-found-title">{t('notFound.title')}</h1>
      <p className="not-found-sub">{t('notFound.sub')}</p>
      <button className="btn-primary" onClick={() => navigate('/')}>
        {t('notFound.back')}
      </button>
    </main>
  );
}
