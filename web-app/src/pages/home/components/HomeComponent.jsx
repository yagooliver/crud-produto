import React from 'react';
import {Routes} from '../../../routes/index';
import { HashRouter } from "react-router-dom";
import AppBarComponent from '../../../components/app-bar/AppBarComponent';

class HomeComponent extends React.Component {
  checkAuth = () => {
    if(this.props.isAuthenticated){
      return true;
    }else{
      return false;
    }
  }
  render(){
  return (
    <div>
      {this.checkAuth() && (
        <AppBarComponent
        />
      )}
      
    <HashRouter>
      <div style={{minHeight: '100%'}}>
        <div className="wrapper-container">
          <div id="breadcrumb"></div>
          <div style={{marginBottom: '30', marginTop: 50}}>
            <Routes isAuthenticated={this.props.isAuthenticated}/>
          </div>
        </div>
          <footer
            className="footer-bar">
            <div style={{marginTop: '20px', justifyContent: 'center', alignContent: 'center', display: 'flex'}}>
              <strong>
                <p>
                  SiteMercado
                </p>
              </strong>
            </div>
          </footer>
        </div>
      </HashRouter>
    </div>
  )
  }
}

export default HomeComponent;