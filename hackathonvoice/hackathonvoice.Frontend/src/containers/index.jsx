import React, { Fragment } from 'react';
import { Route, Switch } from 'react-router-dom';

import Main from './Main';
import CartPatient from './CartPatient';

const Home = () => (
  <Fragment>
    <div className="header">
      Logo
    </div>
    <Switch>
      <Fragment>
        <Route path="/" exact component={Main} />
        <Route exact path="/result" component={CartPatient} />
      </Fragment>
    </Switch>
    <div className="footer">
      Footer
    </div>
  </Fragment>
);

export default Home;
