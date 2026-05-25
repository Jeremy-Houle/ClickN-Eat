import { useState } from 'react';
import { View, Text, FlatList, TouchableOpacity, StyleSheet, Image, ScrollView, ActivityIndicator } from 'react-native';
import { useLocalSearchParams, router } from 'expo-router';
import { useQuery } from '@tanstack/react-query';
import { getMenuItems, getCategories } from '../../src/api/menu';
import { getRestaurants } from '../../src/api/restaurants';
import { MenuItem } from '../../src/types';
import { useCart } from '../../src/context/CartContext';

const BASE = 'http://192.168.1.100:5173';

export default function RestaurantScreen() {
  const { id } = useLocalSearchParams<{ id: string }>();
  const restaurantId = Number(id);
  const [activeCategory, setActiveCategory] = useState('');
  const { add, count } = useCart();

  const { data: restaurants = [] } = useQuery({ queryKey: ['restaurants'], queryFn: getRestaurants });
  const restaurant = restaurants.find(r => r.id === restaurantId);

  const { data: items = [], isLoading } = useQuery({
    queryKey: ['menu', restaurantId],
    queryFn: () => getMenuItems(restaurantId),
    enabled: !!restaurantId,
  });

  const { data: categories = [] } = useQuery({
    queryKey: ['categories', restaurantId],
    queryFn: () => getCategories(restaurantId),
    enabled: !!restaurantId,
  });

  const filtered = activeCategory ? items.filter(i => i.category === activeCategory) : items.filter(i => i.isAvailable);

  return (
    <View style={styles.container}>
      <View style={[styles.header, { borderBottomColor: restaurant?.accentColor ?? '#333' }]}>
        <TouchableOpacity onPress={() => router.back()} style={styles.backBtn}>
          <Text style={styles.backText}>←</Text>
        </TouchableOpacity>
        <Text style={styles.headerName}>{restaurant?.name ?? '...'}</Text>
        {count > 0 && (
          <TouchableOpacity style={[styles.cartBtn, { backgroundColor: restaurant?.accentColor ?? '#FF416C' }]} onPress={() => router.push('/cart')}>
            <Text style={styles.cartBtnText}>🛒 {count}</Text>
          </TouchableOpacity>
        )}
      </View>

      <ScrollView horizontal showsHorizontalScrollIndicator={false} style={styles.categories} contentContainerStyle={styles.categoriesContent}>
        <TouchableOpacity style={[styles.catBtn, !activeCategory && { backgroundColor: restaurant?.accentColor ?? '#FF416C' }]} onPress={() => setActiveCategory('')}>
          <Text style={styles.catText}>Tous</Text>
        </TouchableOpacity>
        {categories.map(c => (
          <TouchableOpacity key={c} style={[styles.catBtn, activeCategory === c && { backgroundColor: restaurant?.accentColor ?? '#FF416C' }]} onPress={() => setActiveCategory(c)}>
            <Text style={styles.catText}>{c}</Text>
          </TouchableOpacity>
        ))}
      </ScrollView>

      {isLoading ? (
        <View style={styles.center}><ActivityIndicator color="#FF416C" /></View>
      ) : (
        <FlatList
          data={filtered}
          keyExtractor={i => String(i.id)}
          contentContainerStyle={styles.list}
          renderItem={({ item }) => <MenuCard item={item} accentColor={restaurant?.accentColor} onAdd={() => add(item)} />}
        />
      )}
    </View>
  );
}

function MenuCard({ item, accentColor, onAdd }: { item: MenuItem; accentColor?: string; onAdd: () => void }) {
  const imageUri = item.imageUrl?.startsWith('/images/') ? `${BASE}${item.imageUrl}` : item.imageUrl;
  return (
    <View style={styles.card}>
      <Image source={{ uri: imageUri }} style={styles.cardImg} />
      <View style={styles.cardInfo}>
        <Text style={styles.cardName}>{item.name}</Text>
        <Text style={styles.cardDesc} numberOfLines={2}>{item.description}</Text>
        <View style={styles.cardBottom}>
          <Text style={styles.cardPrice}>{item.price.toFixed(2)} $</Text>
          <TouchableOpacity style={[styles.addBtn, { backgroundColor: accentColor ?? '#FF416C' }]} onPress={onAdd}>
            <Text style={styles.addBtnText}>+ Ajouter</Text>
          </TouchableOpacity>
        </View>
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: '#0f0f0f' },
  center: { flex: 1, justifyContent: 'center', alignItems: 'center' },
  header: { flexDirection: 'row', alignItems: 'center', paddingTop: 56, paddingBottom: 12, paddingHorizontal: 16, borderBottomWidth: 1 },
  backBtn: { marginRight: 12 },
  backText: { color: '#fff', fontSize: 22 },
  headerName: { flex: 1, color: '#fff', fontSize: 20, fontWeight: '700' },
  cartBtn: { borderRadius: 10, paddingHorizontal: 12, paddingVertical: 6 },
  cartBtnText: { color: '#fff', fontWeight: '700' },
  categories: { maxHeight: 52 },
  categoriesContent: { paddingHorizontal: 16, paddingVertical: 10, gap: 8 },
  catBtn: { backgroundColor: '#1a1a1a', borderRadius: 20, paddingHorizontal: 14, paddingVertical: 6, borderWidth: 1, borderColor: '#2a2a2a' },
  catText: { color: '#fff', fontSize: 13, fontWeight: '600' },
  list: { padding: 16, gap: 12 },
  card: { backgroundColor: '#1a1a1a', borderRadius: 14, flexDirection: 'row', overflow: 'hidden', borderWidth: 1, borderColor: '#2a2a2a' },
  cardImg: { width: 100, height: 100 },
  cardInfo: { flex: 1, padding: 12, justifyContent: 'space-between' },
  cardName: { color: '#fff', fontWeight: '700', fontSize: 15 },
  cardDesc: { color: '#888', fontSize: 12, marginTop: 4 },
  cardBottom: { flexDirection: 'row', justifyContent: 'space-between', alignItems: 'center', marginTop: 8 },
  cardPrice: { color: '#fff', fontWeight: '700', fontSize: 16 },
  addBtn: { borderRadius: 8, paddingHorizontal: 12, paddingVertical: 6 },
  addBtnText: { color: '#fff', fontWeight: '700', fontSize: 13 },
});
