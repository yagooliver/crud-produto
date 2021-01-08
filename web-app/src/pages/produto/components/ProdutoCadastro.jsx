import React, {useRef} from 'react';
import {
  Dialog,
  Button,
  Grid,
  Typography
} from "@material-ui/core";
import { ValidatorForm, TextValidator } from "react-material-ui-form-validator";
import FotoUpload from '../../../components/foto/FotoUpload';
import CurrencyTextField from '@unicef/material-ui-currency-textfield'

const ProdutoCadastro = (props) => {
  const handleClose = () => {
    props.setaEstadoModal(false);
  }
  const handleSubmit = () => {
    if(props.produto.id){
      props.atualizaProduto(props.produto);
    }else{
      props.insereProduto(props.produto);
    }
  }
  const handleChange = (e) => {
    props.editaForm({
      ...props.produto,
      [e.target.name]: e.target.value
    });
  }
  const handleChangeValor = (e, valor) => {
    props.editaForm({
      ...props.produto,
      valor: valor
    });
  }
  const handleFoto = (foto) => {
    props.editaForm({
      ...props.produto,
      imagem: foto
    });
  }
  const inputRef = useRef("form");
  return (
    <Dialog onClose={() => {}} open={props.open} fullWidth disableBackdropClick>
      <div className="p-12">
      <div style={{padding: 50, width: '100%', justifyContent: 'center', alignItems: 'center', display: 'flex'}}>
        <ValidatorForm ref={inputRef} onSubmit={handleSubmit}>
          <div className="mb-sm-30">
            <Grid className="mb-12" container spacing={2}>
              <Grid item sm={12} xs={12}>
                {props.produto.id ? 
                (<Typography variant="h5" component="h2">
                  Editar Produto - {props.produto.id}
                </Typography>) : (
                <Typography variant="h5" component="h2">
                  Adicionar Produto
                </Typography>)}
              </Grid>
            </Grid>
          </div>
          <div className="mt-6">
            <FotoUpload
              uploadFoto={handleFoto}
              foto={props.produto.imagem}
            />
          </div>
          <Grid className="mb-12" container spacing={2}>
            <Grid item sm={12} xs={12}>
              <TextValidator
                className="w-full mb-12"
                label="Nome"
                type="text"
                name="nome"
                value={props.produto.nome}
                onChange={handleChange}
                validators={["required"]}
                errorMessages={['Nome do produto deve ser informado']}
              />
              <CurrencyTextField
                label="Valor"
                variant="standard"
                value={props.produto.valor}
                currencySymbol="R$"
                minimumValue="0"
                outputFormat="number"
                decimalCharacter="."
                digitGroupSeparator=","
                onChange={(event, value)=> handleChangeValor(event, value)}/>
            </Grid>
            <Grid item sm={12} xs={12}>
            <div className="flex justify-between items-center">
                <Button variant="contained" color="primary" type="submit">
                    Salvar
                </Button>
                <br/>
                <Button
                  variant="outlined"
                  color="secondary"
                  onClick={handleClose}
                >
                  Cancelar
                </Button>
              </div>
            </Grid>
          </Grid>
        </ValidatorForm>
          </div>
      </div>
    </Dialog>
  )
}

export default ProdutoCadastro;