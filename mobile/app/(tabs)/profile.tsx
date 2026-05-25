import { View, Text, TouchableOpacity, StyleSheet } from 'react-native';
import { router } from 'expo-router';
import { useAuth } from '../../src/context/AuthContext';
import { useQueryClient } from '@tanstack/react-query';

export default function ProfileScreen() {
  const { user, logout } = useAuth();
  const qc = useQueryClient();

  const handleLogout = async () => {
    await logout();
    qc.clear();
    router.replace('/login');
  };

  if (!user) {
    return (
      <View style={styles.container}>
        <Text style={styles.title}>Profil</Text>
        <TouchableOpacity style={styles.logoutBtn} onPress={() => router.push('/login')}>
          <Text style={styles.logoutText}>Se connecter</Text>
        </TouchableOpacity>
      </View>
    );
  }

  return (
    <View style={styles.container}>
      <Text style={styles.title}>Profil</Text>

      <View style={styles.avatar}>
        <Text style={styles.avatarText}>{user.name.charAt(0).toUpperCase()}</Text>
      </View>
      <Text style={styles.name}>{user.name}</Text>
      <Text style={styles.email}>{user.email}</Text>
      {user.role === 'Admin' && <Text style={styles.adminBadge}>Admin</Text>}

      <View style={styles.pointsCard}>
        <Text style={styles.pointsLabel}>Points de fidélité</Text>
        <Text style={styles.pointsValue}>{user.points.toLocaleString()} pts</Text>
        <Text style={styles.pointsHint}>1 $ = 100 pts · 100 pts = 1 $ de rabais</Text>
      </View>

      <TouchableOpacity style={styles.logoutBtn} onPress={handleLogout}>
        <Text style={styles.logoutText}>Se déconnecter</Text>
      </TouchableOpacity>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: '#0f0f0f', padding: 24, paddingTop: 60 },
  title: { fontSize: 26, fontWeight: '800', color: '#fff', marginBottom: 32 },
  avatar: { width: 80, height: 80, borderRadius: 40, backgroundColor: '#FF416C', justifyContent: 'center', alignItems: 'center', marginBottom: 16, alignSelf: 'center' },
  avatarText: { fontSize: 34, color: '#fff', fontWeight: '700' },
  name: { fontSize: 22, fontWeight: '700', color: '#fff', textAlign: 'center' },
  email: { fontSize: 14, color: '#888', textAlign: 'center', marginTop: 4, marginBottom: 8 },
  adminBadge: { alignSelf: 'center', backgroundColor: '#6366f133', color: '#6366f1', paddingHorizontal: 12, paddingVertical: 4, borderRadius: 8, fontSize: 12, fontWeight: '700', overflow: 'hidden' },
  pointsCard: { backgroundColor: '#1a1a1a', borderRadius: 16, padding: 20, marginTop: 24, borderWidth: 1, borderColor: '#2a2a2a' },
  pointsLabel: { color: '#888', fontSize: 13, marginBottom: 6 },
  pointsValue: { fontSize: 28, fontWeight: '800', color: '#FF416C' },
  pointsHint: { color: '#555', fontSize: 12, marginTop: 8 },
  logoutBtn: { marginTop: 32, backgroundColor: '#1a1a1a', borderRadius: 12, padding: 16, alignItems: 'center', borderWidth: 1, borderColor: '#f87171' },
  logoutText: { color: '#f87171', fontWeight: '700', fontSize: 16 },
});
