import qs from 'qs';
const API_URL = 'http://api.nmro.local/iam';
const DEFAULT_OPTIONS = {
    method: 'GET',
    headers: {}
};
const DEFAULT_HEADERS = {
    Accept: 'application/json',
    'Content-Type': 'application/json'
};
export default ask;
export function ask({ path = '/', queries = {}, options = {}, host = API_URL, serviceURI = '' } = {}) {
    const queryString = qs.stringify(queries, { allowDots: true });
    const requestURL = `${host}${serviceURI}${path}${queryString.length ? `?${queryString}` : ''}`;

    const headers = {
        ...DEFAULT_HEADERS,
        ...options.headers
    };
    const requestOptions = { ...DEFAULT_OPTIONS, ...options, headers };

    return fetch(requestURL, requestOptions).then((res) => (res.ok ? handlers.success(res) : handlers.error(res)));
}

const handlers = {
    success: (response) => {
        const ctype = response.headers.get('Content-Type');
        return response.status === 200 && ctype.includes('application/json') ? response.json() : response.text();
    },
    error: (response) => {
        throw response.json();
    }
};
