<template>
  <div class="login-page d-flex align-items-center justify-content-center">

    <div class="card login-card border-0 shadow-lg">
      <div class="card-body p-5">

        <!-- Logo / Título -->
        <div class="text-center mb-4">
          <div class="login-icon mb-3">
            <i class="bi bi-person-circle"></i>
          </div>

          <h2 class="fw-bold">Iniciar Sesión</h2>

          <p class="text-muted">
            Bienvenido de nuevo
          </p>
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
        <button class="btn btn-primary w-100 btn-lg shadow-sm" @click="handleLogin">
          <i class="bi bi-box-arrow-in-right me-2"></i>
          Entrar
        </button>

        <!-- Footer -->
        <div class="text-center mt-4">
          <small class="text-muted">
            ¿No tienes cuenta?
            <a href="#" class="text-decoration-none fw-semibold">
              Regístrate
            </a>
          </small>
        </div>

      </div>
    </div>

  </div>
</template>

<style scoped>
.login-page {
  min-height: 100vh;
  background: linear-gradient(to bottom right, #f1f5f9, #dbeafe);
  padding: 20px;
}

.login-card {
  width: 100%;
  max-width: 450px;
  border-radius: 24px;
  overflow: hidden;
}

.login-icon {
  font-size: 4rem;
  color: #0d6efd;
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
import { useAuthStore } from '../stores/authStore'
import { useRouter } from 'vue-router'
const email = ref('')
const password = ref('')
const error = ref('')
const authStore = useAuthStore()
const router = useRouter()
const handleLogin = async () => {
  try {
    await authStore.iniciarSesion(email.value, password.value)
    const rol = localStorage.getItem('rol')
    if (rol === 'admin') {
      router.push('/admin')
    } else {
      router.push('/home')
    }
  } catch (err: any) {
    error.value = 'Error al iniciar sesión: ' + err.message
  }
}

</script>