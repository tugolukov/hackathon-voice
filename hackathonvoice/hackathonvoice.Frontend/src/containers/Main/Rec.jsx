import React from 'react';
import Button from '@material-ui/core/Button';

import { ReactMic } from 'react-mic';
import CircularProgress from '@material-ui/core/CircularProgress/CircularProgress';

class Ric extends React.Component {
  state = {
    record: false,
  };

  handleToRecording = () => {
    const { record } = this.state;

    this.setState({
      record: !record,
    });
  };

  render() {
    const { record } = this.state;
    const { handleOnStopRec, isLoading } = this.props;

    return (
      <div className="rec-container">
        <ReactMic
          record={record}
          className="sound-wave"
          onStop={handleOnStopRec}
          audioBitsPerSecond={128000}
          height={100}
          strokeColor="rgb(0, 150, 239)"
          backgroundColor="rgb(33, 33, 33)"
        />
        <Button variant="fab" disabled={isLoading} className={`record ${record ? 'record-true' : 'record-false'}`} onClick={this.handleToRecording} aria-label="Rec">
          {
            isLoading
              ? (
                <CircularProgress
                  style={{
                    width: '100px',
                    height: '100px',
                    color: 'wheat',
                  }}
                />
              )
              : (<i className="fas fa-microphone fa-7x" />)
          }
        </Button>
      </div>
    );
  }
}

export default Ric;
