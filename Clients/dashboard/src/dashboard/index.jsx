import React, { useEffect, useState } from 'react';
import Buttons from '../components/Buttons';
import AuthContent from '../components/AuthContent';
import { AuthService } from '../services/AuthService';
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';

const Dashboard = () => {
    const authService = new AuthService();

    // state declare

    const [user, setUser] = useState({});

    const login = () => {
        console.log('login');
        authService.login();
    };

    const logout = () => {
        authService.logout();
    };

    const getUser = () => {
        console.log('getUser');
        authService
            .getUser()
            .then((userData) => {
                if (userData) {
                    setUser(userData);
                } else {
                    toast.info('You are not logged in.');
                }
            })
            .catch((error) => {
                console.log(error);
            });
    };

    useEffect(() => {
        console.log('did mount or updated');
        getUser();
    }, []);

    return (
        <>
            <div>Dashboard</div>
            <ToastContainer />
        </>
    );
};

export default Dashboard;
