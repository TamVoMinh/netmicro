import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';
import * as serviceWorker from './serviceWorker';
import CssBaseline from '@material-ui/core/CssBaseline';
import { ThemeProvider } from '@material-ui/styles';
import Theme from './theme';
import { Provider } from 'react-redux';
import NotifierProvider from './notifier/NotifierProvider';
import { createMuiTheme } from '@material-ui/core/styles';
import configureStore from './store/configStore';

const theme = createMuiTheme(Theme);
theme.shadows[1] = '0 0 5px 0 rgba(0, 0, 0, 0.1)';

const store = configureStore();

const AppWrapper = () => {
    return (
        <React.Fragment>
            <CssBaseline />
            <Provider store={store}>
                <ThemeProvider theme={theme}>
                    {/* <NotifierProvider> */}
                    <App />
                    {/* </NotifierProvider> */}
                </ThemeProvider>
            </Provider>
        </React.Fragment>
    );
};

ReactDOM.render(<AppWrapper />, document.getElementById('root'));

// If you want your app to work offline and load faster, you can change
// unregister() to register() below. Note this comes with some pitfalls.
// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.unregister();
