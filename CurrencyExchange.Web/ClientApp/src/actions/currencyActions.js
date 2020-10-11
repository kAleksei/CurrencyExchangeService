import {getCurrencies} from "../api/currencyApi"

export const SET_CURRENCIES = "SET_CURRENCIES"

export const setCurrencies = (currencies) => ({
    type: SET_CURRENCIES,
    currencies
})

export function fetchCurrencies(filteringModel) {
    return (dispatch) => {
        return getCurrencies(filteringModel).then(response => {
            dispatch(setCurrencies(response.data))
            return response.data
        })

    }
}
