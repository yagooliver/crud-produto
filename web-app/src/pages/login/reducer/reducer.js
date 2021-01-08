import * as types from '../actions/actionTypes';

const loginObj = {
  login: '',
  senha: ''
}

const initialState = {
  login: loginObj,
  isAuthenticated: false,
  isSubmitting: false
}

const LoginReducer = (state = initialState, action) => {
  switch(action.type){
    case types.INIT_COMPONENT: 
      return {
        ...initialState
      }
    case types.EDITING_ITEM:
      return {
        ...state,
        login: action.payload
      }
    case types.SUBMIT_LOGIN:
      return {
        ...state,
        isAuthenticated: action.payload.autenticado,
        isSubmitting: false
      }
    default: 
      return state;
  }
}

export default LoginReducer;