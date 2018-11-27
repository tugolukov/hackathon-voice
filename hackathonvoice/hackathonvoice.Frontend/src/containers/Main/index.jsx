import React from 'react';
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
    return (
      <div className="main-content-download">
        <Rec handleOnStopRec={this.handleOnStopRec} />
        <InformationSteps />
      </div>
    );
  }
}

// const mapStateToProps = store => ({
//   isLoading: store.file.isLoading,
//   uploadFilesGuid: store.file.uploadFilesGuid,
// });

const mapDispatchToProps = dispatch => ({
  actions: {
    loadFile: file => dispatch(loadFile(file)),
  },
});

export default connect(null, mapDispatchToProps)(Main);
