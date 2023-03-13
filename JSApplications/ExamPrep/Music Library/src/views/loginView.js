import { login } from "../api/user.js";
import { html } from "../lit.js";
import { getFormData } from "../util/util.js";

let ctx;

const loginTemplate = () => html`
    <section id="login">
        <div class="form">
            <h2>Login</h2>
            <form @submit=${onSubmit} class="login-form">
                <input type="text" name="email" id="email" placeholder="email" />
                <input type="password" name="password" id="password" placeholder="password" />
                <button type="submit">login</button>
                <p class="message">
                    Not registered? <a href="#">Create an account</a>
                </p>
            </form>
        </div>
    </section>

`;

export function showLogin(context) {
    ctx = context;
    ctx.render(loginTemplate());
}

async function onSubmit(e) {
    const data = getFormData(e);

    try {
        await login(data);
    } catch (error) {
        alert(error.message);
        return;
    }

    ctx.updateNav();
    ctx.page.redirect('/catalog');

}

