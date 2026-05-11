import axios from 'axios'
import { useAuthStore } from '../stores/authStore'

const API_URL = 'http://localhost:5135'

export const obtenerProductoPorId = async (id: number) => {
     const token = localStorage.getItem('token')
    const response = await axios.get(`${API_URL}/api/Producto/${id}`,{ headers: {
    Authorization: `Bearer ${token}`
  }
})
  return response.data
}
export const obtenerProductos = async () => {
    const token = localStorage.getItem('token')
    console.log('Token desde localStorage:', localStorage.getItem('token'))
    const response = await axios.get(`${API_URL}/api/Producto`,{
    headers: {
    Authorization: `Bearer ${token}`
  }
  })
  return response.data
}
export const crearProducto = async (data: any) => {
  const token = localStorage.getItem('token')
  const response = await axios.post(`${API_URL}/api/Producto`, data, {
    headers: { Authorization: `Bearer ${token}` }
  })
  return response.data
}

export const actualizarProducto = async (id: number, data: any) => {
  const token = localStorage.getItem('token')
  const response = await axios.put(`${API_URL}/api/Producto/${id}`, data, {
    headers: { Authorization: `Bearer ${token}` }
  })
  return response.data
}

export const eliminarProducto = async (id: number) => {
  const token = localStorage.getItem('token')
  await axios.delete(`${API_URL}/api/Producto/${id}`, {
    headers: { Authorization: `Bearer ${token}` }
  })
}