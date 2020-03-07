import * as types from './types';
import React from 'react';
import { CloseOutlined as CloseIcon } from '@material-ui/icons';
import store from '../store/configStore';

const { dispatch } = store;

const AUTO_HIDE_DURATION = 3000;

export const enqueueSnackbar = ({
    message,
    type,
    duration = AUTO_HIDE_DURATION,
    action = key => (
        <CloseIcon
            style={{
                cursor: 'pointer',
                fontSize: 20,
                opacity: 0.8
            }}
            onClick={() => dispatch(closeSnackbar(key))}
        />
    )
}) => {
    return function(dispatch) {
        dispatch(
            enqueue({
                message,
                options: {
                    key: new Date().getTime() + Math.random(),
                    variant: type,
                    action,
                    autoHideDuration: duration
                }
            })
        );
    };
};

export const enqueue = notification => {
    const key = notification.options && notification.options.key;

    return {
        type: types.ENQUEUE_SNACKBAR,
        notification: {
            ...notification,
            key: key || new Date().getTime() + Math.random()
        }
    };
};

export const closeSnackbar = key => ({
    type: types.CLOSE_SNACKBAR,
    dismissAll: !key, // dismiss all if no key has been defined
    key
});

export const removeSnackbar = key => ({
    type: types.REMOVE_SNACKBAR,
    key
});
