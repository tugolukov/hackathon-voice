import {
  LOAD_FILE_REQUEST,
  LOAD_FILE_SUCCESS,
  LOAD_FILE_FAILURE,
  CALCULATE_FILES_REQUEST,
  CALCULATE_FILES_SUCCESS,
  CALCULATE_FILES_FAILURE,
} from '../actions/file';

const initialState = {
  uploadFilesGuid: [],
  isLoading: false,
  errorMessage: null,
  operationGuid: null,
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
        uploadFilesGuid: _.concat(state.uploadFilesGuid, action.payload),
        isLoading: false,
      };
    case LOAD_FILE_FAILURE:
      return {
        ...state,
        errorMessage: action.payload,
        isLoading: false,
      };
    case CALCULATE_FILES_SUCCESS:
      return {
        ...state,
        operationGuid: action.payload,
      };
    default:
      return state;
  }
};
