import {
  LOAD_FILE_REQUEST,
  LOAD_FILE_SUCCESS,
  LOAD_FILE_FAILURE,
} from '../actions/file';

const initialState = {
  resText: null,
  isLoading: false,
  errorMessage: null,
};

export default (state = initialState, action) => {
  switch (action.type) {
    case LOAD_FILE_REQUEST:
      return {
        ...state,
        isLoading: true,
      };
    case LOAD_FILE_SUCCESS:
      return {
        ...state,
        resText: action.payload,
        isLoading: false,
      };
    case LOAD_FILE_FAILURE:
      return {
        ...state,
        errorMessage: action.payload,
        isLoading: false,
      };
    default:
      return state;
  }
};
