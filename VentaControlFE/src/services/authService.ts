import axios from 'axios'

const API_URL = 'http://localhost:5135'

export const login = async (email: string, password: string) => {
  const response = await axios.post(`${API_URL}/api/Login/login`, {
    email,
    password
  })
  return response.data
}
export const registro = async (email: string, password: string,nombre: string, telefono: string) => {
  const response = await axios.post(`${API_URL}/api/Login/registro`, {
    email,
    password,
    nombre,
    telefono
  })
  return response.data
}
