<template>
    <div>
        <div class="d-flex justify-content-between align-items-center mb-4">
            <h3>Gestión de Usuarios</h3>
            <button class="btn btn-success" @click="mostrarFormulario = true">+ Nuevo Usuario</button>
        </div>

        <!-- Formulario -->
        <div v-if="mostrarFormulario" class="card p-4 mb-4">
            <h5>{{ usuarioEditando ? 'Editar Usuario' : 'Nuevo Usuario' }}</h5>
            <input v-model="form.nombre" type="text" class="form-control mb-2" placeholder="Nombre" />
            <input v-model="form.telefono" type="text" class="form-control mb-2" placeholder="Teléfono" />
            <input v-model="form.email" type="email" class="form-control mb-2" placeholder="Email" />
            <input v-model="form.password" type="password" class="form-control mb-2" placeholder="Password" />
            <select v-model="form.rol" class="form-select mb-2">
                <option value="admin">Admin</option>
                <option value="cliente">Cliente</option>
            </select>
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
                    <th>Rol</th>
                    <th>Acciones</th>
                </tr>
            </thead>
            <tbody>
                <tr v-for="usuario in usuarios" :key="usuario.id">
                    <td>{{ usuario.nombre }}</td>
                    <td>{{ usuario.email }}</td>
                    <td>{{ usuario.telefono }}</td>
                    <td>{{ usuario.rol }}</td>
                    <td>
                        <button class="btn btn-sm btn-danger" @click="eliminar(usuario.id)">Eliminar</button>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
</template>

<script setup lang="ts">
import { ref, onMounted } from 'vue'
import { obtenerUsuarios, crearUsuario, actualizarUsuario, eliminarUsuario } from '../../services/usuarioService';
import { crearCliente } from '../../services/clienteService';
const usuarios = ref<any[]>([])
const mostrarFormulario = ref(false)
const usuarioEditando = ref<any>(null)
const form = ref({ nombre: '', telefono: '', email: '', password: '', rol: 'cliente' })
const cargarUsuarios = async () => {
    usuarios.value = await obtenerUsuarios()
}

onMounted(cargarUsuarios)
const guardar = async () => {
    if (usuarioEditando.value) {
        await actualizarUsuario(usuarioEditando.value.id, form.value)
    } else {
        await crearUsuario({ email: form.value.email, password: form.value.password, rol: form.value.rol })
        if (form.value.rol === 'cliente') {
            await crearCliente({ nombre: form.value.nombre, email: form.value.email, telefono: form.value.telefono })
        }
    }
    mostrarFormulario.value = false
    form.value = { nombre: '', telefono: '', email: '', password: '', rol: 'cliente' }
    cargarUsuarios()
}
const cancelar = () => {
    mostrarFormulario.value = false
    form.value = { nombre: '', telefono: '', email: '', password: '', rol: 'cliente' }
    usuarioEditando.value = null
}
const eliminar = async (id: number) => {
    if (confirm('¿Estás seguro de eliminar este usuario?')) {
    try {
      await eliminarUsuario(id)
      usuarios.value = usuarios.value.filter(p => p.id !== id)
    } catch (error: any) {
      alert('No se puede eliminar este cliente.')
    }
  }
}
</script>