import React, { Fragment } from 'react';
import { Route, Switch } from 'react-router-dom';
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';

import Main from './Main';
import CartPatient from './CartPatient';

const Home = () => (
  <Fragment>
    <AppBar className="header" position="static">
      <Toolbar className="header">
        <Typography variant="h6" color="inherit">
            VOX SONATOR
        </Typography>
        <p style={{ textAlign: 'left' }}>
            Прототип
        </p>
      </Toolbar>
    </AppBar>
    <Switch>
      <Fragment>
        <Route path="/" exact component={Main} />
        <Route exact path="/result" component={CartPatient} />
      </Fragment>
    </Switch>
    <div className="footer">
      COPYRIGHT 2018 ALPHARD
    </div>
  </Fragment>
);

export default Home;
