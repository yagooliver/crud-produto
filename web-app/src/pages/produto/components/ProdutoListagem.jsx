import React from 'react';
import {
  IconButton,
  Button,
  Card,
  Grid,
  Typography,
  TablePagination
} from "@material-ui/core";
import EditIcon from '@material-ui/icons/Edit';
import DeleteIcon from '@material-ui/icons/Delete';
import MaterialTable from 'material-table';
import {tableIcons} from '../../../components/tabela/iconesTabela';

function AddZero(num){
  return (num >= 0 && num < 10) ? "0" + num : num + "";
}

function montaDateTime(date) {
  if(date === null || date === undefined || !date){
    return "";
  }
  var now = new Date(date);
  var strDateTime = [[AddZero(now.getDate()), 
      AddZero(now.getMonth() + 1), 
      now.getFullYear()].join("/"), 
      [AddZero(now.getHours()), 
      AddZero(now.getMinutes())].join(":"), 
      now.getHours() >= 12 ? "PM" : "AM"].join(" ");
  return strDateTime;
}

const ProdutoListagem = (props) => {
  const adicionaProdutoDialog = () => {
    props.setaEstadoModal(true);
  }

  const handleChangePage = (event, newPage) => {
    props.onChange(newPage);
  }

  const handleSelect = (id) => {
    props.retornaProduto(id);
  }

  const handleDeleta = (id) => {
    if(window.confirm("Deseja deletar o produto?")) {
      props.deletaProduto(id);
    }
  }

  return (
    <div className="m-sm-30">
      <div className="flex justify-between items-center">
        <Button
          className="mb-4"
          variant="contained"
          color="primary"
          onClick={adicionaProdutoDialog}
        >
          Adicionar Produto
        </Button>
      </div>
      <br/>
      <br/>
      <Card className="w-full overflow-auto" elevation={6}>
        <div className="p-12">
          <div className="mb-sm-30">
            <Grid className="mb-12" container spacing={2}>
              <Grid item sm={12} xs={12}>
               
              </Grid>
            </Grid>
          </div>
          <MaterialTable
            title={<Typography variant="h5" component="h2">Lista de produtos</Typography>}
            components={{
                Pagination: prop => (
                  <TablePagination
                    {...prop}
                    className="px-4"
                    rowsPerPageOptions={[25]}
                    count={props.total}
                    rowsPerPage={props.tamanho}
                    page={props.pagina}
                    backIconButtonProps={{
                      "aria-label": "Previous Page"
                    }}
                    nextIconButtonProps={{
                      "aria-label": "Next Page"
                    }}
                    onChangePage={handleChangePage}
                    // onChangeRowsPerPage={handleChangeRowsPerPage}
                    />
                  )
                }}
            options={{
              sorting: false,
              pageSize: props.tamanho,
              initialPage: props.pagina,
              emptyRowsWhenPaging: false
            }}
            icons={tableIcons}
            columns={[
              { title: '', field: 'imagem', render: rowData => rowData.imagem ? <img src={"data:image/jpeg;base64," + rowData.imagem} alt="foto" style={{ marginLeft: "5px", height:70, width: 70 }} /> : ''},
              { title: 'Nome', field: 'nome' },
              { title: 'Valor', field: 'valor'},
              { title: 'Data Criacao', field: 'dataCriacao', render: rowData => rowData.dataCriacao ? montaDateTime(rowData.dataCriacao) : ''},
              {
                title: '',
                field: 'acoes',
                render: rowData => (
                  <div>
                    <IconButton onClick={() => handleSelect(rowData.id)}>
                      <EditIcon color="primary"/>
                    </IconButton>
                    <IconButton onClick={() => handleDeleta(rowData.id)}>
                      <DeleteIcon color="error"/>
                    </IconButton>
                  </div>
                )
              }]}
            data={props.produtos}
          />
        </div>
      </Card>
    </div>
  )
}

export default ProdutoListagem;