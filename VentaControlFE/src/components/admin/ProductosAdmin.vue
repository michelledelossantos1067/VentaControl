<template>
  <div>
    <div class="d-flex justify-content-between align-items-center mb-4">
      <h3>Gestión de Productos</h3>
      <button class="btn btn-success" @click="mostrarFormulario = true">+ Nuevo Producto</button>
    </div>

    <!-- Formulario crear/editar -->
    <div class="card p-4 mb-4" v-if="mostrarFormulario">
      <h5>{{ productoEditando ? 'Editar' : 'Nuevo' }} Producto</h5>
      <input v-model="form.nombre" class="form-control mb-2" placeholder="Nombre" />
      <input v-model="form.descripcion" class="form-control mb-2" placeholder="Descripción" />
      <input v-model="form.precio" type="number" class="form-control mb-2" placeholder="Precio" />
      <input v-model="form.stock" type="number" class="form-control mb-2" placeholder="Stock" />
      <input v-model="form.imagenUrl" class="form-control mb-2" placeholder="URL de imagen" />
      <div class="d-flex gap-2">
        <button class="btn btn-primary" @click="guardar">Guardar</button>
        <button class="btn btn-secondary" @click="cancelar">Cancelar</button>
      </div>
    </div>

    <!-- Tabla -->
    <table class="table table-striped">
      <thead>
        <tr>
          <th>Imagen</th>
          <th>Nombre</th>
          <th>Descripción</th>
          <th>Precio</th>
          <th>Stock</th>
          <th>Acciones</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="producto in productos" :key="producto.id">
          <td><img :src="producto.imagenUrl || 'https://placehold.co/60x60'" width="60" /></td>
          <td>{{ producto.nombre }}</td>
          <td>{{ producto.descripcion }}</td>
          <td>${{ producto.precio }}</td>
          <td>{{ producto.stock }}</td>
          <td>
            <button class="btn btn-sm btn-warning me-2" @click="editar(producto)">Editar</button>
            <button class="btn btn-sm btn-danger" @click="eliminar(producto.id)">Eliminar</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup  lang="ts">
import { ref, onMounted } from 'vue'
import { obtenerProductos, crearProducto, actualizarProducto, eliminarProducto } from '../../services/productoService'

interface Producto {
  id: number
  nombre: string
  descripcion: string
  precio: number
  stock: number
  imagenUrl: string
}

const productos = ref<Producto[]>([])
const mostrarFormulario = ref(false)
const productoEditando = ref<Producto | null>(null)
const form = ref({ nombre: '', descripcion: '', precio: 0, stock: 0, imagenUrl: '' })

onMounted(async () => {
  productos.value = await obtenerProductos()
})

const cancelar = () => {
  mostrarFormulario.value = false
  productoEditando.value = null
  form.value = { nombre: '', descripcion: '', precio: 0, stock: 0, imagenUrl: '' }
}
const editar = (producto: Producto) => {
  productoEditando.value = producto
  form.value = { ...producto }
  mostrarFormulario.value = true
}
const guardar = async () => {
  if (productoEditando.value) {
    await actualizarProducto(productoEditando.value.id, form.value)
  } else {
    await crearProducto(form.value)
  }
  productos.value = await obtenerProductos()
  cancelar()
}
const eliminar = async (id: number) => {
  if (confirm('¿Estás seguro de eliminar este producto? Si tiene ventas asociadas no podrá eliminarse.')) {
    try {
      await eliminarProducto(id)
      productos.value = productos.value.filter(p => p.id !== id)
    } catch (error: any) {
      alert('No se puede eliminar este producto porque tiene ventas asociadas. Elimina primero el detalle de venta.')
    }
  }
}

</script>