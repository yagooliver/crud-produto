import React from 'react';
import LoginComponent from './LoginComponent';
import localStorageService from '../../../services/localStorageService';

class LoginContainer extends React.Component {
  render(){
    if(localStorageService.getItem("jwt_token") !== null){
      window.location.href = "/home";
    }
    return (
      <div>
        <LoginComponent
          login={this.props.login}
          onChange={this.props.editingItem}
          onSubmit={this.props.submitLogin}
          isSubmitting={this.props.isSubmitting}
          isAuthenticated={this.props.isAuthenticated}
        />
      </div>
    )
  }
}

export default LoginContainer;