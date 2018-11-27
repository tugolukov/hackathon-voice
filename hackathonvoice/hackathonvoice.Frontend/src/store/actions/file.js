import { push } from 'connected-react-router';
import { NotificationManager } from 'react-notifications';

export const LOAD_FILE_REQUEST = 'POST_FILE_REQUEST';
export const LOAD_FILE_SUCCESS = 'POST_FILE_SUCCESS';
export const LOAD_FILE_FAILURE = 'LOAD_FILE_FAILURE';

export function loadFile(file) {
  return async (dispatch, getState, api) => {
    try {
      const body = new FormData();

      body.append('file', file.blob);

      dispatch({ type: LOAD_FILE_REQUEST });
      const res = await api.post('send', body);

      dispatch({ type: LOAD_FILE_SUCCESS, payload: res.data });
      dispatch(push('/result'));
    } catch (error) {
      dispatch({ type: LOAD_FILE_FAILURE, payload: error.message });
      NotificationManager.error('Вы загрузили слишком большой файл. Попробуйте снова!', 'Ошибка', 3000);
    }
    return null;
  };
}

export function redirect() {
  return async (dispatch, getState, api) => {
    dispatch(push('/'));
  };
}
