import { View, Text, FlatList, StyleSheet, ActivityIndicator } from 'react-native';
import { useQuery } from '@tanstack/react-query';
import { useAuth } from '../../src/context/AuthContext';
import { getMyOrders } from '../../src/api/orders';
import { Order } from '../../src/types';

const STATUS_COLORS: Record<string, string> = {
  Pending: '#f59e0b', Confirmed: '#6366f1', Preparing: '#3b82f6',
  Ready: '#4ade80', Delivered: '#22c55e', Cancelled: '#f87171',
};
const STATUS_LABELS: Record<string, string> = {
  Pending: 'En attente', Confirmed: 'Confirmée', Preparing: 'En préparation',
  Ready: 'Prête', Delivered: 'Livrée', Cancelled: 'Annulée',
};

export default function OrdersScreen() {
  const { user } = useAuth();
  const { data: orders = [], isLoading } = useQuery({
    queryKey: ['myOrders'],
    queryFn: getMyOrders,
    enabled: !!user,
  });

  if (!user) {
    return <View style={styles.center}><Text style={styles.empty}>Connectez-vous pour voir vos commandes.</Text></View>;
  }

  if (isLoading) {
    return <View style={styles.center}><ActivityIndicator color="#FF416C" size="large" /></View>;
  }

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Mes commandes</Text>
      {orders.length === 0 ? (
        <View style={styles.center}><Text style={styles.empty}>Aucune commande.</Text></View>
      ) : (
        <FlatList
          data={orders}
          keyExtractor={o => String(o.id)}
          contentContainerStyle={styles.list}
          renderItem={({ item }) => <OrderCard order={item} />}
        />
      )}
    </View>
  );
}

function OrderCard({ order }: { order: Order }) {
  const color = STATUS_COLORS[order.status] ?? '#94a3b8';
  return (
    <View style={styles.card}>
      <View style={styles.cardTop}>
        <Text style={styles.orderId}>Commande #{order.id}</Text>
        <View style={[styles.badge, { backgroundColor: `${color}22`, borderColor: `${color}44` }]}>
          <Text style={[styles.badgeText, { color }]}>{STATUS_LABELS[order.status] ?? order.status}</Text>
        </View>
      </View>
      <Text style={styles.items}>{order.items.map(i => `${i.menuItemName} ×${i.quantity}`).join(' · ')}</Text>
      <View style={styles.cardBottom}>
        <Text style={styles.total}>Total: {order.total.toFixed(2)} $</Text>
        <Text style={styles.date}>{new Date(order.createdAt).toLocaleDateString('fr-CA', { day: 'numeric', month: 'short' })}</Text>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: '#0f0f0f' },
  center: { flex: 1, justifyContent: 'center', alignItems: 'center', backgroundColor: '#0f0f0f' },
  title: { fontSize: 26, fontWeight: '800', color: '#fff', paddingTop: 60, paddingHorizontal: 20, paddingBottom: 12 },
  list: { padding: 16, gap: 12 },
  empty: { color: '#666', fontSize: 16 },
  card: { backgroundColor: '#1a1a1a', borderRadius: 14, padding: 16, borderWidth: 1, borderColor: '#2a2a2a' },
  cardTop: { flexDirection: 'row', justifyContent: 'space-between', alignItems: 'center', marginBottom: 8 },
  orderId: { color: '#fff', fontWeight: '700', fontSize: 15 },
  badge: { borderRadius: 8, paddingHorizontal: 10, paddingVertical: 4, borderWidth: 1 },
  badgeText: { fontSize: 12, fontWeight: '600' },
  items: { color: '#aaa', fontSize: 13, marginBottom: 10 },
  cardBottom: { flexDirection: 'row', justifyContent: 'space-between' },
  total: { color: '#fff', fontWeight: '700' },
  date: { color: '#666', fontSize: 12 },
});
