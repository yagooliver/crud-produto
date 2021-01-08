import * as types from './actionTypes';
import instance from '../../../services/api';

export const editaProdutoForm = (item) => dispatch => {
  dispatch({
    type: types.SET_FORM,
    payload: item
  });
}

export const retornaProdutos = () => dispatch => {
  instance.get("/produto").then((res) => {
    dispatch({
      type: types.GET_PRODUTOS,
      payload: res.data.data
    });
  });
}

export const retornaProduto = (id) => dispatch => {
  instance.get(`/produto/${id}`).then((res) => {
    dispatch({
      type: types.GET_PRODUTOS_BY_ID,
      payload: res.data.data
    });
  })  
}

export const insereProduto = (produto) => dispatch => {
  instance.post("/produto",produto).then((res) => {
    dispatch({
      type: types.POST_PRODUTO,
      payload: res.data.data
    });
  });
}

export const atualizaProduto = (produto) => dispatch => {
  instance.put("/produto",produto).then((res) => {
    dispatch({
      type: types.PUT_PRODUTO,
      payload: res.data.data
    });
  });
}

export const deletaProduto = (id) => dispatch => {
  instance.delete(`/produto/${id}`).then((res) => {
    dispatch({
      type: types.DELETE_PRODUTO,
      payload: res.data.data
    });
  });
}

export const setaEstadoModal = (status) => dispatch => {
  dispatch({
    type: types.SET_EDIT_DIALOG_STATE,
    payload: status
  })
}

export const alteraPagina = () => dispatch => {

}