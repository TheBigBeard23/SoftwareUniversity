import page from "../node_modules/page/page.mjs"
import { catalogView } from "./views/catalog.js";
import { createView } from "./views/create.js";
import { detailsView } from "./views/details.js";
import { loginView } from "./views/login.js";
import { logout } from "./views/logout.js";
import { myPublicationsView } from "./views/myPublication.js";
import { registerView } from "./views/register.js";

page('/login', loginView);
page('/catalog', catalogView);
page('/myPublications', myPublicationsView);
page('/register', registerView);
page('/create', createView);
page('/details/:detailsId', detailsView)

document.getElementById('logoutBtn').addEventListener('click', logout);

export const updateInfo = () => {
    let userDiv = document.getElementById('user');
    let guestDiv = document.getElementById('guest');

    if (localStorage.length == 0) {
        userDiv.style.display = 'none';
        guestDiv.style.display = 'inline';
    }
    else {
        userDiv.style.display = 'inline';
        guestDiv.style.display = 'none';
    }
}

updateInfo();
page.start();
