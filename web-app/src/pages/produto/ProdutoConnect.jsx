import {connect} from 'react-redux';
import ProdutoContainer from './components/ProdutoContainer';
import {withRouter} from 'react-router-dom';
import * as actions from './actions/actions';

const mapStateToProps = (state) => ({
  produtos: state.produto.produtos,
  openModal: state.produto.openModal,
  produto: state.produto.produto,
  total: state.produto.total,
  pagina: state.produto.pagina,
  tamanho: state.produto.tamanho
});

const mapDispatchToProps = (dispatch) => ({
  editaForm : (item) => dispatch(actions.editaProdutoForm(item)),
  retornaProdutos : () => dispatch(actions.retornaProdutos()),
  retornaProduto : (id) => dispatch(actions.retornaProduto(id)),
  insereProduto : (produto) => dispatch(actions.insereProduto(produto)),
  atualizaProduto : (produto) => dispatch(actions.atualizaProduto(produto)),
  deletaProduto : (id) => dispatch(actions.deletaProduto(id)),
  setaEstadoModal : (status) => dispatch(actions.setaEstadoModal(status))
})

export default withRouter(connect(mapStateToProps, mapDispatchToProps)(ProdutoContainer));