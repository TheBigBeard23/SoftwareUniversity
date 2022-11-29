import { loadHome } from "./home.js";

export function logout() {
    localStorage.removeItem('user');
    loadHome();
}