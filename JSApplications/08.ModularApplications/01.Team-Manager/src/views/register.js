import { register } from "../api/user.js";
import { html } from "../lit.js"

let ctx;

const registerTamplate = () => html`
    <section id="register">
        <article class="narrow">
            <header class="pad-med">
                <h1>Register</h1>
            </header>
            <form @submit=${onRegister} id="register-form" class="main-form pad-large">
                <div class="error"></div>
                <label>E-mail: <input type="text" name="email"></label>
                <label>Username: <input type="text" name="username"></label>
                <label>Password: <input type="password" name="password"></label>
                <label>Repeat: <input type="password" name="repass"></label>
                <input class="action cta" type="submit" value="Create Account">
            </form>
            <footer class="pad-small">Already have an account? <a href="#" class="invert">Sign in here</a>
            </footer>
        </article>
    </section>
`;

export function showRegister(context) {
    ctx = context;
    ctx.render(registerTamplate());
}
async function onRegister(e) {
    e.preventDefault();

    const regex = /[A-z]+@[A-z]+.[a-z]+$/;
    const formData = ctx.formData(e);

    if (!regex.test(formData['email'])) {
        document.querySelector('.error').textContent = "Invalid email address!"
    }
    else if (formData['username'].length < 3) {
        document.querySelector('.error').textContent = "Username must contain at least 3 characters!"
    }
    else if (formData['password'] !== formData['repass'] || formData['password'] === "") {
        document.querySelector('.error').textContent = "Password is invalid or don't match!"
    }
    else {
        await register(formData);
        ctx.updateNav();
        ctx.page.redirect("/home");
    }

}