import * as React from 'react';
import { Button } from '@material-ui/core';

interface IButtonsProps {
    login: () => void;
    // getUser: () => void;
    // callApi: () => void;
    // renewToken: () => void;
    logout: () => void;
}

const Buttons: React.SFC<IButtonsProps> = (props) => {
    return (
        <div className="row">
            <div className="col-md-12 text-center" style={{ marginTop: '30px' }}>
                <Button color="primary" style={{ margin: '10px' }} onClick={props.login}>
                    Login
                </Button>
                {/* <button className="btn btn-secondary btn-getuser" style={{ margin: '10px' }} onClick={props.getUser}>
          Get User info
        </button>
        <button className="btn btn-warning btn-getapi" style={{ margin: '10px' }} onClick={props.callApi}>
          Call API
        </button>
        <button className="btn btn-success btn-renewtoken" style={{ margin: '10px' }} onClick={props.renewToken}>
          Renew Token
        </button> */}
                <Button color="secondary" style={{ margin: '10px' }} onClick={props.logout}>
                    Logout
                </Button>
            </div>
        </div>
    );
};

export default Buttons;
