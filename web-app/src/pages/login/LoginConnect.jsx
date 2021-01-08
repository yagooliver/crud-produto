import {connect} from 'react-redux';
import LoginContainer from './components/LoginContainer';
import {withRouter} from 'react-router-dom';
import {
  editingItem,
  submitLogin
} from './actions/actions';

const mapStateToProps = (state) => ({
  login: state.login.login,
  isSubmitting: state.login.isSubmitting,
  isAuthenticated: state.login.isAuthenticated
});

const mapDispatchToProps = (dispatch) => ({
  editingItem: (item) => dispatch(editingItem(item)),
  submitLogin: (item) => dispatch(submitLogin(item))
})

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(LoginContainer));