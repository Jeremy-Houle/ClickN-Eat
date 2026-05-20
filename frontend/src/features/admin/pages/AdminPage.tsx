import { useState } from 'react';
import { useQuery, useMutation, useQueryClient } from '@tanstack/react-query';
import { getAllMenuItems, getAllCategories, deleteMenuItem, createMenuItem, updateMenuItem } from '@/features/menu/api/menuItems';
import { getAllOrders, updateOrderStatus } from '@/features/orders/api/orders';
import { getAdminStats, getAdminUsers, toggleUserStatus, deleteUser, type AdminStats, type AdminUser } from '@/features/admin/api/admin';
import { getRestaurants } from '@/features/menu/api/restaurants';
import ImagePicker from '@/features/admin/components/ImagePicker';
import { useToast } from '@/shared/context/ToastContext';
import { useLanguage } from '@/shared/context/LanguageContext';
import { getTier } from '@/shared/utils/tiers';
import type { MenuItem, Order } from '@/shared/types';

const STATUS_COLORS: Record<string, string> = {
  Pending:   '#f59e0b',
  Confirmed: '#6366f1',
  Preparing: '#3b82f6',
  Ready:     '#4ade80',
  Delivered: '#22c55e',
  Cancelled: '#f87171',
};
const ALL_STATUSES = Object.keys(STATUS_COLORS);
const EMPTY_FORM = { name: '', description: '', price: '', category: '', imageUrl: '', isAvailable: true, restaurantId: 1 };

type Tab = 'items' | 'orders' | 'stats' | 'users';

