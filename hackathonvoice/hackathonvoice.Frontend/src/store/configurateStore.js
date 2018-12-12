import axios from 'axios';
import { createStore, applyMiddleware } from 'redux';
import { persistStore } from 'redux-persist';
import thunk from 'redux-thunk';
import logger from 'redux-logger';
import { createBrowserHistory } from 'history';
import { connectRouter, routerMiddleware } from 'connected-react-router';

import rootReducer from './reducers';

const history = createBrowserHistory();

const api = axios.create({
  baseURL: '/api',
  headers: {
    'Content-Type': 'application/json',
  },
});

const observeStore = (store, select, onChange) => {
  let currentState;

  function handleChange() {
    const nextState = select(store.getState());
    if (nextState !== currentState) {
      currentState = nextState;
      onChange(currentState);
    }
  }
  handleChange();

  return store.subscribe(handleChange);
};

export default () => {
  const store = createStore(
    connectRouter(history)(rootReducer),
    applyMiddleware(thunk.withExtraArgument(api), logger, routerMiddleware(history)),
  );
  const persistor = persistStore(store);

  observeStore(
    store,
    state => state.auth.token,
    (accessToken) => {
      api.defaults.headers.common.Authorization = `Bearer ${accessToken}`;
    },
  );

  return { store, persistor, history };
};
