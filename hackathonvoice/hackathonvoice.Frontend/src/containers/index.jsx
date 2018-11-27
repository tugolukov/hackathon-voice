import React, { Fragment } from 'react';
import { Route, Switch } from 'react-router-dom';

import Main from './Main';
// import MedicalOpinion from './MedicalOpinion';

const Home = () => (
  <Switch>
    <Fragment>
      <Route path="/" exact component={Main} />
      {/* <Route exact path="/result/:guidOperation" component={MedicalOpinion} /> */}
    </Fragment>
  </Switch>
);

export default Home;
