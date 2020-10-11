import updateObject from "../utility/objectUtility"
import * as actions from "../actions/cityActions"
const initialState = {
    cities: []
}

function cityReducer(state = initialState, action) {
    switch (action.type) {
        case actions.SET_CITIES: 
            return updateObject(state, {cities: action.cities})
        default:
            return state
    }
}

export default cityReducer
