<template>
  <nav class="navbar navbar-expand-lg navbar-light bg-light">
    <div class="container-fluid">
      <a class="navbar-brand" href="#">Venta Control</a>
      <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav"
        aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
        <span class="navbar-toggler-icon"></span>
      </button>
      <div class="collapse navbar-collapse" id="navbarNav">
        <ul class="navbar-nav">
          <li class="nav-item">
            <a class="nav-link active" aria-current="page" href="#">Home</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#">Producto</a>
          </li>
          <li class="nav-item">
            <a class="nav-link" href="#" tabindex="-1" aria-disabled="true">Venta</a>
          </li>
          <li class="nav-item">
            <RouterLink to="/login" class="nav-link" tabindex="-1" aria-disabled="true">Detalle de Venta
            </RouterLink>
          </li>
          <RouterLink to="/registro" class="nav-link">Registro</RouterLink>
          <RouterLink to="/login" class="nav-link">Login</RouterLink>
        </ul>
      </div>
    </div>
  </nav>

  <div class="container py-5">

    <!-- Título -->
    <div class="d-flex justify-content-between align-items-center mb-4">
      <div>
        <h2 class="fw-bold mb-1">Productos</h2>
        <p class="text-muted mb-0">
          Explora los productos disponibles
        </p>
      </div>

      <button class="btn btn-success shadow-sm">
        <i class="bi bi-plus-lg me-2"></i>
        Nuevo Producto
      </button>
    </div>

    <!-- Buscador -->
    <div class="card border-0 shadow-sm mb-4">
      <div class="card-body">
        <div class="input-group">
          <span class="input-group-text bg-white border-end-0">
            <i class="bi bi-search"></i>
          </span>

          <input type="text" class="form-control border-start-0" placeholder="Buscar producto..." />
        </div>
      </div>
    </div>

    <!-- Cards -->
    <div class="row g-4">
      <div class="col-lg-4 col-md-6" v-for="producto in productos" :key="producto.id">
        <div class="card h-100 border-0 shadow-sm producto-card">

          <!-- Imagen -->
          <img :src="producto.imagenUrl || 'https://placehold.co/400x220'" class="card-img-top" alt="Producto" />

          <div class="card-body d-flex flex-column">

            <!-- Nombre -->
            <h5 class="card-title fw-bold text-dark">
              {{ producto.nombre }}
            </h5>

            <!-- Descripción -->
            <p class="card-text text-muted flex-grow-1">
              {{ producto.descripcion }}
            </p>

            <!-- Precio -->
            <div class="mb-3">
              <span class="badge bg-success fs-6 px-3 py-2">
                ${{ producto.precio }}
              </span>
            </div>

            <!-- Botones -->
            <div class="d-flex gap-2">
              <button class="btn btn-primary w-100" @click="verDetalle(producto.id)">
                Ver detalle
              </button>

              <button class="btn btn-outline-secondary">
                <i class="bi bi-pencil"></i>
              </button>
            </div>

          </div>
        </div>
      </div>
    </div>

  </div>

</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { obtenerProductos } from '../services/productoService'
import { useRouter } from 'vue-router'
interface Producto {
  id: number
  nombre: string
  descripcion: string
  precio: number
  stock: number
  imagenUrl?: string
}
const productos = ref<Producto[]>([])
const router = useRouter()
onMounted(async () => {
  productos.value = await obtenerProductos()
})
const verDetalle = (id: number) => {
  router.push(`/producto/${id}`)
}
</script>

<style scoped>
.producto-card {
  transition: all 0.3s ease;
  border-radius: 16px;
  overflow: hidden;
}

.producto-card:hover {
  transform: translateY(-5px);
  box-shadow: 0 12px 24px rgba(0, 0, 0, 0.12) !important;
}

.card-img-top {
  height: 220px;
  object-fit: cover;
}

.btn {
  border-radius: 10px;
}

.input-group-text,
.form-control {
  border-radius: 10px;
}
</style>