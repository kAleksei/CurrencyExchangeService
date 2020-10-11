import updateObject from "../utility/objectUtility"
import * as actions from "../actions/currencyActions"
import moment from "moment"

const initialState = {
    currencies: []
}

const setCurrencies = (state, currencies) => {
    const newCurrencies = currencies.map(currency => updateObject(currency, {
        rate: currency.rate.toFixed(3),
        lastUpdate: moment(currency.lastUpdate).format("DD/MM HH:mm")
    }))
    return updateObject(state, {
        currencies: newCurrencies
    })
}

function currencyReducer(state = initialState, action) {
    switch (action.type) {
        case actions.SET_CURRENCIES:
            return setCurrencies(state, action.currencies)
        default:
            return state
    }
}

export default currencyReducer