import ask from './ask';
export const findAll = (entityPath, queries) => {
    return ask({
        path: entityPath,
        queries
    });
};

export const createEntity = (entityPath, data) => {
    return ask({
        path: entityPath,
        options: {
            method: 'POST',
            body: JSON.stringify(data)
        }
    });
};

export const updateEntity = (entityPath, fields, conditions) => {
    return ask({
        path: `${entityPath}/${conditions.id}`,
        options: {
            method: 'PUT',
            body: JSON.stringify({ fields, conditions })
        }
    });
};

export const deleteEntity = (entityPath, data) => {
    return ask({
        path: `${entityPath}/${data.id}`,
        options: { method: 'DELETE' }
    });
};

export const getEntity = (entityPath, id) => {
    return ask({
        path: `${entityPath}/${id}`,
        options: { method: 'GET' }
    });
};
