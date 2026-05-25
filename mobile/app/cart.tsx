import { useState } from 'react';
import { View, Text, FlatList, TouchableOpacity, StyleSheet, TextInput, ActivityIndicator, ScrollView } from 'react-native';
import { router } from 'expo-router';
import { useMutation, useQueryClient } from '@tanstack/react-query';
import { useCart } from '../src/context/CartContext';
import { useAuth } from '../src/context/AuthContext';
import { createOrder } from '../src/api/orders';
import { CartItem } from '../src/types';

export default function CartScreen() {
  const { items, total, count, add, remove, clear, restaurantId } = useCart();
  const { user } = useAuth();
  const qc = useQueryClient();
  const [orderType, setOrderType] = useState<'Pickup' | 'Delivery'>('Pickup');
  const [address, setAddress] = useState('');
  const [error, setError] = useState('');

  const mutation = useMutation({
    mutationFn: createOrder,
    onSuccess: (order) => {
      clear();
      qc.invalidateQueries({ queryKey: ['myOrders'] });
      router.replace({ pathname: '/confirmation', params: { orderId: order.id } });
    },
    onError: (err: any) => {
      const msg = err?.response?.data;
      if (msg === 'errors.order.deliveryAddressRequired') setError('Adresse de livraison requise.');
      else setError('Erreur lors de la commande.');
    },
  });

  const handleOrder = () => {
    if (!user) { router.push('/login'); return; }
    if (orderType === 'Delivery' && !address.trim()) { setError("L'adresse de livraison est requise."); return; }
    setError('');
    mutation.mutate({
      restaurantId: restaurantId!,
      orderType,
      deliveryAddress: orderType === 'Delivery' ? address : undefined,
      paidWithPoints: false,
      items: items.map(c => ({ menuItemId: c.item.id, quantity: c.quantity })),
    });
  };

  if (count === 0) {
    return (
      <View style={styles.empty}>
        <Text style={styles.emptyEmoji}>🛒</Text>
        <Text style={styles.emptyText}>Votre panier est vide</Text>
        <TouchableOpacity style={styles.backBtn} onPress={() => router.back()}>
          <Text style={styles.backBtnText}>Voir le menu</Text>
        </TouchableOpacity>
      </View>
    );
  }

  return (
    <View style={styles.container}>
      <View style={styles.header}>
        <TouchableOpacity onPress={() => router.back()}><Text style={styles.back}>←</Text></TouchableOpacity>
        <Text style={styles.title}>Panier</Text>
      </View>

      <ScrollView contentContainerStyle={styles.scroll}>
        {items.map(c => <CartRow key={c.item.id} cartItem={c} onAdd={() => add(c.item)} onRemove={() => remove(c.item.id)} />)}

        <View style={styles.section}>
          <Text style={styles.sectionTitle}>Type de commande</Text>
          <View style={styles.typeRow}>
            {(['Pickup', 'Delivery'] as const).map(t => (
              <TouchableOpacity key={t} style={[styles.typeBtn, orderType === t && styles.typeBtnActive]} onPress={() => setOrderType(t)}>
                <Text style={[styles.typeBtnText, orderType === t && styles.typeBtnTextActive]}>
                  {t === 'Pickup' ? '🏃 À emporter' : '🛵 Livraison'}
                </Text>
              </TouchableOpacity>
            ))}
          </View>

          {orderType === 'Delivery' && (
            <TextInput style={styles.input} placeholder="Adresse de livraison *" placeholderTextColor="#666" value={address} onChangeText={setAddress} />
          )}
        </View>

        <View style={styles.totalRow}>
          <Text style={styles.totalLabel}>Total</Text>
          <Text style={styles.totalValue}>{total.toFixed(2)} $</Text>
        </View>

        {error ? <Text style={styles.error}>{error}</Text> : null}

        <TouchableOpacity style={styles.orderBtn} onPress={handleOrder} disabled={mutation.isPending}>
          {mutation.isPending ? <ActivityIndicator color="#fff" /> : <Text style={styles.orderBtnText}>Commander</Text>}
        </TouchableOpacity>
      </ScrollView>
    </View>
  );
}

