import axios from 'axios'
import { useAuthStore } from '../stores/authStore'

const API_URL = 'http://localhost:5135'

export const obtenerUsuarios = async () => {
    const token = localStorage.getItem('token')
    console.log('Token desde localStorage:', localStorage.getItem('token'))
    const response = await axios.get(`${API_URL}/api/Usuario`,{
    headers: {
    Authorization: `Bearer ${token}`
  }
  })
  return response.data
}
export const crearUsuario = async (data: any) => {
  const token = localStorage.getItem('token')
  const response = await axios.post(`${API_URL}/api/Usuario`, data, {
    headers: { Authorization: `Bearer ${token}` }
  })
  return response.data
}

export const actualizarUsuario = async (id: number, data: any) => {
  const token = localStorage.getItem('token')
  const response = await axios.put(`${API_URL}/api/Usuario/${id}`, data, {
    headers: { Authorization: `Bearer ${token}` }
  })
  return response.data
}

export const eliminarUsuario = async (id: number) => {
  const token = localStorage.getItem('token')
  await axios.delete(`${API_URL}/api/Usuario/${id}`, {
    headers: { Authorization: `Bearer ${token}` }
  })
}