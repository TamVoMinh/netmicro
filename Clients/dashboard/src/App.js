import React from 'react';
import AppRoutes from './routes';
import { HashRouter } from 'react-router-dom';
// import Notifier from 'notifier/Notifier';
import './App.scss';
function App() {
    return (
        <React.Fragment>
            {/* <Notifier /> */}
            <HashRouter>
                <AppRoutes />
            </HashRouter>
        </React.Fragment>
    );
}

export default App;
