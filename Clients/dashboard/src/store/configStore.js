/* eslint-disable no-unused-vars */
import { createStore, applyMiddleware, compose } from 'redux';
import thunk from 'redux-thunk';
import { middlewares } from 'joy-ui/store';
import rootReducer from './rootReducer';
const isProduction = process.env.NODE_ENV === 'production';

let composeFn = null;
if (isProduction) {
    composeFn = compose;
} else {
    const devTools = require('redux-devtools-extension');
    composeFn = devTools.composeWithDevTools;
}

const configureStore = (preloadedState) => {
    const store = createStore(
        rootReducer,
        preloadedState,
        composeFn(applyMiddleware(middlewares.errorhandler, middlewares.optimistic, thunk))
    );
    return store;
};

export default configureStore;
