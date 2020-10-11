import axios, { AxiosRequestConfig } from "axios"

const instance = axios.create({
});

export const axiosPromise = (configure: AxiosRequestConfig) => instance.request(configure)

export default instance
