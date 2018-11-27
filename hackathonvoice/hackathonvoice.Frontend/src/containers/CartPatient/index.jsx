import React from 'react';
import connect from 'react-redux/es/connect/connect';
import Button from '@material-ui/core/Button';

import { redirect } from '../../store/actions/file';

const CartPatient = ({ resText, actions }) => (
  <div className="main-content">
    <h1>Карта пациента</h1>
    <div className="cardPatient">
      <p>
        Пациент:
        {resText.patientModel.fullName}
      </p>
      <p>
        Жалобы:
        {resText.visitModel.description}
      </p>
      <p>
        Полис:
        {resText.patientModel.policy}
      </p>
      <hr />
      <p>Врач: Иванов Иван</p>
      <p>
        Поставленный диагноз:
        { resText.visitModel.diagnoses }
      </p>
      <p>
        Заключение:
        { resText.visitModel.recipe }
      </p>
    </div>
    <div className="actions-button">
      <Button onClick={actions.redirect} variant="outlined" color="primary">Назад</Button>
      <Button onClick={() => console.log('Кнопка Редактировать')} variant="outlined" color="primary">Редактировать</Button>
      <Button onClick={() => console.log('Кнопка Принять')} variant="outlined" color="primary">Принять</Button>
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
