
import React from 'react';
import {Switch, Route, Redirect} from 'react-router-dom'
import LoginConnect from '../pages/login/LoginConnect';
import localStorageService from '../services/localStorageService';
import ProdutoConnect from '../pages/produto/ProdutoConnect';

const checkAuth = () => {
    if(localStorageService.getItem('jwt_token') !== null){
    return true;
  }else{
    return false;
  }
}

export const Routes = (props) => {
  return (
    <Switch>
      <Route exact path="/" render={(props) => (
          !checkAuth() ? (
              <Redirect to="/login"/> 
              ) : 
              (<ProdutoConnect/>))} /> 
      <Route path="/home" component={ProdutoConnect}/>
      <Route path="/login" component={LoginConnect}/>
    </Switch>
  )
}