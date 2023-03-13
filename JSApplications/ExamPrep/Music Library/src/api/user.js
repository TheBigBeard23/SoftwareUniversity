import * as api from "./api.js"

const endpoints = {
    'login': 'users/login',
    'register': 'users/register',
    'logout': 'users/logout',
}

async function login(data) {
    const res = await api.post(endpoints.login, data);
    sessionStorage.setItem('user', JSON.stringify(res));
}
async function register({ email, password, _ }) {
    const res = await api.post(endpoints.register, { email, password });
    sessionStorage.setItem('user', JSON.stringify(res));
}
async function logout() {
    api.get(endpoints.logout);
    sessionStorage.removeItem('user');
}

export {
    login,
    register,
    logout
}