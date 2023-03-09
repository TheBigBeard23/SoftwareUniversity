import { get } from "../api/api.js";
import { html } from "../lit.js"
import { login } from "../api/user.js";

let ctx;

const loginTamplate = () => html`
    <section id="login">
        <article class="narrow">
            <header class="pad-med">
                <h1>Login</h1>
            </header>
            <form @submit=${onSubmit} id="login-form" class="main-form pad-large">
                <div class="error"></div>
                <label>E-mail: <input type="text" name="email"></label>
                <label>Password: <input type="password" name="password"></label>
                <input class="action cta" type="submit" value="Sign In">
            </form>
            <footer class="pad-small">Don't have an account? <a href="#" class="invert">Sign up here</a>
            </footer>
        </article>
    </section>
`;

export function showLogin(context) {
    ctx = context;
    ctx.render(loginTamplate());
}

async function onSubmit(e) {
    e.preventDefault();

    try {
        await login(ctx.formData(e));
        ctx.updateNav();
        ctx.page.redirect('/home');
    }
    catch (err) {
        document.querySelector('.error').textContent = err.message;
    }

}
