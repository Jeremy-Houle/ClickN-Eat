import { View, Text, TouchableOpacity, StyleSheet } from 'react-native';
import { router, useLocalSearchParams } from 'expo-router';

export default function ConfirmationScreen() {
  const { orderId } = useLocalSearchParams<{ orderId: string }>();

  return (
    <View style={styles.container}>
      <Text style={styles.emoji}>✅</Text>
      <Text style={styles.title}>Commande confirmée !</Text>
      <Text style={styles.subtitle}>Commande #{orderId} reçue.</Text>
      <Text style={styles.hint}>Suivez votre commande dans l'onglet Commandes.</Text>

      <TouchableOpacity style={styles.btn} onPress={() => router.replace('/(tabs)')}>
        <Text style={styles.btnText}>Retour à l'accueil</Text>
      </TouchableOpacity>

      <TouchableOpacity style={styles.btnSecondary} onPress={() => router.replace('/(tabs)/orders')}>
        <Text style={styles.btnSecondaryText}>Voir mes commandes</Text>
      </TouchableOpacity>
    </View>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: '#0f0f0f', justifyContent: 'center', alignItems: 'center', padding: 32 },
  emoji: { fontSize: 64, marginBottom: 16 },
  title: { fontSize: 26, fontWeight: '800', color: '#fff', textAlign: 'center', marginBottom: 8 },
  subtitle: { fontSize: 16, color: '#aaa', textAlign: 'center', marginBottom: 8 },
  hint: { fontSize: 14, color: '#666', textAlign: 'center', marginBottom: 40 },
  btn: { backgroundColor: '#FF416C', borderRadius: 14, paddingHorizontal: 32, paddingVertical: 16, width: '100%', alignItems: 'center', marginBottom: 12 },
  btnText: { color: '#fff', fontWeight: '700', fontSize: 16 },
  btnSecondary: { backgroundColor: '#1a1a1a', borderRadius: 14, paddingHorizontal: 32, paddingVertical: 16, width: '100%', alignItems: 'center', borderWidth: 1, borderColor: '#2a2a2a' },
  btnSecondaryText: { color: '#aaa', fontWeight: '600', fontSize: 16 },
});
