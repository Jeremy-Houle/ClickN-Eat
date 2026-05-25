import { useState } from 'react';
import { View, Text, TextInput, TouchableOpacity, StyleSheet, ActivityIndicator, KeyboardAvoidingView, Platform } from 'react-native';
import { router } from 'expo-router';
import { useAuth } from '../src/context/AuthContext';
import { register as apiRegister } from '../src/api/auth';

export default function RegisterScreen() {
  const { login } = useAuth();
  const [name, setName] = useState('');
  const [email, setEmail] = useState('');
  const [password, setPassword] = useState('');
  const [error, setError] = useState('');
  const [loading, setLoading] = useState(false);

  const handleRegister = async () => {
    setError('');
    if (password.length < 8) { setError('Minimum 8 caractères.'); return; }
    setLoading(true);
    try {
      const data = await apiRegister(name, email, password);
      await login(data.token, data.user);
      router.replace('/(tabs)');
    } catch (err: any) {
      const msg = err?.response?.data;
      if (msg === 'errors.auth.emailTaken') setError('Cet email est déjà utilisé.');
      else setError('Erreur lors de la création du compte.');
    } finally {
      setLoading(false);
    }
  };

  return (
    <KeyboardAvoidingView behavior={Platform.OS === 'ios' ? 'padding' : undefined} style={styles.container}>
      <View style={styles.inner}>
        <Text style={styles.logo}>ClickN'Eat</Text>
        <Text style={styles.title}>Créer un compte</Text>

        <TextInput style={styles.input} placeholder="Nom complet" placeholderTextColor="#666" value={name} onChangeText={setName} />
        <TextInput style={styles.input} placeholder="Courriel" placeholderTextColor="#666" value={email} onChangeText={setEmail} autoCapitalize="none" keyboardType="email-address" />
        <TextInput style={styles.input} placeholder="Mot de passe (min. 8 car.)" placeholderTextColor="#666" value={password} onChangeText={setPassword} secureTextEntry />

        {error ? <Text style={styles.error}>{error}</Text> : null}

        <TouchableOpacity style={styles.btn} onPress={handleRegister} disabled={loading}>
          {loading ? <ActivityIndicator color="#fff" /> : <Text style={styles.btnText}>Créer mon compte</Text>}
        </TouchableOpacity>

        <TouchableOpacity onPress={() => router.back()}>
          <Text style={styles.link}>Déjà un compte ? <Text style={styles.linkBold}>Se connecter</Text></Text>
        </TouchableOpacity>
      </View>
    </KeyboardAvoidingView>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1, backgroundColor: '#0f0f0f' },
  inner: { flex: 1, justifyContent: 'center', padding: 28 },
  logo: { fontSize: 32, fontWeight: '800', color: '#FF416C', textAlign: 'center', marginBottom: 8 },
  title: { fontSize: 22, fontWeight: '700', color: '#fff', textAlign: 'center', marginBottom: 32 },
  input: { backgroundColor: '#1a1a1a', color: '#fff', borderRadius: 12, padding: 16, marginBottom: 12, fontSize: 16, borderWidth: 1, borderColor: '#2a2a2a' },
  error: { color: '#f87171', marginBottom: 12, textAlign: 'center' },
  btn: { backgroundColor: '#FF416C', borderRadius: 12, padding: 16, alignItems: 'center', marginBottom: 16 },
  btnText: { color: '#fff', fontWeight: '700', fontSize: 16 },
  link: { color: '#888', textAlign: 'center', fontSize: 14 },
  linkBold: { color: '#FF416C', fontWeight: '700' },
});
