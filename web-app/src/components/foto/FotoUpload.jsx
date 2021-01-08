import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import {
    Card,
    CardActions,
    CardMedia,
    IconButton,
    Link,
    Dialog
} from '@material-ui/core';
import AddPhotoAlternateIcon from '@material-ui/icons/AddPhotoAlternate';

const useStyles = makeStyles({
  root: {
    marginBottom: 30,
    maxWidth: 300,
    height: 300,
    boxShadow: '0px 5px 5px -3px rgba(0, 0, 0, 0.06), 0px 8px 10px 1px rgba(0, 0, 0, 0.042), 0px 3px 14px 2px rgba(0, 0, 0, 0.036)'
  },
  media: {
    height: 200,
    paddingTop: '56.25%', // 16:9
  },
  input: {
    display: 'none',
  },
  dialog: {
    boxShadow: '0px 5px 5px -3px rgba(0, 0, 0, 0.06), 0px 8px 10px 1px rgba(0, 0, 0, 0.042), 0px 3px 14px 2px rgba(0, 0, 0, 0.036)'
  }
});

const FotoUpload = (props) => {
  const classes = useStyles();

  const handleImagem = (file) => {
    let reader = new FileReader();

    reader.onload = (readerEvt) => {
      let imagem = btoa(readerEvt.target.result);
      props.uploadFoto(imagem);
      // props.uploadFoto('data:image/jpeg;base64,' + imagem);
    }

    reader.readAsBinaryString(file);
  }

  const handleOpenLogo = (e) => {
    e.preventDefault();

    props.setOpenLogo(true);
  }

  
  const foto = (props.foto === null || props.foto === undefined) ? "" : 'data:image/jpeg;base64,' + props.foto;

  return (
    <div>
    <Card className={classes.root}>
      <Link href="#" onClick={() => {}}>
        <CardMedia
           className={classes.media}
           image={foto}
        />
      </Link>
      <CardActions disableSpacing>
        
      </CardActions>
    </Card>
    <input
          accept="image/*"
          style={{ display: 'none' }}
          id="raised-button-file"
          multiple
          type="file"
        />
        <input accept="image/*" className={classes.input} onChange={(e) => handleImagem(e.target.files[0])} id="icon-button-file" type="file" />
        <label htmlFor="icon-button-file">
          <IconButton color="primary" aria-label="upload picture" component="span">
            <AddPhotoAlternateIcon />
          </IconButton>
        </label>
    </div>
  )
}

export default FotoUpload;