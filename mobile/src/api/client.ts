import axios from 'axios';
import * as SecureStore from 'expo-secure-store';

// Change this to your machine's local IP when testing on a physical device
const API_URL = 'http://192.168.1.100:5294';

export const api = axios.create({
  baseURL: API_URL,
  timeout: 10000,
});

api.interceptors.request.use(async config => {
  const token = await SecureStore.getItemAsync('jwt');
  if (token) config.headers.Authorization = `Bearer ${token}`;
  return config;
});

export { API_URL };
