import {connect} from 'react-redux';
import ProdutoContainer from './components/ProdutoContainer';
import {withRouter} from 'react-router-dom';

const mapStateToProps = (state) => ({

});

export default withRouter(connect(mapStateToProps, {})(ProdutoContainer));