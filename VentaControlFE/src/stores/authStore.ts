import { defineStore } from 'pinia'
import { ref } from 'vue'
import { login } from '../services/authService'

export const useAuthStore = defineStore('auth', () => {
  const token = ref<string | null>(null)
  const email = ref<string | null>(null)
  const rol = ref<string | null>(null)

  const iniciarSesion = async (userEmail: string, password: string) => {
    const data = await login(userEmail, password)
    token.value = data.token
    email.value = userEmail
    rol.value = data.rol
    localStorage.setItem('token', data.token)
    localStorage.setItem('rol', data.rol)
    localStorage.setItem('email', userEmail)
  }
  const cerrarSesion = async () => {
    token.value = null
    email.value = null
    rol.value = null
    localStorage.removeItem('token')
    localStorage.removeItem('email')
    localStorage.removeItem('rol')
  }

  return { token, email, iniciarSesion, cerrarSesion }
})
