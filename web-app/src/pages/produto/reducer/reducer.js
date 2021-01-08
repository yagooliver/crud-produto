import * as types from '../actions/actionTypes';

const produtoObj = {
  id: '',
  nome: '',
  valor: 0.00,
  imagem: ''
}

const initialState = {
  produto: produtoObj,
  openModal: false,
  produtos: [],
  tamanho: 25,
  pagina: 0,
  total: 0
}

const ProdutoReducer = (state = initialState, action) => {
  switch(action.type){
    case types.SET_FORM:
      return {
        ...state, 
        produto: action.payload
      }
    case types.GET_PRODUTOS:
      return {
        ...state,
        total: action.payload.length,
        produtos: action.payload
      }
    case types.GET_PRODUTOS_BY_ID:
      return {
        ...state,
        produto: action.payload,
        openModal: true
      }
    case types.POST_PRODUTO:
      let lista = state.produtos;
      lista.push(action.payload);
      return {
        ...state,
        produtos: lista,
        produto: produtoObj,
        openModal: false
      }
    case types.PUT_PRODUTO:
      let listagem = state.produtos.map((it) => {
        console.log(it);
        console.log(state.produto.id)
        if(it.id === state.produto.id){
          return state.produto;
        }else{
          return it;
        }
      });
      return {
        ...state,
        produtos: listagem,
        produto: produtoObj,
        openModal: false
      }
    case types.DELETE_PRODUTO:
      let list = state.produtos.filter((it) => it.id !== action.payload);
      return {
        ...state,
        produtos: list
      }
    case types.SET_EDIT_DIALOG_STATE:
      return {
        ...state,
        produto: produtoObj,
        openModal: action.payload
      }
    default: 
      return state;
  }
}

export default ProdutoReducer;