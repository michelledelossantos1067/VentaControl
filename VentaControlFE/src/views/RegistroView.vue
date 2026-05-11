<template>
  <div class="registro-page d-flex align-items-center justify-content-center">

    <div class="card registro-card border-0 shadow-lg">
      <div class="card-body p-5">

        <!-- Header -->
        <div class="text-center mb-4">

          <div class="registro-icon mb-3">
            <i class="bi bi-person-plus-fill"></i>
          </div>

          <h2 class="fw-bold">
            Crear Cuenta
          </h2>

          <p class="text-muted">
            Regístrate para comenzar
          </p>

        </div>

        <!-- Nombre -->
        <div class="mb-3">
          <label class="form-label fw-semibold">
            Nombre Completo
          </label>

          <div class="input-group">
            <span class="input-group-text">
              <i class="bi bi-person"></i>
            </span>

            <input v-model="nombre" type="text" class="form-control" placeholder="Tu nombre" />
          </div>
        </div>

        <!-- Teléfono -->
        <div class="mb-3">
          <label class="form-label fw-semibold">
            Teléfono
          </label>

          <div class="input-group">
            <span class="input-group-text">
              <i class="bi bi-telephone"></i>
            </span>

            <input v-model="telefono" type="text" class="form-control" placeholder="809-000-0000" />
          </div>
        </div>

        <!-- Email -->
        <div class="mb-3">
          <label class="form-label fw-semibold">
            Correo Electrónico
          </label>

          <div class="input-group">
            <span class="input-group-text">
              <i class="bi bi-envelope"></i>
            </span>

            <input v-model="email" type="email" class="form-control" placeholder="ejemplo@email.com" />
          </div>
        </div>

        <!-- Password -->
        <div class="mb-4">
          <label class="form-label fw-semibold">
            Contraseña
          </label>

          <div class="input-group">
            <span class="input-group-text">
              <i class="bi bi-lock"></i>
            </span>

            <input v-model="password" type="password" class="form-control" placeholder="********" />
          </div>
        </div>

        <!-- Error -->
        <div v-if="error" class="alert alert-danger py-2">
          {{ error }}
        </div>

        <!-- Botón -->
        <button class="btn btn-success w-100 btn-lg shadow-sm" @click="handleRegistro">
          <i class="bi bi-check-circle me-2"></i>
          Registrarme
        </button>

        <!-- Footer -->
        <div class="text-center mt-4">
          <small class="text-muted">
            ¿Ya tienes cuenta?
            <RouterLink to="/login" class="text-decoration-none fw-semibold">
              Inicia sesión
            </RouterLink>
          </small>
        </div>

      </div>
    </div>

  </div>
</template>

<style scoped>
.registro-page {
  min-height: 100vh;
  background: linear-gradient(to bottom right, #f8fafc, #dcfce7);
  padding: 20px;
}

.registro-card {
  width: 100%;
  max-width: 500px;
  border-radius: 24px;
  overflow: hidden;
}

.registro-icon {
  font-size: 4rem;
  color: #198754;
}

.form-control,
.input-group-text {
  height: 52px;
  border-radius: 12px;
}

.input-group-text {
  background: white;
}

.btn {
  border-radius: 14px;
  font-weight: 600;
  transition: all 0.3s ease;
}

.btn:hover {
  transform: translateY(-2px);
}

.card-body {
  background: white;
}
</style>

<script setup lang="ts">
import { ref } from 'vue'
import { useRouter } from 'vue-router'
import { registro } from '../services/authService'
const email = ref('')
const password = ref('')
const nombre = ref('')
const telefono = ref('')
const error = ref('')
const router = useRouter()
const handleRegistro = async () => {
  try {
    await registro(email.value, password.value, nombre.value, telefono.value)
    router.push('/')
  } catch (err: any) {
    error.value = 'Error al registrar: ' + err.message
  }
}

</script>