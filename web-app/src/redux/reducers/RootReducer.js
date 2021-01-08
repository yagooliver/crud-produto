import { combineReducers } from "redux";
import LoginReducer from '../../pages/login/reducer/reducer';

const RootReducer = combineReducers({
  login: LoginReducer
});

export default RootReducer;