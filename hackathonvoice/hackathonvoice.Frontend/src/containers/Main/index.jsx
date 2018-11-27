import React, { Fragment } from 'react';
import { connect } from 'react-redux';

import Rec from './Rec';
import InformationSteps from './InformationSteps';
import { loadFile } from '../../store/actions/file';

class Main extends React.Component {
  handleOnStopRec = (recordedBlob) => {
    const { actions } = this.props;

    actions.loadFile(recordedBlob);
  };

  render() {
    const { isLoading } = this.props;

    return (
      <Fragment>
        <div className="main-content-download">
          <Rec isLoading={isLoading} handleOnStopRec={this.handleOnStopRec} />
          <InformationSteps />
        </div>
      </Fragment>
    );
  }
}

const mapStateToProps = store => ({
  isLoading: store.file.isLoading,
});

const mapDispatchToProps = dispatch => ({
  actions: {
    loadFile: file => dispatch(loadFile(file)),
  },
});

export default connect(mapStateToProps, mapDispatchToProps)(Main);
