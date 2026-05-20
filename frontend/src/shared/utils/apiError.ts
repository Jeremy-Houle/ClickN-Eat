/**
 * Translates an API error code returned by the backend (e.g. "errors.auth.emailTaken")
 * into a user-facing message using the active language's translations.
 * Falls back to `fallback` for unknown or non-code strings.
 */
export function translateApiError(
  data: unknown,
  t: (key: string) => string,
  fallback: string
): string {
  if (typeof data === 'string' && data.startsWith('errors.')) {
    return t(data);
  }
  return fallback;
}
