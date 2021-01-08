import axios from 'axios';
import https from 'https';
import localStorageService from "./localStorageService";

const instance = axios.create({
  baseURL: `${process.env.REACT_APP_BASE_URL}/api`,
  timeout: 180000,
  headers: {
    'Content-Type': 'application/json',
    'Access-Control-Allow-Origin': '*',
    'Accept':  '*/*',
    common: {
       Authorization: `Bearer ${localStorageService.getItem("jwt_token")}`
    }
  },
  httpsAgent: new https.Agent({  
     rejectUnauthorized: false
  })
});

export default instance;