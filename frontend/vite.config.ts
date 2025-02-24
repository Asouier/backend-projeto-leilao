// Plugins
import AutoImport from "unplugin-auto-import/vite";
import Components from "unplugin-vue-components/vite";
import Vue from "@vitejs/plugin-vue";
import VueRouter from "unplugin-vue-router/vite";
import Vuetify, { transformAssetUrls } from "vite-plugin-vuetify";

// Utilities
import { defineConfig } from "vite";

export default defineConfig({
    plugins: [
      VueRouter({
        dts: "src/typed-router.d.ts",
      }),
      AutoImport({
        imports: [
          "vue",
          {
            "vue-router/auto": ["useRoute", "useRouter"],
          },
        ],
        dts: "src/auto-imports.d.ts",
        eslintrc: {
          enabled: true,
        },
        vueTemplate: true,
      }),
      Components({
        dts: "src/components.d.ts",
      }),
      Vue({
        template: { transformAssetUrls },
      }),
      Vuetify({
        autoImport: true
      }),
    ],
    server: {
      port: 8080,
    },
    resolve: {
      alias: {
        '@': '/src',
      },
    },
    build: {
      outDir: "./deploy/dist",
    }
  });



// import { defineConfig } from 'vite'
// import vue from '@vitejs/plugin-vue'

// // https://vitejs.dev/config/
// export default defineConfig({
//   plugins: [vue()],
// })

