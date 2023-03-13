import { register } from "../api/user.js";
import { html } from "../lit.js";
import { getFormData } from "../util/util.js";

let ctx;

const registerTamplate = () => html`
<section id="register">
    <div class="form">
        <h2>Register</h2>
        <form @submit=${onRegister} class="login-form">
            <input type="text" name="email" id="register-email" placeholder="email" />
            <input type="password" name="password" id="register-password" placeholder="password" />
            <input type="password" name="re-password" id="repeat-password" placeholder="repeat password" />
            <button type="submit">register</button>
            <p class="message">Already registered? <a href="#">Login</a></p>
        </form>
    </div>
</section>
`;

export function showRegister(context) {
    ctx = context;
    ctx.render(registerTamplate());
}
async function onRegister(e) {
    const data = getFormData(e);

    if (data['password'] !== data['re-password']) {
        alert('Password don\'t match');
        return;
    }
    if (data['password'].length < 3 ||
        data['re-password'].length < 3) {

        alert('Password should have at least three unique characters');
        return;
    }

    await register(data);
    ctx.updateNav();
    ctx.page.redirect('/catalog');
}