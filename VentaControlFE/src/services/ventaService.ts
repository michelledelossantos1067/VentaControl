import axios from 'axios'
import { useAuthStore } from '../stores/authStore'
const API_URL = 'http://localhost:5135'

export const venta = async (Fecha: string, ClienteId: number,Total: number) => {
   const token = localStorage.getItem('token')
    const response = await axios.post(`${API_URL}/api/Venta`, {
    Fecha,
    ClienteId,
    Total
  },{ headers: {
      Authorization: `Bearer ${token}`
    }
  })
  return response.data
}


export const obtenerVentasConCliente = async () => {
    const token = localStorage.getItem('token')
    console.log('Token desde localStorage:', localStorage.getItem('token'))
    const response = await axios.get(`${API_URL}/api/Venta/conCliente`,{
    headers: {
    Authorization: `Bearer ${token}`
  }
  })
  return response.data
}
export const crearVenta = async (data: any) => {
  const token = localStorage.getItem('token')
  const response = await axios.post(`${API_URL}/api/Venta`, data, {
    headers: { Authorization: `Bearer ${token}` }
  })
  return response.data
}

export const actualizarVenta = async (id: number, data: any) => {
  const token = localStorage.getItem('token')
  const response = await axios.put(`${API_URL}/api/Venta/${id}`, data, {
    headers: { Authorization: `Bearer ${token}` }
  })
  return response.data
}

export const eliminarVenta = async (id: number) => {
  const token = localStorage.getItem('token')
  await axios.delete(`${API_URL}/api/Venta/${id}`, {
    headers: { Authorization: `Bearer ${token}` }
  })
}