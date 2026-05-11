<template>
  <div class="container-fluid p-0">
    <nav class="navbar navbar-dark bg-dark d-md-none px-3">
      <span class="navbar-brand fw-bold">Admin Panel</span>
      <button class="navbar-toggler" type="button" @click="sidebarAbierto = !sidebarAbierto">
        <span class="navbar-toggler-icon"></span>
      </button>
    </nav>

    <div
      v-if="sidebarAbierto"
      class="sidebar-overlay d-md-none"
      @click="sidebarAbierto = false"
    />

    <div class="d-flex" style="min-height: 100vh">
      <aside :class="['sidebar bg-dark', sidebarAbierto ? 'sidebar--open' : '']">
        <div class="sidebar-header d-none d-md-block px-3 pt-4 pb-2">
          <h5 class="text-white fw-bold">Admin Panel</h5>
        </div>

        <ul class="nav flex-column px-3 pt-3 gap-2">
          <li v-for="item in menuItems" :key="item.key" class="nav-item">
            <button
              :class="['btn w-100 text-start', vista === item.key ? 'btn-light' : 'btn-outline-light']"
              @click="navegarA(item.key)"
            >
              <span class="me-2">{{ item.icono }}</span>{{ item.label }}
            </button>
          </li>
        </ul>

        <div class="px-3 mt-auto pb-4 pt-3">
          <button class="btn btn-danger w-100" @click="cerrarSesion">
            🚪 Cerrar Sesión
          </button>
        </div>
      </aside>

      <main class="flex-grow-1 p-3 p-md-4 overflow-auto main-content">
        <h6 class="text-muted mb-3 d-none d-md-block">
          {{ menuItems.find(i => i.key === vista)?.label }}
        </h6>
        <UsuariosAdmin      v-if="vista === 'usuarios'" />
        <ProductosAdmin     v-if="vista === 'productos'" />
        <ClientesAdmin      v-if="vista === 'clientes'" />
        <DetalleVentasAdmin v-if="vista === 'detalledeventas'" />
        <VentasAdmin        v-if="vista === 'ventas'" />
      </main>
    </div>

    <nav class="bottom-nav d-flex d-md-none">
      <button
        v-for="item in menuItems"
        :key="item.key"
        :class="['bottom-nav__item', vista === item.key ? 'bottom-nav__item--active' : '']"
        @click="navegarA(item.key)"
      >
        <span class="bottom-nav__icon">{{ item.icono }}</span>
        <span class="bottom-nav__label">{{ item.label }}</span>
      </button>
    </nav>
  </div>
</template>

<script setup>
import { ref } from 'vue';
import { useRouter } from 'vue-router';
import { useAuthStore } from '../../stores/authStore';
import ProductosAdmin     from '@/components/admin/ProductosAdmin.vue';
import UsuariosAdmin      from '@/components/admin/UsuariosAdmin.vue';
import ClientesAdmin      from '@/components/admin/ClientesAdmin.vue';
import DetalleVentasAdmin from '@/components/admin/DetalleVentasAdmin.vue';
import VentasAdmin        from '@/components/admin/VentasAdmin.vue';

const router         = useRouter();
const authStore      = useAuthStore();
const vista          = ref('productos');
const sidebarAbierto = ref(false);

const menuItems = [
  { key: 'usuarios',        label: 'Usuarios',   icono: '👤' },
  { key: 'productos',       label: 'Productos',  icono: '📦' },
  { key: 'clientes',        label: 'Clientes',   icono: '🧑‍💼' },
  { key: 'detalledeventas', label: 'Ventas Det', icono: '📋' },
  { key: 'ventas',          label: 'Ventas',     icono: '💰' },
];

const navegarA = (key) => {
  vista.value = key;
  sidebarAbierto.value = false;
};

const cerrarSesion = () => {
  authStore.cerrarSesion();
  router.push('/login');
};
</script>

<style scoped>
.sidebar {
  width: 230px;
  min-height: 100vh;
  display: flex;
  flex-direction: column;
  flex-shrink: 0;
  transition: transform 0.28s ease;
}

@media (max-width: 767px) {
  .sidebar {
    position: fixed;
    top: 0;
    left: 0;
    height: 100%;
    z-index: 1045;
    transform: translateX(-100%);
    padding-top: 56px;
  }
  .sidebar--open {
    transform: translateX(0);
  }
  .main-content {
    padding-bottom: 75px !important;
  }
}

.sidebar-overlay {
  position: fixed;
  inset: 0;
  background: rgba(0, 0, 0, 0.5);
  z-index: 1044;
}

.bottom-nav {
  position: fixed;
  bottom: 0;
  left: 0;
  right: 0;
  height: 62px;
  background: #212529;
  border-top: 1px solid #444;
  z-index: 1040;
  justify-content: space-around;
  align-items: center;
}

.bottom-nav__item {
  flex: 1;
  display: flex;
  flex-direction: column;
  align-items: center;
  justify-content: center;
  gap: 2px;
  background: none;
  border: none;
  color: #adb5bd;
  padding: 6px 0;
  cursor: pointer;
  transition: color 0.2s;
}

.bottom-nav__item--active {
  color: #ffffff;
}

.bottom-nav__icon {
  font-size: 1.2rem;
  line-height: 1;
}

.bottom-nav__label {
  font-size: 0.62rem;
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
  max-width: 60px;
}
</style>