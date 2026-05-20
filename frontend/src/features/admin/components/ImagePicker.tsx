import { useRef, useState } from 'react';
import { uploadImage } from '@/features/admin/api/uploads';
import { useLanguage } from '@/shared/context/LanguageContext';
import { translateApiError } from '@/shared/utils/apiError';

interface Props {
  value: string;
  onChange: (url: string) => void;
}

export default function ImagePicker({ value, onChange }: Props) {
  const inputRef = useRef<HTMLInputElement>(null);
  const [uploading, setUploading] = useState(false);
  const [error, setError] = useState('');
  const { t } = useLanguage();

  const handleFile = async (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0];
    if (!file) return;
    setUploading(true);
    setError('');
    try {
      const url = await uploadImage(file);
      onChange(url);
    } catch (err: any) {
      const data = err?.response?.data;
      setError(translateApiError(data, t, t('admin.imagePicker.uploadError')));
    } finally {
      setUploading(false);
    }
  };

  return (
    <div className="image-picker">
      <div
        className={`image-picker-zone ${uploading ? 'uploading' : ''}`}
        onClick={() => inputRef.current?.click()}
      >
        {value ? (
          <img src={value} alt={t('admin.imagePicker.preview')} className="image-picker-preview" />
        ) : (
          <div className="image-picker-placeholder">
            {uploading ? `⏳ ${t('admin.imagePicker.uploading')}` : `📷 ${t('admin.imagePicker.clickToChoose')}`}
            <span className="image-picker-hint">jpg, png, webp — max 5 MB</span>
          </div>
        )}
      </div>

      {value && (
        <button
          type="button"
          className="image-picker-remove"
          onClick={() => { onChange(''); if (inputRef.current) inputRef.current.value = ''; }}
        >
          ✕ {t('admin.imagePicker.remove')}
        </button>
      )}

      {error && <p className="error" style={{ marginTop: '4px' }}>{error}</p>}

      <input
        ref={inputRef}
        type="file"
        accept="image/jpeg,image/png,image/webp,image/gif"
        style={{ display: 'none' }}
        onChange={handleFile}
      />
    </div>
  );
}
