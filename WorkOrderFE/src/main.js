import { createApp } from 'vue'
import './style.css'
import App from './App.vue'
import axios from 'axios';
import 'bootstrap/dist/css/bootstrap.min.css';
import 'bootstrap/dist/js/bootstrap.bundle.min.js';


const app = createApp(App);




axios.defaults.baseURL = 'http://localhost:5266';

app.config.globalProperties.$axios = axios;;
app.mount('#app');
