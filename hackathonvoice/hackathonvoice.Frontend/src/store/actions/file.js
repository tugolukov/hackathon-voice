import { push } from 'connected-react-router';

export const LOAD_FILE_REQUEST = 'POST_FILE_REQUEST';
export const LOAD_FILE_SUCCESS = 'POST_FILE_SUCCESS';
export const LOAD_FILE_FAILURE = 'LOAD_FILE_FAILURE';

export const CALCULATE_FILES_REQUEST = 'CALCULATE_FILES_REQUEST';
export const CALCULATE_FILES_SUCCESS = 'CALCULATE_FILES_SUCCESS';
export const CALCULATE_FILES_FAILURE = 'CALCULATE_FILES_FAILURE';

export function loadFile(file) {
  return async (dispatch, getState, api) => {
    try {
      const body = new FormData();

      body.append('file', file, file.name);
      dispatch({ type: LOAD_FILE_REQUEST });
      const res = await api.post('files/upload', body);

      dispatch({ type: LOAD_FILE_SUCCESS, payload: res.data });
    } catch (error) {
      dispatch({ type: LOAD_FILE_FAILURE, payload: error.message });
    }
    return null;
  };
}

export function calculateFiles(uploadFilesGuid) {
  return async (dispatch, getState, api) => {
    try {
      dispatch({ type: CALCULATE_FILES_REQUEST });
      const res = await api.post('files/done', uploadFilesGuid);

      dispatch({ type: CALCULATE_FILES_SUCCESS, payload: res.data });
      dispatch(push(`/result/${res.data}`));
    } catch (error) {
      dispatch({ type: CALCULATE_FILES_FAILURE, payload: error.message });
    }
  };
}
