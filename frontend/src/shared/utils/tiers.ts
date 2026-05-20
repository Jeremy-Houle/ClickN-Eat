export interface Tier {
  label: string;
  icon: string;
  color: string;
  min: number;
  next: number | null;
}

export const TIERS: Tier[] = [
  { label: 'Bronze',    icon: '🥉', color: '#cd7f32', min: 0,       next: 5_000   },
  { label: 'Argent',    icon: '🥈', color: '#94a3b8', min: 5_000,   next: 20_000  },
  { label: 'Or',        icon: '🥇', color: '#f59e0b', min: 20_000,  next: 50_000  },
  { label: 'Platine',   icon: '⚜️', color: '#e2e8f0', min: 50_000,  next: 100_000 },
  { label: 'Diamant',   icon: '💎', color: '#67e8f9', min: 100_000, next: 200_000 },
  { label: 'Président', icon: '👑', color: '#fbbf24', min: 200_000, next: null    },
];

export function getTier(points: number): Tier {
  return [...TIERS].reverse().find(t => points >= t.min) ?? TIERS[0];
}
