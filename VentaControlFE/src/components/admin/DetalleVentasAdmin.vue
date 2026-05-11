<template>
  <div>
    <div class="d-flex justify-content-between align-items-center mb-4">
      <h3>Gestión de Detalle de Ventas</h3>
    </div>

    <!-- Formulario crear/editar -->
    <div class="card p-4 mb-4" v-if="mostrarFormulario">
      <h5>{{ detalledeventaEditando ? 'Editar' : 'Nuevo' }} Detalle de Ventas</h5>
      <input v-model="form.productoNombre" class="form-control mb-2" placeholder="Nombre del Producto" />
      <input v-model="form.clienteNombre" class="form-control mb-2" placeholder="Nombre del Cliente" />
      <input v-model="form.precio" class="form-control mb-2" placeholder="Precio" />
      <input v-model="form.total" class="form-control mb-2" placeholder="Total" />
      <div class="d-flex gap-2">
        <button class="btn btn-primary" @click="guardar">Guardar</button>
        <button class="btn btn-secondary" @click="cancelar">Cancelar</button>
      </div>
    </div>

    <!-- Tabla -->
    <table class="table table-striped">
      <thead>
        <tr>
            <th>Nombre del producto</th>
            <th>Nombre del cliente</th>
            <th>precio</th>
            <th>total</th>
            <th>Acciones</th>

        </tr>
      </thead>
      <tbody>
        <tr v-for="venta in ventas" :key="venta.id">
          <td>{{ venta.productoNombre }}</td>
          <td>{{ venta.clienteNombre }}</td>
           <td>{{ venta.precio }}</td>
           <td>{{ venta.total }}</td>
          <td>
            <button class="btn btn-sm btn-warning me-2" @click="editar(venta)">Editar</button>
            <button class="btn btn-sm btn-danger" @click="eliminar(venta.id)">Eliminar</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup  lang="ts">
import { ref, onMounted } from 'vue'
import { obtenerDetalleVentas, actualizarDetalleVenta, eliminarDetalleVenta } from '../../services/detalleVentaService'

interface Cliente {
  id: number
  productoNombre: string
  clienteNombre: string
  precio: string
  total: string
}

const ventas = ref<Cliente[]>([])
const mostrarFormulario = ref(false)
const detalledeventaEditando = ref<Cliente | null>(null)
const form = ref({ productoNombre: '', clienteNombre:'',precio:'',total:''})

onMounted(async () => {
  ventas.value = await obtenerDetalleVentas()
})

const cancelar = () => {
  mostrarFormulario.value = false
  detalledeventaEditando.value = null
  form.value = { productoNombre: '', clienteNombre:'',total:'', precio:''}
}
const editar = (venta: Cliente) => {
  detalledeventaEditando.value = venta
  form.value = { ...venta }
  mostrarFormulario.value = true
}
const guardar = async () => {
  if (detalledeventaEditando.value) {
    await actualizarDetalleVenta(detalledeventaEditando .value.id, form.value)
  }
  ventas.value = await obtenerDetalleVentas()
  cancelar()
}
const eliminar = async (id: number) => {
  if (confirm('¿Estás seguro de eliminar esta venta?')) {
    await eliminarDetalleVenta(id)
    ventas.value = ventas.value.filter(c => c.id !== id)
  }
}

</script>