import React from 'react';
import Button from '@material-ui/core/Button';
import { makeStyles } from '@material-ui/core/styles';
import localStorageService from '../../services/localStorageService';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';

const useStyles = makeStyles(theme => ({
    '@global': {
      body: {
        backgroundColor: theme.palette.common.white,
      },
    },
    paper: {
      marginTop: theme.spacing(8),
      display: 'flex',
      flexDirection: 'column',
      alignItems: 'center',
    },
    avatar: {
      margin: theme.spacing(1),
      backgroundColor: theme.palette.secondary.main,
    },
    form: {
      width: '100%', // Fix IE 11 issue.
      marginTop: theme.spacing(1),
    },
    submit: {
      margin: theme.spacing(3, 0, 2),
    },
    menuButton: {
      marginRight: theme.spacing(2),
    },
    title: {
      flexGrow: 1,
      textAlign: "right",
      marginRight: "15px"
    },
    root: {
      flexGrow: 1,
    }
  }));

const AppBarComponent = () => {
    const classes = useStyles();

    const isLoggedIn = localStorageService.getItem("jwt_token") != null; 
    const logout = () => {
      localStorageService.removeItem("jwt_token");
      window.location.href = '/login';
    }

    return (
      <div className={classes.root}>
        <AppBar 
        position="static">
          <Toolbar>
            {isLoggedIn
                    ?
                    [
                      <Typography variant="h6" className={classes.title}>
                        Olá
                      </Typography>,
                      
                      <Button
                      variant="contained"
                      color="primary"
                      
                      onClick={logout}>
                          Logout
                      </Button>
                    ]
                    : <div/>}
          </Toolbar>
        </AppBar>
      </div>
    );
}

export default AppBarComponent;