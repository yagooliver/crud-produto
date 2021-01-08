import React from 'react';
import ProdutoListagem from './ProdutoListagem';
import ProdutoCadastro from './ProdutoCadastro';

class ProdutoContainer extends React.Component {
  componentDidMount(){
    this.props.retornaProdutos();
  }
  render(){
    return(
      <div style={{display: 'flex', justifyContent: 'center', alignItems: 'center'}}>
        <ProdutoListagem
          setaEstadoModal={this.props.setaEstadoModal}
          produtos={this.props.produtos}
          total={this.props.total}
          pagina={this.props.pagina}
          tamanho={this.props.tamanho}
          retornaProduto={this.props.retornaProduto}
          deletaProduto={this.props.deletaProduto}
        />
        {this.props.openModal && (
          <ProdutoCadastro
            produto={this.props.produto}
            setaEstadoModal={this.props.setaEstadoModal}
            atualizaProduto={this.props.atualizaProduto}
            insereProduto={this.props.insereProduto}
            editaForm={this.props.editaForm}
            open={this.props.openModal}
          />
        )}
      </div>
    )
  }
}

export default ProdutoContainer;