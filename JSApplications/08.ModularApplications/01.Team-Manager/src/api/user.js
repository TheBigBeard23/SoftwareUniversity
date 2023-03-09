import * as api from "./api.js";

const endpoint = {
    'login': 'users/login',
    'register': 'users/register',
    'logout': 'users/logout',
}

export async function login(data) {
    try {
        const user = await api.post(endpoint.login, data);
        sessionStorage.setItem('user', JSON.stringify(user));
    } catch (err) {
        throw err;
    }
}

export async function register({ email, username, password, _ }) {

    const user = await api.post(endpoint.register, { email, password });
    user.username = username;
    sessionStorage.setItem('user', JSON.stringify(user));
}

export async function logout() {
    api.get(endpoint.logout);
    sessionStorage.removeItem('user');
}