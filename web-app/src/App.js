import React from 'react';
import { Store } from './redux/Store';
import { Provider } from 'react-redux';
import { Router} from 'react-router-dom'
import HomeConnect from './pages/home/HomeConnect';
import customHistory from './history';

const App = () => {
  return (
    <Provider store={Store}>
      <Router history={customHistory}>
        <HomeConnect/>
      </Router>
    </Provider>
  )
}

export default App;