import { loadCreate } from "./create.js";
import { loadHome } from "./home.js";
import { loadLogin } from "./login.js";
import { logout } from "./logout.js";
import { loadRegister } from "./register.js";

window.addEventListener('load', loadHome);

document.querySelector('nav').addEventListener('click', onNavigate);
document.querySelector('#add-movie-button').addEventListener('click', onNavigate);


const routes = {
    '/': loadHome,
    '/login': loadLogin,
    '/register': loadRegister,
    '/create': loadCreate,
    '/logout': logout
}


function onNavigate(event) {
    if (event.target.tagName == 'A' && event.target.href) {
        event.preventDefault();
        const url = new URL(event.target.href);

        const view = routes[url.pathname];
        if (typeof view == 'function') {
            view();
        }
    }
}