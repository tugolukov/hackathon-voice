import React from 'react';
import Button from '@material-ui/core/Button';

import { ReactMic } from 'react-mic';

class Ric extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      record: false,
    };
  }

  handleToRecording = () => {
    const { record } = this.state;

    this.setState({
      record: !record,
    });
  };

  onData = (recordedBlob) => {
    console.log('chunk of real-time data is: ', recordedBlob);
  };

  onStop = (recordedBlob) => {
    console.log('recordedBlob is: ', recordedBlob);
  };

  render() {
    const { record } = this.state;

    return (
      <div className="rec-container">
        <ReactMic
          record={record}
          className="sound-wave"
          onStop={this.onStop}
          onData={this.onData}
          audioBitsPerSecond={128000}
          height={100}
          strokeColor="rgb(0, 150, 239)"
          backgroundColor="rgb(33, 33, 33)"
        />
        <Button variant="fab" className={`record ${record ? 'record-true' : 'record-false'}`} onClick={this.handleToRecording} aria-label="Rec">
          <i className="fas fa-microphone fa-7x" />
        </Button>
      </div>
    );
  }
}

export default Ric;
