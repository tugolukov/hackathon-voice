export const GET_RESULT_REQUEST = 'GET_RESULT_REQUEST';
export const GET_RESULT_SUCCESS = 'GET_RESULT_SUCCESS';
export const GET_RESULT_FAILURE = 'GET_RESULT_FAILURE';

export function getResult(operationGuid) {
  return async (dispatch, getState, api) => {
    try {
      dispatch({ type: GET_RESULT_REQUEST });
      const res = await api.get(
        'files/result',
        {
          params: {
            operationGuid,
          },
        },
      );

      dispatch({ type: GET_RESULT_SUCCESS, payload: res.data });
    } catch (error) {
      dispatch({ type: GET_RESULT_FAILURE, payload: error.message });
    }
    return null;
  };
}

// dispatch(push(`/result/${res.data}`));