export default function AdminPage() {
  const { toast } = useToast();
  const { t, tCat } = useLanguage();
  const qc = useQueryClient();
  const [activeTab, setActiveTab] = useState<Tab>('items');
  const [activeRestaurantId, setActiveRestaurantId] = useState<number>(1);
  const [filterCat, setFilterCat] = useState('');
  const [ordersPage, setOrdersPage] = useState(1);
  const [usersPage, setUsersPage] = useState(1);

  // — Modal state —
  const [modalOpen, setModalOpen] = useState(false);
  const [editingItem, setEditingItem] = useState<MenuItem | null>(null);
  const [form, setForm] = useState(EMPTY_FORM);
  const [formTags, setFormTags] = useState<string[]>([]);
  const [customCategory, setCustomCategory] = useState('');
  const [formError, setFormError] = useState('');

  // — Queries —
  const { data: restaurants = [] } = useQuery({
    queryKey: ['restaurants'],
    queryFn: getRestaurants,
  });

  const { data: items = [] } = useQuery({
    queryKey: ['adminItems', activeRestaurantId],
    queryFn: () => getAllMenuItems(activeRestaurantId),
  });

  const { data: categories = [] } = useQuery({
    queryKey: ['adminCategories', activeRestaurantId],
    queryFn: () => getAllCategories(activeRestaurantId),
  });

  const { data: ordersData } = useQuery({
    queryKey: ['adminOrders', ordersPage],
    queryFn: () => getAllOrders(ordersPage, 50),
    enabled: activeTab === 'orders',
    placeholderData: prev => prev,
  });

  const { data: stats } = useQuery({
    queryKey: ['adminStats'],
    queryFn: getAdminStats,
    enabled: activeTab === 'stats',
  });

  const { data: usersData } = useQuery({
    queryKey: ['adminUsers', usersPage],
    queryFn: () => getAdminUsers(usersPage, 50),
    enabled: activeTab === 'users',
    placeholderData: prev => prev,
  });

  const orders = ordersData?.items ?? [];
  const users = usersData?.items ?? [];

  // — Mutations —
  const invalidateItems = () => qc.invalidateQueries({ queryKey: ['adminItems', activeRestaurantId] });
  const invalidateCategories = () => qc.invalidateQueries({ queryKey: ['adminCategories', activeRestaurantId] });

  const createMutation = useMutation({
    mutationFn: createMenuItem,
    onSuccess: () => { toast(t('admin.modal.itemAdded')); invalidateItems(); invalidateCategories(); closeModal(); },
    onError: (err: any) => setFormError(err?.response?.data?.title || err?.response?.data || t('admin.modal.error')),
  });

  const updateMutation = useMutation({
    mutationFn: ({ id, item }: { id: number; item: MenuItem }) => updateMenuItem(id, item),
    onSuccess: () => { toast(t('admin.modal.itemUpdated')); invalidateItems(); invalidateCategories(); closeModal(); },
    onError: (err: any) => setFormError(err?.response?.data?.title || err?.response?.data || t('admin.modal.error')),
  });

  const deleteMutation = useMutation({
    mutationFn: deleteMenuItem,
    onSuccess: (_, id) => { toast(t('admin.modal.deleted', { name: items.find(i => i.id === id)?.name ?? '' }), 'error'); invalidateItems(); invalidateCategories(); },
    onError: () => toast(t('admin.modal.error'), 'error'),
  });

  const toggleMutation = useMutation({
    mutationFn: ({ id }: { id: number; item: MenuItem }) => updateMenuItem(id, { ...items.find(i => i.id === id)!, isAvailable: !items.find(i => i.id === id)!.isAvailable }),
    onSuccess: () => invalidateItems(),
  });

  const statusMutation = useMutation({
    mutationFn: ({ id, status }: { id: number; status: string }) => updateOrderStatus(id, status),
    onSuccess: updated => qc.setQueryData(['adminOrders', ordersPage], (old: typeof ordersData) =>
      old ? { ...old, items: old.items.map((o: Order) => o.id === updated.id ? updated : o) } : old
    ),
  });

  const toggleUserMutation = useMutation({
    mutationFn: (u: AdminUser) => toggleUserStatus(u.id),
    onSuccess: (updated, u) => {
      qc.setQueryData(['adminUsers', usersPage], (old: typeof usersData) =>
        old ? { ...old, items: old.items.map((usr: AdminUser) => usr.id === updated.id ? { ...usr, isActive: updated.isActive } : usr) } : old
      );
      toast(updated.isActive ? t('admin.userActivated', { name: u.name }) : t('admin.userDeactivated', { name: u.name }), updated.isActive ? 'success' : 'info');
    },
  });

  const deleteUserMutation = useMutation({
    mutationFn: (u: AdminUser) => deleteUser(u.id),
    onSuccess: (_, u) => {
      qc.setQueryData(['adminUsers', usersPage], (old: typeof usersData) =>
        old ? { ...old, items: old.items.filter((usr: AdminUser) => usr.id !== u.id), totalCount: old.totalCount - 1 } : old
      );
      toast(t('admin.userDeleted', { name: u.name }), 'error');
    },
    onError: () => toast(t('admin.modal.error'), 'error'),
  });

  // — Helpers —
  const TAGS_OPTIONS = [
    { key: 'vegan', label: t('card.tags.vegan') },
    { key: 'spicy', label: t('card.tags.spicy') },
    { key: 'halal', label: t('card.tags.halal') },
    { key: 'gluten-free', label: t('card.tags.gluten-free') },
    { key: 'popular', label: t('card.tags.popular') },
  ];

  const openAdd = () => {
    setEditingItem(null);
    setForm({ ...EMPTY_FORM, restaurantId: activeRestaurantId });
    setFormTags([]);
    setCustomCategory('');
    setFormError('');
    setModalOpen(true);
  };

  const openEdit = (item: MenuItem) => {
    setEditingItem(item);
    setForm({ name: item.name, description: item.description, price: String(item.price), category: item.category, imageUrl: item.imageUrl, isAvailable: item.isAvailable, restaurantId: item.restaurantId });
    setFormTags(item.tags ? item.tags.split(',').filter(Boolean) : []);
    setCustomCategory('');
    setFormError('');
    setModalOpen(true);
  };

  const closeModal = () => { setModalOpen(false); setEditingItem(null); setFormError(''); };
  const toggleTag = (key: string) => setFormTags(prev => prev.includes(key) ? prev.filter(tg => tg !== key) : [...prev, key]);
  const effectiveCategory = form.category === '__new__' ? customCategory : form.category;

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    setFormError('');
    if (!effectiveCategory) { setFormError(t('admin.modal.categoryRequired')); return; }
    const tags = formTags.join(',');
    const payload = { name: form.name, description: form.description, price: parseFloat(form.price), category: effectiveCategory, imageUrl: form.imageUrl, isAvailable: form.isAvailable, restaurantId: form.restaurantId, tags };
    if (editingItem) {
      updateMutation.mutate({ id: editingItem.id, item: { ...editingItem, ...payload } });
    } else {
      createMutation.mutate(payload as Omit<MenuItem, 'id'>);
    }
  };

  const filtered = filterCat ? items.filter(i => i.category === filterCat) : items;
  const availableCount = items.filter(i => i.isAvailable).length;
  const isSaving = createMutation.isPending || updateMutation.isPending;

  return (
    <main className="container admin-v2">
      <div className="admin-v2-header">
        <div>
          <h1 className="page-title" style={{ marginBottom: '0.25rem' }}>{t('admin.title')}</h1>
          <p className="admin-v2-stats">
            {items.length} {t('admin.dishes')} &nbsp;·&nbsp; {categories.length} {t('admin.categories')} &nbsp;·&nbsp;
            <span style={{ color: '#4ade80' }}>{availableCount} {t('admin.available')}</span>
            {items.length - availableCount > 0 && <>&nbsp;·&nbsp;<span style={{ color: '#facc15' }}>{items.length - availableCount} {t('admin.hidden')}</span></>}
          </p>
        </div>
        {activeTab === 'items' && (
          <button className="btn-primary" onClick={openAdd}>{t('admin.newDish')}</button>
        )}
      </div>

      <div className="admin-main-tabs">
        {(['items', 'orders', 'users', 'stats'] as Tab[]).map(tab => (
          <button key={tab} className={`admin-main-tab${activeTab === tab ? ' active' : ''}`} onClick={() => setActiveTab(tab)}>
            {t(`admin.tabs.${tab}`)}
          </button>
        ))}
      </div>

      {activeTab === 'items' && (
        <>
          <div className="admin-restaurant-tabs">
            {restaurants.map(r => (
              <button
                key={r.id}
                className={`admin-restaurant-tab${activeRestaurantId === r.id ? ' active' : ''}`}
                style={activeRestaurantId === r.id ? { borderColor: r.accentColor, color: r.accentColor } : {}}
                onClick={() => { setActiveRestaurantId(r.id); setFilterCat(''); }}
              >
                {r.name}
              </button>
            ))}
          </div>
          <div className="category-bar">
            <button className={`category-btn${!filterCat ? ' active' : ''}`} onClick={() => setFilterCat('')}>{t('admin.allCategories')}</button>
            {categories.map(c => (
              <button key={c} className={`category-btn${filterCat === c ? ' active' : ''}`} onClick={() => setFilterCat(c)}>{tCat(c)}</button>
            ))}
          </div>
          <div className="admin-v2-list">
            {filtered.length === 0 && <p style={{ color: 'var(--text-muted)', textAlign: 'center', padding: '2rem' }}>{t('admin.noDishes')}</p>}
            {filtered.map(item => (
              <div key={item.id} className={`admin-v2-card${!item.isAvailable ? ' unavailable' : ''}`}>
                <div className="admin-v2-thumb">
                  {item.imageUrl ? <img src={item.imageUrl} alt={item.name} /> : <span>🍽️</span>}
                </div>
                <div className="admin-v2-info">
                  <div className="admin-v2-name">{item.name}</div>
                  <div className="admin-v2-desc">{item.description}</div>
                  <span className="admin-v2-cat">{item.category}</span>
                </div>
                <div className="admin-v2-price">{item.price.toFixed(2)} $</div>
                <div className="admin-v2-actions">
                  <button className={`admin-toggle${item.isAvailable ? ' on' : ' off'}`} onClick={() => toggleMutation.mutate({ id: item.id, item })}>
                    {item.isAvailable ? t('admin.availableToggle') : t('admin.hiddenToggle')}
                  </button>
                  <button className="btn-icon btn-edit-icon" onClick={() => openEdit(item)}>✏️</button>
                  <button className="btn-icon btn-del-icon" onClick={() => { if (window.confirm(t('admin.modal.deleteConfirm', { name: item.name }))) deleteMutation.mutate(item.id); }}>🗑️</button>
                </div>
              </div>
            ))}
          </div>
        </>
      )}

      {activeTab === 'orders' && (
        <div className="admin-orders-list">
          {!ordersData && <p className="loading-text">{t('admin.loading')}</p>}
          {ordersData && orders.length === 0 && <p className="loading-text">{t('admin.noOrders')}</p>}
          {orders.map(order => {
            const color = STATUS_COLORS[order.status] ?? '#94a3b8';
            return (
              <div key={order.id} className="admin-order-card">
                <div className="admin-order-top">
                  <div>
                    <span className="admin-order-id">
                      {t('common.orderNumber', { id: order.id })}
                      <span className="order-type-badge" style={{ marginLeft: '0.5rem' }}>
                        {order.orderType === 'Delivery' ? t('orders.delivery') : t('orders.pickup')}
                      </span>
                    </span>
                    <div className="admin-order-customer">{order.customerName} · {order.customerEmail}</div>
                    {order.orderType === 'Delivery' && order.deliveryAddress && (
                      <div style={{ fontSize: '0.78rem', color: 'var(--text-muted)', marginTop: '0.15rem' }}>
                        📍 {order.deliveryAddress}
                        {order.deliveryNote && <span> · 💬 {order.deliveryNote}</span>}
                      </div>
                    )}
                  </div>
                  <div className="admin-order-right">
                    <span className="order-status-badge" style={{ background: `${color}22`, color, borderColor: `${color}44` }}>
                      {t(`status.${order.status}`) || order.status}
                    </span>
                    <select
                      className="admin-order-status-select"
                      value={order.status}
                      onChange={e => statusMutation.mutate({ id: order.id, status: e.target.value })}
                    >
                      {ALL_STATUSES.map(s => <option key={s} value={s}>{t(`status.${s}`) || s}</option>)}
                    </select>
                  </div>
                </div>
                <div className="admin-order-items">
                  {order.items.map(i => `${i.menuItemName} ×${i.quantity}`).join(' · ')}
                </div>
                <div className="admin-order-footer">
                  <span className="admin-order-total">{t('orders.total')}: {order.total.toFixed(2)} ${order.paidWithPoints ? ` ${t('common.paidPoints')}` : ''}</span>
                  <span style={{ fontSize: '0.75rem', color: 'var(--text-muted)' }}>
                    {new Date(order.createdAt).toLocaleDateString(t('common.locale'), { day: 'numeric', month: 'short', hour: '2-digit', minute: '2-digit' })}
                  </span>
                </div>
              </div>
            );
          })}
          {(ordersData?.totalPages ?? 1) > 1 && (
            <div style={{ display: 'flex', justifyContent: 'center', gap: '0.5rem', marginTop: '1rem' }}>
              <button className="btn-secondary" onClick={() => setOrdersPage(p => p - 1)} disabled={!ordersData?.hasPrev}>←</button>
              <span style={{ padding: '8px 12px', color: 'var(--text-muted)' }}>{ordersPage} / {ordersData?.totalPages}</span>
              <button className="btn-secondary" onClick={() => setOrdersPage(p => p + 1)} disabled={!ordersData?.hasNext}>→</button>
            </div>
          )}
        </div>
      )}

      {activeTab === 'users' && (
        <div className="admin-users-list">
          {!usersData && <p className="loading-text">{t('admin.loading')}</p>}
          {usersData && users.length === 0 && <p className="loading-text">{t('admin.noUsers')}</p>}
          {users.map(u => {
            const tier = getTier(u.totalPointsEarned);
            return (
              <div key={u.id} className={`admin-user-card${!u.isActive ? ' inactive' : ''}`}>
                <div className="admin-user-avatar">{u.name.charAt(0).toUpperCase()}</div>
                <div className="admin-user-info">
                  <div className="admin-user-name">
                    {u.name}
                    {u.role === 'Admin' && <span className="admin-user-badge admin">{t('admin.badgeAdmin')}</span>}
                    {!u.isActive && <span className="admin-user-badge disabled">{t('admin.badgeDisabled')}</span>}
                  </div>
                  <div className="admin-user-email">{u.email}</div>
                  <div className="admin-user-meta">
                    <span style={{ color: tier.color }}>{tier.icon} {tier.label}</span>
                    <span>⭐ {u.points.toLocaleString()} pts</span>
                    <span style={{ color: 'var(--text-faint)' }}>
                      {t('admin.registeredOn')} {new Date(u.createdAt).toLocaleDateString(t('common.locale'), { day: 'numeric', month: 'short', year: 'numeric' })}
                    </span>
                  </div>
                </div>
                <div className="admin-user-actions">
                  <button className={`admin-toggle${u.isActive ? ' on' : ' off'}`} onClick={() => toggleUserMutation.mutate(u)}>
                    {u.isActive ? t('admin.userActive') : t('admin.userInactive')}
                  </button>
                  <button className="btn-icon btn-del-icon" onClick={() => { if (window.confirm(t('admin.deleteUserConfirm', { name: u.name }))) deleteUserMutation.mutate(u); }}>🗑️</button>
                </div>
              </div>
            );
          })}
          {(usersData?.totalPages ?? 1) > 1 && (
            <div style={{ display: 'flex', justifyContent: 'center', gap: '0.5rem', marginTop: '1rem' }}>
              <button className="btn-secondary" onClick={() => setUsersPage(p => p - 1)} disabled={!usersData?.hasPrev}>←</button>
              <span style={{ padding: '8px 12px', color: 'var(--text-muted)' }}>{usersPage} / {usersData?.totalPages}</span>
              <button className="btn-secondary" onClick={() => setUsersPage(p => p + 1)} disabled={!usersData?.hasNext}>→</button>
            </div>
          )}
        </div>
      )}

      {activeTab === 'stats' && (
        <>
          {!stats && <p className="loading-text">{t('admin.loading')}</p>}
          {stats && (
            <div className="admin-stats-grid">
              {([
                ['admin.stats.todayOrders', stats.todayOrderCount],
                ['admin.stats.todayRevenue', `${stats.todayRevenue.toFixed(2)} $`],
                ['admin.stats.totalOrders', stats.totalOrderCount],
                ['admin.stats.totalRevenue', `${stats.totalRevenue.toFixed(2)} $`],
                ['admin.stats.pending', stats.pendingCount],
                ['admin.stats.clients', stats.totalUsers],
              ] as [string, AdminStats[keyof AdminStats]][]).map(([key, value]) => (
                <div key={key} className="admin-stat-card">
                  <span className="admin-stat-label">{t(key)}</span>
                  <span className="admin-stat-value">{value}</span>
                </div>
              ))}
              <div className="admin-stat-card" style={{ gridColumn: '1 / -1' }}>
                <span className="admin-stat-label">{t('admin.stats.topItem')}</span>
                <span className="admin-stat-value" style={{ fontSize: '1.1rem' }}>{stats.topItem}</span>
              </div>
            </div>
          )}
        </>
      )}

      {modalOpen && (
        <div className="modal-overlay" onClick={closeModal}>
          <div className="modal" onClick={e => e.stopPropagation()}>
            <div className="modal-header">
              <h2>{editingItem ? t('admin.modal.editDish', { name: editingItem.name }) : t('admin.modal.newDish')}</h2>
              <button className="modal-close" onClick={closeModal}>✕</button>
            </div>
            <form className="modal-form" onSubmit={handleSubmit}>
              <div className="modal-grid">
                <div className="modal-col">
                  <label>{t('admin.modal.name')}</label>
                  <input type="text" placeholder={t('admin.modal.namePlaceholder')} required value={form.name} onChange={e => setForm(f => ({ ...f, name: e.target.value }))} />

                  <label>{t('admin.modal.description')}</label>
                  <textarea placeholder={t('admin.modal.descPlaceholder')} required rows={3} value={form.description} onChange={e => setForm(f => ({ ...f, description: e.target.value }))} />

                  <div className="modal-row">
                    <div style={{ flex: 1, display: 'flex', flexDirection: 'column', gap: '0.4rem' }}>
                      <label>{t('admin.modal.price')}</label>
                      <input type="number" placeholder="12.99" required min="0" step="0.01" value={form.price} onChange={e => setForm(f => ({ ...f, price: e.target.value }))} />
                    </div>
                    <div style={{ flex: 1, display: 'flex', flexDirection: 'column', gap: '0.4rem' }}>
                      <label>{t('admin.modal.category')}</label>
                      <select value={form.category} onChange={e => setForm(f => ({ ...f, category: e.target.value }))} required>
                        <option value="">{t('admin.modal.categoryPlaceholder')}</option>
                        {categories.map(c => <option key={c} value={c}>{c}</option>)}
                        <option value="__new__">{t('admin.modal.newCategory')}</option>
                      </select>
                    </div>
                  </div>

                  {form.category === '__new__' && (
                    <input type="text" placeholder={t('admin.modal.categoryNamePlaceholder')} required value={customCategory} onChange={e => setCustomCategory(e.target.value)} />
                  )}

                  <label>{t('admin.modal.tags')}</label>
                  <div className="tags-checkboxes">
                    {TAGS_OPTIONS.map(tag => (
                      <label key={tag.key} className={`tag-checkbox-label${formTags.includes(tag.key) ? ' checked' : ''}`}>
                        <input type="checkbox" checked={formTags.includes(tag.key)} onChange={() => toggleTag(tag.key)} />
                        {tag.label}
                      </label>
                    ))}
                  </div>

                  <label className="admin-checkbox" style={{ marginTop: '0.25rem' }}>
                    <input type="checkbox" checked={form.isAvailable} onChange={e => setForm(f => ({ ...f, isAvailable: e.target.checked }))} />
                    {t('admin.modal.availableCheck')}
                  </label>
                </div>
                <div className="modal-col">
                  <label>{t('admin.modal.image')}</label>
                  <ImagePicker value={form.imageUrl} onChange={url => setForm(f => ({ ...f, imageUrl: url }))} />
                </div>
              </div>
              {formError && <p className="error">{formError}</p>}
              <div className="modal-footer">
                <button type="button" className="btn-secondary" onClick={closeModal}>{t('admin.modal.cancel')}</button>
                <button type="submit" className="btn-primary" disabled={isSaving}>
                  {isSaving ? t('admin.modal.saving') : editingItem ? t('admin.modal.save') : t('admin.modal.add')}
                </button>
              </div>
            </form>
          </div>
        </div>
      )}
    </main>
  );
}
