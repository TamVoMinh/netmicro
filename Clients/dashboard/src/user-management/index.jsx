import React, { useEffect } from 'react';
import { ApiService } from '../services/ApiService';
import ManageEntity from './ManageEntity';
import meta from './meta.json';

const Users = () => {
    const apiService = new ApiService();
    // useEffect(() => {
    //     apiService.get('users?email=&limit=50&offset=0');
    //     apiService.get('clients?clientName=&limit=50&offset=0');
    // }, []);

    const title = 'Hello Joy-UI';
    const props = {
        title,
        meta,
        form: <div />,
        useModal: true
        // subheader: <SubHeader title={title}></SubHeader>
    };

    return <ManageEntity {...props} />;
};

export default Users;
