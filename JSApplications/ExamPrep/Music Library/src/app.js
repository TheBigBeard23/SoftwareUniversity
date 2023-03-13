import { render } from "../src/lit.js";
import { page } from "../src/lit.js";
import { logout } from "./api/user.js";
import { getUser, updateNav } from "./util/util.js";
import { showCatalog } from "./views/catalogView.js";
import { showCreate } from "./views/createView.js";
import { showDetails } from "./views/detailsView.js";
import { showEdit } from "./views/editView.js";
import { showHome } from "./views/homeView.js";
import { showLogin } from "./views/loginView.js";
import { showRegister } from "./views/registerView.js";

const main = document.querySelector('main');

page(decorateCtx);
page('/', showHome);
page('/home', showHome);
page('/login', showLogin);
page('/logout', onLogout);
page('/register', showRegister);
page('/edit/:id', showEdit);
page('/details/:id', showDetails);
page('/create', showCreate);
page('/catalog', showCatalog);


function decorateCtx(ctx, next) {
    ctx.render = function (content) {
        render(content, main);
    }
    ctx.updateNav = updateNav;
    ctx.user = JSON.parse(getUser());
    next();
}

page.start();
updateNav();

function onLogout() {
    logout();
    updateNav();
    page.redirect('/');
}