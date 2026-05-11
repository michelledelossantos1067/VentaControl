import { createRouter, createWebHistory } from 'vue-router'
import LoginView from '../views/LoginView.vue'

const router = createRouter({
  history: createWebHistory(),
  routes: [
    { path: '/', component: LoginView },
    { path: '/home', component: ()=> import('../views/HomeView.vue')},
    { path: '/login', component: ()=> import('../views/LoginView.vue')},
    { path: '/registro', component: ()=> import('../views/RegistroView.vue')},
    { path: '/confirmacion', component: ()=> import('../views/ConfirmacionView.vue') },
    {path: '/producto/:id', component: ()=> import('../views/ProductoDetalleView.vue') },
    { path: '/admin', component: () => import('../views/admin/AdminView.vue'), meta: { requiresAdmin: true } },

    ]
})
router.beforeEach((to, from, next) => {
  const token = localStorage.getItem('token')
  const rol = localStorage.getItem('rol')

  if (to.meta.requiresAdmin && rol !== 'admin') {
    next('/')
  } else {
    next()
  }
})

export default router