import { createContext, useContext, useState, useEffect, type ReactNode } from 'react';
import { useAuth } from '@/shared/context/AuthContext';
import fr from '@/shared/i18n/fr.json';
import es from '@/shared/i18n/es.json';
import de from '@/shared/i18n/de.json';
import en from '@/shared/i18n/en.json';

export type Lang = 'fr' | 'en' | 'es' | 'de';

const TRANSLATIONS: Record<Lang, Record<string, unknown>> = { fr, es, de, en };

function getNestedValue(obj: Record<string, unknown>, key: string): string {
  const parts = key.split('.');
  let current: unknown = obj;
  for (const part of parts) {
    if (current == null || typeof current !== 'object') return key;
    current = (current as Record<string, unknown>)[part];
  }
  return typeof current === 'string' ? current : key;
}

interface LanguageContextType {
  lang: Lang;
  setLang: (lang: Lang) => void;
  t: (key: string, params?: Record<string, string | number>) => string;
  tCat: (category: string) => string;
}

const LanguageContext = createContext<LanguageContextType | null>(null);

export function LanguageProvider({ children }: { children: ReactNode }) {
  const { user } = useAuth();

  const storageKey = user ? `app_lang_${user.email}` : 'app_lang_guest';

  const [lang, setLangState] = useState<Lang>(() => {
    const saved = localStorage.getItem(storageKey) as Lang | null;
    return saved && saved in TRANSLATIONS ? saved : 'fr';
  });

  useEffect(() => {
    const saved = localStorage.getItem(storageKey) as Lang | null;
    setLangState(saved && saved in TRANSLATIONS ? saved : 'fr');
  }, [storageKey]);

  const setLang = (newLang: Lang) => {
    localStorage.setItem(storageKey, newLang);
    setLangState(newLang);
  };

  const t = (key: string, params?: Record<string, string | number>): string => {
    let value = getNestedValue(TRANSLATIONS[lang] as Record<string, unknown>, key);
    if (params) {
      value = value.replace(/\{\{(\w+)\}\}/g, (_, k) => String(params[k] ?? ''));
    }
    return value;
  };

  const tCat = (category: string): string => {
    const translated = getNestedValue(TRANSLATIONS[lang] as Record<string, unknown>, `categories.${category}`);
    return translated !== `categories.${category}` ? translated : category;
  };

  return (
    <LanguageContext.Provider value={{ lang, setLang, t, tCat }}>
      {children}
    </LanguageContext.Provider>
  );
}

export function useLanguage() {
  const ctx = useContext(LanguageContext);
  if (!ctx) throw new Error('useLanguage must be used within LanguageProvider');
  return ctx;
}
