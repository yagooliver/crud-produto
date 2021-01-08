import thunk from "redux-thunk";
import { createStore, applyMiddleware, compose } from "redux";
import logger from 'redux-logger'
import RootReducer from "./reducers/RootReducer";

let middlewares = []
let devtools = x => x;


if (
  process.env.NODE_ENV !== "production" &&
  process.browser &&
  window.__REDUX_DEVTOOLS_EXTENSION__
) {
  devtools = window.__REDUX_DEVTOOLS_EXTENSION__();
  middlewares = [...middlewares, thunk]
}else{
  middlewares = [...middlewares, thunk, logger]
}

export const Store = createStore(
  RootReducer,
  compose(applyMiddleware(...middlewares), devtools)
);