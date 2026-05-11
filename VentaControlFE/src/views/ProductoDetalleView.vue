<template>
    <div class="detalle-page py-5">
        <div class="container">

            <div class="row justify-content-center align-items-center">

                <div class="col-lg-10">
                    <div class="card border-0 shadow-lg overflow-hidden detalle-card">

                        <div class="row g-0">

                            <!-- Imagen -->
                            <div class="col-md-6">
                                <div class="img-container">
                                    <img :src="producto.imagenUrl || 'https://placehold.co/600x500'"
                                        class="img-fluid detalle-img" alt="Producto" />
                                </div>
                            </div>

                            <!-- Información -->
                            <div class="col-md-6">
                                <div class="card-body p-5 d-flex flex-column h-100">

                                    <span class="badge bg-primary mb-3 categoria-badge">
                                        Producto Disponible
                                    </span>

                                    <!-- Nombre -->
                                    <h1 class="fw-bold text-dark mb-3">
                                        {{ producto.nombre }}
                                    </h1>

                                    <!-- Descripción -->
                                    <p class="text-muted fs-5 mb-4">
                                        {{ producto.descripcion }}
                                    </p>

                                    <!-- Precio -->
                                    <div class="precio-container mb-4">
                                        <span class="precio-label">Precio</span>

                                        <h2 class="fw-bold text-success">
                                            ${{ producto.precio }}
                                        </h2>
                                    </div>

                                    <!-- Características -->
                                    <div class="mb-4">
                                        <div class="d-flex align-items-center mb-2">
                                            <i class="bi bi-check-circle-fill text-success me-2"></i>
                                            <span>Producto original</span>
                                        </div>

                                        <div class="d-flex align-items-center mb-2">
                                            <i class="bi bi-truck text-primary me-2"></i>
                                            <span>Entrega rápida</span>
                                        </div>

                                        <div class="d-flex align-items-center">
                                            <i class="bi bi-shield-check text-warning me-2"></i>
                                            <span>Garantía incluida</span>
                                        </div>
                                        <!-- Cantidad -->
                                        <div class="mb-3">
                                            <label class="form-label">Cantidad</label>
                                            <input v-model="cantidad" type="number" min="1" :max="producto.stock"
                                                class="form-control" />
                                        </div>
                                        <p class="text-danger" v-if="error">{{ error }}</p>

                                    </div>

                                    <!-- Botones -->
                                    <div class="d-flex gap-3 mt-auto">


                                        <button class="btn btn-primary btn-lg flex-fill shadow-sm" @click="comprar">
                                            <i class="bi bi-cart-check me-2"></i>
                                            Comprar Ahora
                                        </button>

                                        <button class="btn btn-outline-dark btn-lg">
                                            <i class="bi bi-heart"></i>
                                        </button>

                                    </div>

                                </div>
                            </div>

                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</template>

<script setup lang="ts">
import { onMounted, ref } from 'vue'
import { obtenerProductoPorId } from '../services/productoService'
import { obtenerClientePorEmail } from '../services/clienteService'
import { venta } from '../services/ventaService'
import { crearDetalleVenta } from '../services/detalleVentaService'
import { useRoute, useRouter } from 'vue-router'
import { useAuthStore } from '../stores/authStore'

interface Producto {
    id: number
    nombre: string
    descripcion: string
    precio: number
    stock: number
    imagenUrl?: string
}
const cantidad = ref(1)

const producto = ref<Producto>({ id: 0, nombre: '', descripcion: '', precio: 0, stock: 0, imagenUrl: '' })
const route = useRoute()
const router = useRouter()
const id = Number(route.params.id)

onMounted(async () => {
    producto.value = await obtenerProductoPorId(id)
})
const error = ref('')
const comprar = async () => {
    try {
        const email = localStorage.getItem('email')
        const cliente = await obtenerClientePorEmail(email!)
        error.value = ''

        if (!email) {
            error.value = 'El email es requerido'
            return
        }
        if (!cantidad.value || cantidad.value < 1) {
            error.value = 'La cantidad debe ser al menos 1'
            return
        }
        if (cantidad.value > producto.value.stock) {
            error.value = `La cantidad no puede ser mayor a ${producto.value.stock}`
            return
        }
        const ventaCreada = await venta(new Date().toISOString(), cliente.id, producto.value.precio)
        await crearDetalleVenta(ventaCreada.id, producto.value.id, cantidad.value, producto.value.precio)
        router.push('/confirmacion')
    } catch (error: any) {
        console.error('Error al comprar:', error.message)
    }
}
</script>

<style scoped>
.detalle-page {
    min-height: 100vh;
    background: linear-gradient(to bottom right, #f8f9fa, #eef2f7);
}

.detalle-card {
    border-radius: 24px;
}

.img-container {
    height: 100%;
    background: #f4f4f4;
}

.detalle-img {
    width: 100%;
    height: 100%;
    object-fit: cover;
    min-height: 500px;
}

.card-body {
    background: white;
}

.categoria-badge {
    width: fit-content;
    padding: 10px 16px;
    border-radius: 12px;
    font-size: 0.9rem;
}

.precio-container {
    padding: 20px;
    background: #f8f9fa;
    border-radius: 18px;
}

.precio-label {
    display: block;
    color: #6c757d;
    margin-bottom: 5px;
}

.btn {
    border-radius: 14px;
    font-weight: 600;
    transition: 0.3s ease;
}

.btn-primary:hover {
    transform: translateY(-2px);
}

@media (max-width: 768px) {
    .detalle-img {
        min-height: 300px;
    }

    .card-body {
        padding: 2rem !important;
    }

    h1 {
        font-size: 1.8rem;
    }
}
</style>