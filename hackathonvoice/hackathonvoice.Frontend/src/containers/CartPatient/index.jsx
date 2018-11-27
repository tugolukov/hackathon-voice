import React from 'react';
import connect from 'react-redux/es/connect/connect';

const CartPatient = ({ resText }) => (
  <h1>Карта пациента</h1>
);

const mapStateToProps = store => ({
  resText: store.file.resText,
});

// const mapDispatchToProps = dispatch => ({
//   actions: {
//     loadFile: file => dispatch(editCard(file)),
//   },
// });

export default connect(mapStateToProps, null)(CartPatient);
