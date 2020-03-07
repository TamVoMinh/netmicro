import { combineReducers } from 'redux';
import authReducer from '../auth/reducer';
import notifierReducer from '../notifier/reducer';

export default combineReducers({
    auth: authReducer,
    notifier: notifierReducer
});
