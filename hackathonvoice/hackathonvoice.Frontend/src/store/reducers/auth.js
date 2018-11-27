import { SIGN_IN_SUCCESS, LOG_OUT_SUCCESS } from '../actions/auth';

const initialState = {
  isAuth: false,
  token: null,
};

export default (state = initialState, action) => {
  switch (action.type) {
    case SIGN_IN_SUCCESS:
      return {
        ...action.payload,
        isAuth: true,
      };
    case LOG_OUT_SUCCESS:
      return {};
    default:
      return state;
  }
};