function CartRow({ cartItem, onAdd, onRemove }: { cartItem: CartItem; onAdd: () => void; onRemove: () => void }) {
  return (
    <View style={styles.row}>
      <View style={styles.rowInfo}>
        <Text style={styles.rowName}>{cartItem.item.name}</Text>
        <Text style={styles.rowPrice}>{(cartItem.item.price * cartItem.quantity).toFixed(2)} $</Text>
      </View>
      <View style={styles.rowQty}>
        <TouchableOpacity style={styles.qtyBtn} onPress={onRemove}><Text style={styles.qtyBtnText}>−</Text></TouchableOpacity>
        <Text style={styles.qtyNum}>{cartItem.quantity}</Text>
        <TouchableOpacity style={styles.qtyBtn} onPress={onAdd}><Text style={styles.qtyBtnText}>+</Text></TouchableOpacity>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: '#0f0f0f' },
  empty: { flex: 1, backgroundColor: '#0f0f0f', justifyContent: 'center', alignItems: 'center', gap: 16 },
  emptyEmoji: { fontSize: 48 },
  emptyText: { color: '#888', fontSize: 18 },
  backBtn: { backgroundColor: '#FF416C', borderRadius: 12, paddingHorizontal: 20, paddingVertical: 10 },
  backBtnText: { color: '#fff', fontWeight: '700' },
  header: { flexDirection: 'row', alignItems: 'center', paddingTop: 56, paddingHorizontal: 20, paddingBottom: 12, gap: 12 },
  back: { color: '#fff', fontSize: 22 },
  title: { color: '#fff', fontSize: 22, fontWeight: '800' },
  scroll: { padding: 16, gap: 12 },
  row: { backgroundColor: '#1a1a1a', borderRadius: 12, padding: 14, flexDirection: 'row', justifyContent: 'space-between', alignItems: 'center', borderWidth: 1, borderColor: '#2a2a2a' },
  rowInfo: { flex: 1 },
  rowName: { color: '#fff', fontWeight: '600' },
  rowPrice: { color: '#aaa', fontSize: 13, marginTop: 2 },
  rowQty: { flexDirection: 'row', alignItems: 'center', gap: 10 },
  qtyBtn: { backgroundColor: '#2a2a2a', borderRadius: 8, width: 32, height: 32, justifyContent: 'center', alignItems: 'center' },
  qtyBtnText: { color: '#fff', fontSize: 18, fontWeight: '700' },
  qtyNum: { color: '#fff', fontWeight: '700', fontSize: 16, minWidth: 20, textAlign: 'center' },
  section: { gap: 10 },
  sectionTitle: { color: '#fff', fontWeight: '700', fontSize: 16 },
  typeRow: { flexDirection: 'row', gap: 10 },
  typeBtn: { flex: 1, backgroundColor: '#1a1a1a', borderRadius: 10, padding: 12, alignItems: 'center', borderWidth: 1, borderColor: '#2a2a2a' },
  typeBtnActive: { backgroundColor: '#FF416C', borderColor: '#FF416C' },
  typeBtnText: { color: '#888', fontWeight: '600' },
  typeBtnTextActive: { color: '#fff' },
  input: { backgroundColor: '#1a1a1a', color: '#fff', borderRadius: 12, padding: 14, borderWidth: 1, borderColor: '#2a2a2a', fontSize: 15 },
  totalRow: { flexDirection: 'row', justifyContent: 'space-between', paddingVertical: 12, borderTopWidth: 1, borderTopColor: '#2a2a2a' },
  totalLabel: { color: '#aaa', fontSize: 16 },
  totalValue: { color: '#fff', fontSize: 20, fontWeight: '800' },
  error: { color: '#f87171', textAlign: 'center' },
  orderBtn: { backgroundColor: '#FF416C', borderRadius: 14, padding: 18, alignItems: 'center' },
  orderBtnText: { color: '#fff', fontWeight: '800', fontSize: 17 },
});
