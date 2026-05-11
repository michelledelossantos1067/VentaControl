<template>
  <div>
    <div class="d-flex justify-content-between align-items-center mb-4">
      <h3>Gestión de Clientes</h3>
    </div>

    <!-- Formulario crear/editar -->
    <div class="card p-4 mb-4" v-if="mostrarFormulario">
      <h5>{{ clienteEditando ? 'Editar' : 'Nuevo' }} Cliente</h5>
      <input v-model="form.nombre" class="form-control mb-2" placeholder="Nombre" />
      <input v-model="form.email" class="form-control mb-2" placeholder="Email" />
      <input v-model="form.telefono" class="form-control mb-2" placeholder="Telefono" />
      <div class="d-flex gap-2">
        <button class="btn btn-primary" @click="guardar">Guardar</button>
        <button class="btn btn-secondary" @click="cancelar">Cancelar</button>
      </div>
    </div>

    <!-- Tabla -->
    <table class="table table-striped">
      <thead>
        <tr>
          <th>Nombre</th>
          <th>Email</th>
          <th>Telefono</th>
          <th>Acciones</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="cliente in clientes" :key="cliente.id">
          <td>{{ cliente.nombre }}</td>
          <td>{{ cliente.email }}</td>
           <td>{{ cliente.telefono }}</td>
          <td>
            <button class="btn btn-sm btn-warning me-2" @click="editar(cliente)">Editar</button>
            <button class="btn btn-sm btn-danger" @click="eliminar(cliente.id)">Eliminar</button>
          </td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script setup  lang="ts">
import { ref, onMounted } from 'vue'
import { obtenerClientes, actualizarCliente, eliminarCliente } from '../../services/clienteService'

interface Cliente {
  id: number
  nombre: string
  email: string
  telefono: string
}

const clientes = ref<Cliente[]>([])
const mostrarFormulario = ref(false)
const clienteEditando = ref<Cliente | null>(null)
const form = ref({ nombre: '', email:'',telefono:''})

onMounted(async () => {
  clientes.value = await obtenerClientes()
})

const cancelar = () => {
  mostrarFormulario.value = false
  clienteEditando.value = null
  form.value = { nombre: '', email:'',telefono:''}
}
const editar = (cliente: Cliente) => {
  clienteEditando.value = cliente
  form.value = { ...cliente }
  mostrarFormulario.value = true
}
const guardar = async () => {
  if (clienteEditando.value) {
    await actualizarCliente(clienteEditando .value.id, form.value)
  }
  clientes.value = await obtenerClientes    ()
  cancelar()
}
const eliminar = async (id: number) => {
  if (confirm('¿Estás seguro de eliminar este cliente?')) {
    await eliminarCliente(id)
    clientes.value = clientes.value.filter(c => c.id !== id)
  }
}

</script>