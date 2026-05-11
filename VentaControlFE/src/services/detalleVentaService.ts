import axios from 'axios'
import { useAuthStore } from '../stores/authStore'
const API_URL = 'http://localhost:5135'

export const crearDetalleVenta = async (VentaId: number, ProductoId: number, Cantidad: number, Precio: number) => {
  const token = localStorage.getItem('token')
  const response = await axios.post(`${API_URL}/api/DetalleVenta`, {
    VentaId,
    ProductoId,
    Cantidad,
    Precio
  }, {
    headers: {
      Authorization: `Bearer ${token}`
    }
  })
  return response.data
}

export const VerDetalleVenta = async () => {
  const token = localStorage.getItem('token')
    const response = await axios.get(`${API_URL}/api/DetalleVenta`,{
     headers: {
        Authorization: `Bearer ${token}`
      }
    })
  return response.data
}

export const obtenerDetalleVentas = async () => {
    const token = localStorage.getItem('token')
    console.log('Token desde localStorage:', localStorage.getItem('token'))
    const response = await axios.get(`${API_URL}/api/DetalleVenta/conDetalle`,{
    headers: {
    Authorization: `Bearer ${token}`
  }
  })
  return response.data
}

export const actualizarDetalleVenta = async (id: number, data: any) => {
  const token = localStorage.getItem('token')
  const response = await axios.put(`${API_URL}/api/DetalleVenta/${id}`, data, {
    headers: { Authorization: `Bearer ${token}` }
  })
  return response.data
}

export const eliminarDetalleVenta = async (id: number) => {
  const token = localStorage.getItem('token')
  await axios.delete(`${API_URL}/api/DetalleVenta/${id}`, {
    headers: { Authorization: `Bearer ${token}` }
  })
}