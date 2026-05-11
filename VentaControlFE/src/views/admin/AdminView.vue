<template>
  <div class="container-fluid">
    <div class="row">
      <!-- Sidebar -->
      <div class="col-md-2 bg-dark min-vh-100 p-3">
        <h5 class="text-white mb-4">Admin Panel</h5>
        <ul class="nav flex-column">
          <li class="nav-item mb-2">
            <button class="btn btn-outline-light w-100" @click="vista = 'usuarios'">Usuarios</button>
          </li>
          <li class="nav-item mb-2">
            <button class="btn btn-outline-light w-100" @click="vista = 'productos'">Productos</button>
          </li>
          <li class="nav-item mb-2">
            <button class="btn btn-outline-light w-100" @click="vista = 'clientes'">Clientes</button>
          </li>
          <li class="nav-item mb-2">
            <button class="btn btn-outline-light w-100" @click="vista = 'detalledeventas'">Detalle de Ventas</button>
          </li>
          <li class="nav-item mb-2">
            <button class="btn btn-outline-light w-100" @click="vista = 'ventas'">Ventas</button>
          </li>
          <li class="nav-item mt-4">
            <button class="btn btn-danger w-100" @click="cerrarSesion">Cerrar Sesión</button>
          </li>
        </ul>
      </div>
      <!-- Contenido -->
      <div class="col-md-10 p-4">
        <UsuariosAdmin v-if="vista === 'usuarios'" />
        <ProductosAdmin v-if="vista === 'productos'" />
        <ClientesAdmin v-if="vista === 'clientes'" />
        <DetalleVentasAdmin v-if="vista === 'detalledeventas'" />
        <VentasAdmin v-if="vista === 'ventas'" />
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import { useAuthStore } from '../../stores/authStore';
import ProductosAdmin from '@/components/admin/ProductosAdmin.vue';
import UsuariosAdmin from '@/components/admin/UsuariosAdmin.vue';
import ClientesAdmin from '@/components/admin/ClientesAdmin.vue';
import DetalleVentasAdmin from '@/components/admin/DetalleVentasAdmin.vue';
import { useRouter } from 'vue-router'
import VentasAdmin from '@/components/admin/VentasAdmin.vue';
const router = useRouter()
const vista = ref('productos');
const authStore = useAuthStore();
const cerrarSesion = () => {
  authStore.cerrarSesion()
  router.push('/login')
};
</script>
