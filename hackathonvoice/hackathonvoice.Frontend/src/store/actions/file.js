import { push } from 'connected-react-router';

export const LOAD_FILE_REQUEST = 'POST_FILE_REQUEST';
export const LOAD_FILE_SUCCESS = 'POST_FILE_SUCCESS';
export const LOAD_FILE_FAILURE = 'LOAD_FILE_FAILURE';

export function loadFile(file) {
  console.log('FILE_AFTER', file);
  return async (dispatch, getState, api) => {
    try {
      const body = new FormData();

      body.append('file', file, 'rec');
      const data = {};

      body.forEach((value, key) => {
        data[key] = value;
      });
      console.log(data);

      dispatch({ type: LOAD_FILE_REQUEST });
      const res = await api.post('send', body);

      dispatch({ type: LOAD_FILE_SUCCESS, payload: res.data });
    } catch (error) {
      dispatch({ type: LOAD_FILE_FAILURE, payload: error.message });
    }
    return null;
  };
}
