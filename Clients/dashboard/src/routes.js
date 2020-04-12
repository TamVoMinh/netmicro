import React from 'react';
import { Route, Switch, Redirect } from 'react-router-dom';
import DashboardLayout from 'layout/DashboardLayout';
import Dashboard from 'dashboard';
import Revenue from 'dashboard/revenue';
import Report from 'dashboard/report';
import UserInfo from 'auth/info';
import UserResetInfo from 'auth/resetPassword';
import Users from './user-management/index';
import User from 'auth';

const pages = [
    {
        path: '/',
        component: Dashboard
    },
    {
        path: '/dashboard',
        component: Dashboard
    },
    {
        path: '/report',
        component: Report
    },
    {
        path: '/revenue',
        component: Revenue
    },
    {
        path: '/users',
        component: Users
    },
    {
        path: '/user',
        component: User
    },
    {
        path: '/user/info',
        component: UserInfo
    },
    {
        path: '/user/reset',
        component: UserResetInfo
    }
];

function NestedRoute() {
    return (
        <DashboardLayout>
            <Switch>
                {pages.map(({ path, component }) => {
                    return <Route path={path} exact component={component} key={path} />;
                })}
                <Redirect to="/dashboard" />
            </Switch>
        </DashboardLayout>
    );
}

function AppRoutes() {
    return (
        <Switch>
            <Route path="/" component={NestedRoute} />
            <Redirect to="/dashboard" />
        </Switch>
    );
}

export default AppRoutes;
