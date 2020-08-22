/* eslint-disable no-unused-vars */
import { createStore, applyMiddleware, compose } from 'redux';
import thunk from 'redux-thunk';
import rootReducer from './rootReducer';

const isProduction = process.env.NODE_ENV === 'production';

let composeFn = null;
// if (isProduction) {
//     composeFn = compose;
// } else {
    const devTools = require('redux-devtools-extension');
    composeFn = devTools.composeWithDevTools;
    //composeFn = compose;
// }
const store = createStore(
    rootReducer,
    composeFn(applyMiddleware(thunk))
);

export default store;
