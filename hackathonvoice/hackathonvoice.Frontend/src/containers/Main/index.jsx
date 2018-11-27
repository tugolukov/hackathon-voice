import React from 'react';

import Rec from './Rec';
import InformationSteps from './InformationSteps';

class Main extends React.Component {
  render() {
    return (
      <div className="main-content-download">
        <Rec />
        <InformationSteps />
      </div>
    );
  }
}

export default Main;