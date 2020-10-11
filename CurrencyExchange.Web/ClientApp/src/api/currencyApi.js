import axios from "../axios"

export const getCurrencies = (filteringModel) => axios.get(`api/currency/`, { params: filteringModel })