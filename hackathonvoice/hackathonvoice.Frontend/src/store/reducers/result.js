import { GET_RESULT_REQUEST, GET_RESULT_SUCCESS, GET_RESULT_FAILURE } from '../actions/result';

const initialState = {
  data: null,
};

export default (state = initialState, action) => {
  switch (action.type) {
    case GET_RESULT_REQUEST:
      return state;
    case GET_RESULT_SUCCESS:
      return {
        data: action.payload,
      };
    default:
      return state;
  }
};
