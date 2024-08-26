import { defineConfig } from 'vite'
import vue from '@vitejs/plugin-vue'
import replace from '@rollup/plugin-replace'
import { resolve } from 'path'

export default defineConfig({
    plugins: [
        vue({
            template: {
                compilerOptions: {
                    isCustomElement: (tag) => /^qc-/.test(tag)
                }
            }
        }),
        replace({
            'process.env.NODE_ENV': JSON.stringify(process.env.NODE_ENV || 'development'),
            preventAssignment: true
        })
    ],
    build: {
        lib: {
            entry: resolve(__dirname, 'src/main.js'),
            name: 'MyVueLibrary',
            formats: ['umd'], // Utilisez UMD pour un support universel
            fileName: (format) => `my-vue-library.${format}.js`
        },
        rollupOptions: {
            output: {
                globals: {
                    vue: 'Vue'
                }
            }
        }
    }
})
