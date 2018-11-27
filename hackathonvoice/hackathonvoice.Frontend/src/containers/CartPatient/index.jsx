import React from 'react';
import connect from 'react-redux/es/connect/connect';
import Button from '@material-ui/core/Button';

import { redirect } from '../../store/actions/file';

const CartPatient = ({ resText, actions }) => (
  <div className="main-content">
    <h1>Карта пациента</h1>
    <div className="cardPatient">
      <p>
        <span className="card-title">Пациент:</span>
        <span className="card-info">{resText.patientModel.fullName}</span>
      </p>
      <p>
        <span className="card-title">Жалобы:</span>
        <span className="card-info">{resText.visitModel.description}</span>
      </p>
      <p>
        <span className="card-title">Полис:</span>
        <span className="card-info">{resText.patientModel.policy}</span>
      </p>
      <hr />
      <p>
        <span className="card-title">Врач:</span>
        <span className="card-info">Иванов Иван</span>
      </p>
      <p>
        <span className="card-title">Поставленный диагноз:</span>
        <span className="card-info">{ resText.visitModel.diagnoses }</span>
      </p>
      <p>
        <span className="card-title">Заключение:</span>
        <span className="card-info">{ resText.visitModel.recipe }</span>
      </p>
    </div>
    <div className="actions-button">
      <Button onClick={actions.redirect} variant="contained" color="primary">Следующий пациент</Button>
    </div>
  </div>
);

const mapStateToProps = store => ({
  resText: store.file.resText,
});

const mapDispatchToProps = dispatch => ({
  actions: {
    redirect: () => dispatch(redirect()),
  },
});

export default connect(mapStateToProps, mapDispatchToProps)(CartPatient);
