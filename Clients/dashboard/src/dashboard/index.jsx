import React, { useEffect, useState } from 'react';
import Buttons from '../components/Buttons';
import AuthContent from '../components/AuthContent';
import { AuthService } from '../services/AuthService';
import { ApiService } from '../services/ApiService';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const Dashboard = () => {
    const authService = new AuthService();

    // state declare

    const [user, setUser] = useState({});
    const [api, setApi] = useState({});

    const apiService = new ApiService();
    const shouldCancel = false;

    const login = () => {
        authService.login();
    };

    const logout = () => {
        authService.logout();
    };

    const getUser = () => {
        console.log('getUser');
        authService.getUser().then((user) => {
            if (user) {
                setUser(user);

                toast.success('User has been successfully loaded from store.');
            } else {
                toast.info('You are not logged in.');
            }

            if (!shouldCancel) {
                setUser(user);
            }
        });
    };

    useEffect(() => {
        console.log('did mount or updated');

        getUser();

        return () => {
            console.log('will unmount');
        };
    }, []);

    return (
        <>
            <Buttons
                login={login}
                logout={logout}
                // renewToken={this.renewToken}
                // getUser={this.getUser}
                // callApi={this.callApi}
            />

            <AuthContent api={api} user={user} />
            <ToastContainer />
        </>
    );
};

export default Dashboard;
