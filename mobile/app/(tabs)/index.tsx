import { View, Text, FlatList, TouchableOpacity, StyleSheet, ImageBackground, ActivityIndicator } from 'react-native';
import { useQuery } from '@tanstack/react-query';
import { router } from 'expo-router';
import { getRestaurants } from '../../src/api/restaurants';
import { Restaurant } from '../../src/types';
import { useCart } from '../../src/context/CartContext';

export default function RestaurantsScreen() {
  const { data: restaurants = [], isLoading } = useQuery({ queryKey: ['restaurants'], queryFn: getRestaurants });
  const { count } = useCart();

  if (isLoading) {
    return <View style={styles.center}><ActivityIndicator color="#FF416C" size="large" /></View>;
  }

  return (
    <View style={styles.container}>
      <View style={styles.header}>
        <Text style={styles.title}>ClickN'Eat</Text>
        <Text style={styles.subtitle}>Choisissez un restaurant</Text>
        {count > 0 && (
          <TouchableOpacity style={styles.cartBtn} onPress={() => router.push('/cart')}>
            <Text style={styles.cartBtnText}>🛒 Panier ({count})</Text>
          </TouchableOpacity>
        )}
      </View>

      <FlatList
        data={restaurants}
        keyExtractor={r => String(r.id)}
        contentContainerStyle={styles.list}
        renderItem={({ item }) => <RestaurantCard restaurant={item} />}
      />
    </View>
  );
}

function RestaurantCard({ restaurant }: { restaurant: Restaurant }) {
  const imageUri = restaurant.coverImageUrl?.startsWith('/images/')
    ? `http://192.168.1.100:5173${restaurant.coverImageUrl}`
    : restaurant.coverImageUrl;

  return (
    <TouchableOpacity style={styles.card} onPress={() => router.push({ pathname: '/restaurant/[id]', params: { id: restaurant.id } })}>
      <ImageBackground source={{ uri: imageUri }} style={styles.cardImage} imageStyle={{ borderRadius: 16 }}>
        <View style={[styles.cardOverlay, { borderColor: restaurant.accentColor }]}>
          <Text style={styles.cardName}>{restaurant.name}</Text>
          <Text style={styles.cardDesc}>{restaurant.description}</Text>
          <View style={[styles.cardBtn, { backgroundColor: restaurant.accentColor }]}>
            <Text style={styles.cardBtnText}>Voir le menu →</Text>
          </View>
        </View>
      </ImageBackground>
    </TouchableOpacity>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: '#0f0f0f' },
  center: { flex: 1, justifyContent: 'center', alignItems: 'center', backgroundColor: '#0f0f0f' },
  header: { paddingTop: 60, paddingHorizontal: 20, paddingBottom: 16 },
  title: { fontSize: 30, fontWeight: '800', color: '#FF416C' },
  subtitle: { fontSize: 16, color: '#888', marginTop: 4 },
  cartBtn: { marginTop: 12, backgroundColor: '#1a1a1a', borderRadius: 10, padding: 10, alignSelf: 'flex-start' },
  cartBtnText: { color: '#fff', fontWeight: '600' },
  list: { padding: 16, gap: 16 },
  card: { borderRadius: 16, overflow: 'hidden', height: 200 },
  cardImage: { flex: 1, justifyContent: 'flex-end' },
  cardOverlay: { backgroundColor: 'rgba(0,0,0,0.55)', padding: 16, borderRadius: 16, borderWidth: 1, borderColor: 'transparent' },
  cardName: { fontSize: 22, fontWeight: '800', color: '#fff' },
  cardDesc: { fontSize: 13, color: '#ccc', marginTop: 2, marginBottom: 10 },
  cardBtn: { alignSelf: 'flex-start', paddingHorizontal: 14, paddingVertical: 6, borderRadius: 8 },
  cardBtnText: { color: '#fff', fontWeight: '700', fontSize: 13 },
});
