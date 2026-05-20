export function estimateTime(totalItems: number, orderType: string): string {
  let min: number, max: number;

  if (totalItems <= 3)       { min = 10; max = 15; }
  else if (totalItems <= 8)  { min = 15; max = 25; }
  else if (totalItems <= 15) { min = 25; max = 35; }
  else if (totalItems <= 30) { min = 35; max = 50; }
  else                       { min = 50; max = 70; }

  if (orderType === 'Delivery') { min += 15; max += 20; }

  return `${min}–${max} min`;
}
