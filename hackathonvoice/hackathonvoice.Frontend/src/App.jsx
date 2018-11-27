import React, { Fragment } from 'react';
import { Route, Switch } from 'react-router-dom';
import { Provider } from 'react-redux';
import { PersistGate } from 'redux-persist/integration/react';
import CssBaseline from '@material-ui/core/CssBaseline/CssBaseline';
import { ConnectedRouter } from 'connected-react-router';
import { create } from 'jss';
import JssProvider from 'react-jss/lib/JssProvider';
import {
  createGenerateClassName,
  createMuiTheme,
  jssPreset,
  MuiThemeProvider,
} from '@material-ui/core/styles';
import 'react-notifications/lib/notifications.css';
import { NotificationContainer } from 'react-notifications';

import Main from './containers';
// import Home from './containers/Home';
import configurateStore from './store/configurateStore';
import './fonts/Roboto/style.css';

const styleNode = document.createComment('insertion-point-jss');
document.head.insertBefore(styleNode, document.head.firstChild);

const generateClassName = createGenerateClassName();
const jss = create(jssPreset());
jss.options.insertionPoint = 'insertion-point-jss';

const { store, persistor, history } = configurateStore();
const theme = createMuiTheme({
  typography: {
    useNextVariants: true,
  },
});

const App = () => (
  <JssProvider jss={jss} generateClassName={generateClassName}>
    <MuiThemeProvider theme={theme}>
      <Provider store={store}>
        <PersistGate persistor={persistor}>
          <ConnectedRouter history={history}>
            <Fragment>
              <CssBaseline />
              <Switch>
                <Route path="/" component={Main} />
              </Switch>
              <NotificationContainer />
            </Fragment>
          </ConnectedRouter>
        </PersistGate>
      </Provider>
    </MuiThemeProvider>
  </JssProvider>
);

export default App;
