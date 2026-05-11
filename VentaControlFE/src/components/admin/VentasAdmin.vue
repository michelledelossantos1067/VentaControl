<template>
  <div>
    <div class="d-flex justify-content-between align-items-center mb-4">
      <h3>Gestión de Ventas</h3>
    </div>

    <!-- Formulario crear/editar -->
    <div class="card p-4 mb-4" v-if="mostrarFormulario">
      <h5>{{ ventaEditando ? 'Editar' : 'Nuevo' }} Ventas</h5>
      <input v-model="form.fecha" class="form-control mb-2" placeholder="Fecha" />
      <input v-model="form.clienteNombre" class="form-control mb-2" placeholder="ClienteNombre" />
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
          <th>Fecha</th>
          <th>ClienteNombre</th>
          <th>Total</th>
          <th>Acciones</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="venta in ventas" :key="venta.id">
          <td>{{ venta.fecha }}</td>
          <td>{{ venta.clienteNombre }}</td>
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
import { obtenerVentasConCliente, actualizarVenta, eliminarVenta } from '../../services/ventaService'

interface Cliente {
  id: number
  fecha: string
  clienteNombre: string
  total: string
}

const ventas = ref<Cliente[]>([])
const mostrarFormulario = ref(false)
const ventaEditando = ref<Cliente | null>(null)
const form = ref({ fecha: '', clienteNombre:'',total:''})

onMounted(async () => {
  ventas.value = await obtenerVentasConCliente()
})

const cancelar = () => {
  mostrarFormulario.value = false
  ventaEditando.value = null
  form.value = { fecha: '', clienteNombre:'',total:''}
}
const editar = (venta: Cliente) => {
  ventaEditando.value = venta
  form.value = { ...venta }
  mostrarFormulario.value = true
}
const guardar = async () => {
  if (ventaEditando.value) {
    await actualizarVenta(ventaEditando .value.id, form.value)
  }
  ventas.value = await obtenerVentasConCliente()
  cancelar()
}
const eliminar = async (id: number) => {
  if (confirm('¿Estás seguro de eliminar esta venta?')) {
    await eliminarVenta(id)
    ventas.value = ventas.value.filter(c => c.id !== id)
  }
}

</script>