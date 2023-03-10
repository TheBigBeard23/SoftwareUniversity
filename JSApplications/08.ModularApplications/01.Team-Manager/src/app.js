import { page } from "./lit.js"
import { render } from "./lit.js"
import { showHome } from "./views/home.js";
import { showLogin } from "./views/login.js";
import { updateNav, getUserData, getFormData } from "./util/util.js";
import { logout } from "./api/user.js";
import { showRegister } from "./views/register.js";
import { showCatalog } from "./views/catalog.js";
import { showDetails } from "./views/details.js";
import { showEdit } from "./views/edit.js";
import { showCreate } from "./views/create.js";
import { showMyTeams } from "./views/myTeams.js";


const main = document.querySelector('main');


page(decorateContext);
page('/', showHome)
page('/home', showHome)
page('/login', showLogin)
page('/logout', onLogout)
page('/register', showRegister)
page('/catalog', showCatalog)
page('/details/:id', showDetails)
page('/edit/:id', showEdit)
page('/create', showCreate)
page('/my-teams', showMyTeams)

page.start();
updateNav();

function decorateContext(ctx, next) {
    ctx.updateNav = updateNav;
    ctx.user = getUserData();
    ctx.formData = getFormData;
    ctx.render = function (content) {
        render(content, main);
    };
    next();
}
async function onLogout() {
    await logout();
    updateNav();
    page.redirect('/home');
}
