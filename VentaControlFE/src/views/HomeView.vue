<template>
  <div class="container py-3 py-md-5">
    <!-- Cards -->
    <div class="row g-4">
      <div class="col-12 col-md-6 col-lg-4" v-for="producto in productos" :key="producto.id">
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
            <div class="d-flex flex-column flex-sm-row gap-2">
              <button class="btn btn-primary w-100" @click="verDetalle(producto.id)">
                Ver detalle
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
.card-title,
.card-text {
  word-break: break-word;
}
.btn {
  border-radius: 10px;
}

.card-img-top {
  height: 220px;
}

@media (max-width: 768px) {

  .card-img-top {
    height: 180px;
  }
}

@media (max-width: 576px) {
  .card-img-top {
    height: 160px;
  }
}

.input-group-text,
.form-control {
  border-radius: 10px;
}
</style>