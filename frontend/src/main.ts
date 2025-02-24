import App from "@/App.vue";
import router from "@/router";
import { createApp } from "vue";
import "@/assets/style/global.scss";
import { createPinia } from "pinia";
import vuetify from "@/plugins/vuetify";


const app = createApp(App);
const pinia = createPinia();

app.use(vuetify);
app.use(router);
app.use(pinia);

app.mount("#app");
