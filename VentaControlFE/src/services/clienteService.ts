import axios from 'axios'
import { useAuthStore } from '../stores/authStore'
const API_URL = 'http://localhost:5135'

export const crearCliente = async (data: any) => {
  const token = localStorage.getItem('token')
  const response = await axios.post(`${API_URL}/api/Cliente`, data, {
    headers: { Authorization: `Bearer ${token}` }
  })
  return response.data
}
export const obtenerClientePorEmail = async (email: string) => {
  const token = localStorage.getItem('token')
  const response = await axios.get(`${API_URL}/api/Cliente/porEmail/${email}`, {
    headers: { Authorization: `Bearer ${token}` }
  })
  return response.data
}
export const obtenerClientes = async () => {
  const token = localStorage.getItem('token')
  const response = await axios.get(`${API_URL}/api/Cliente`, {
    headers: { Authorization: `Bearer ${token}` }
  })
  return response.data
}
export const actualizarCliente = async (id: number, data: any) => {
  const token = localStorage.getItem('token')
  const response = await axios.put(`${API_URL}/api/Cliente/${id}`, data, {
    headers: { Authorization: `Bearer ${token}` }
  })
  return response.data
}

export const eliminarCliente = async (id: number) => {
  const token = localStorage.getItem('token')
  await axios.delete(`${API_URL}/api/Cliente/${id}`, {
    headers: { Authorization: `Bearer ${token}` }
  })
}