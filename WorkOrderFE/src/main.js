import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import axios from 'axios';

const app = createApp(App);

axios.defaults.baseURL = 'http://localhost:5266';

app.config.globalProperties.$axios = axios;;
app.mount('#app');
