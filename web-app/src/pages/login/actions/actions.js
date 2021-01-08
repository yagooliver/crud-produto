
import * as types from './actionTypes';
import instance from '../../../services/api';
import localStorageService from '../../../services/localStorageService';

export const editingItem = (item) => dispatch => {
  dispatch({
    type: types.EDITING_ITEM,
    payload: item
  });
}

export const submitLogin = (item) => dispatch => {
  instance.post("/login", {login: item.login, senha: item.senha}).then(res => {
    localStorageService.setItem("jwt_token", res.data.data.token);
    dispatch({
      type: types.SUBMIT_LOGIN,
      payload: res.data.data
    });
  });
}