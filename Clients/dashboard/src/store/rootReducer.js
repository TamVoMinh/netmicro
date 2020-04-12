import { combineReducers } from 'redux-immutable';
import { ui, entity } from 'joy-ui/store';
import authReducer from '../auth/reducer';
import notifierReducer from '../notifier/reducer';

export default combineReducers({
    auth: authReducer,
    notifier: notifierReducer,
    ui,
    entity
});
