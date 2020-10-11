import {getCities} from "../api/cityApi"

export const SET_CITIES = "SET_CITIES"

export const setCities = (cities) => ({
    type: SET_CITIES,
    cities
})

export function fetchCities(filteringModel) {
    return (dispatch) => {
        return getCities(filteringModel).then(response => {
            dispatch(setCities(response.data))
            return response.data
        })

    }
}