import { Switch, Route, withRouter, Link } from 'react-router-dom';
import { bindActionCreators } from 'redux';
import { connect } from 'react-redux';

import { ManageEntity, ModalProvider, mapStateToProps } from 'joy-ui';
import { mapStateToPropsDefault, entityActions } from 'joy-ui/store';
import * as api from './api';

const actions = entityActions(api);

const mapDispatchToProps = (dispatch, ownProps) => {
    return bindActionCreators(actions, dispatch);
};

const ModalProviderWithRouter = connect(mapStateToProps, null)(withRouter(ModalProvider));

export default connect(mapStateToPropsDefault, mapDispatchToProps)(ManageEntity(Switch, Route, withRouter, Link));
export { ModalProviderWithRouter };
