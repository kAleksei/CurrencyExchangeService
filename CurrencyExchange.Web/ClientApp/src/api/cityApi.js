import axios from "../axios"

export const getCities = (filteringModel) => axios.get(`api/city/`, { params: filteringModel })