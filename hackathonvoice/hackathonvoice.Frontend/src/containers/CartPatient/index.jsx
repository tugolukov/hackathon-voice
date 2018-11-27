import React from 'react';
import connect from 'react-redux/es/connect/connect';
import Button from '@material-ui/core/Button';

const CartPatient = ({ resText }) => (
  <div className="main-content">
    <h1>Карта пациента</h1>
    <div className="cardPatient">
      <p>Пациент: </p>
      <p>Жалобы: </p>
      <hr />
      <p>Врач: </p>
      <p>Поставленный диагноз: </p>
      <hr />
      <p>Заключение: </p>
    </div>
    <div className="actions-button">
      <Button onClick={() => console.log('Кнопка Назад')} variant="outlined" color="primary">Назад</Button>
      <Button onClick={() => console.log('Кнопка Редактировать')} variant="outlined" color="primary">Редактировать</Button>
      <Button onClick={() => console.log('Кнопка Принять')} variant="outlined" color="primary">Принять</Button>
    </div>
  </div>
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
