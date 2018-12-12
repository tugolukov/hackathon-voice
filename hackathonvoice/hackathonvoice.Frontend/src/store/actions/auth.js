import { push } from 'connected-react-router';

export const SIGN_IN_REQUEST = 'SIGN_IN_REQUEST';
export const SIGN_IN_SUCCESS = 'SIGN_IN_SUCCESS';

export const LOG_OUT_REQUEST = 'LOG_OUT_REQUEST';
export const LOG_OUT_SUCCESS = 'LOG_OUT_SUCCESS';

export function signIn({ login, password }) {
  return async (dispatch, getState, api) => {
    dispatch({ type: SIGN_IN_REQUEST });
    const res = await api.post('account/signin', { userName: login, password });

    dispatch({ type: SIGN_IN_SUCCESS, payload: res.data });
    dispatch(push('/'));
  };
}

export function logOut(user) {
  return (dispatch) => {
    dispatch({ type: LOG_OUT_SUCCESS, payload: user.userGuid });
  };
}
