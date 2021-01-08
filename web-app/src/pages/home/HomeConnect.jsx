import {connect } from 'react-redux';
import {withRouter} from 'react-router-dom'
import HomeComponent from './components/HomeComponent';
import localStorageService from '../../services/localStorageService';

const mapStateToProps = (state) => ({
  isAuthenticated: localStorageService.getItem('jwt_token') !== null,
  token: localStorageService.getItem('jwt_token')
})
  
export default connect(mapStateToProps, {})(withRouter(HomeComponent));