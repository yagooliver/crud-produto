import { combineReducers } from "redux";
import LoginReducer from '../../pages/login/reducer/reducer';
import ProdutoReducer from '../../pages/produto/reducer/reducer';

const RootReducer = combineReducers({
  login: LoginReducer,
  produto: ProdutoReducer
});

export default RootReducer;