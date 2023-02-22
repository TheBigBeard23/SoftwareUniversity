import { html, render } from "../../node_modules/lit-html/lit-html.js";
import page from "../../node_modules/page/page.mjs";
import { updateInfo } from "../app.js";

const registerTamplate = () => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Register New User</h1>
        <p>Please fill all fields.</p>
    </div>
</div>
<form @submit=${onSubmit}>
    <div class="row space-top">
        <div class="col-md-4">
            <div class="form-group">
                <label class="form-control-label" for="email">Email</label>
                <input class="form-control" id="email" type="text" name="email">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="password">Password</label>
                <input class="form-control" id="password" type="password" name="password">
            </div>
            <div class="form-group">
                <label class="form-control-label" for="rePass">Repeat</label>
                <input class="form-control" id="rePass" type="password" name="rePass">
            </div>
            <input type="submit" class="btn btn-primary" value="Register" />
        </div>
    </div>
</form>
`;

function onSubmit(e) {
    e.preventDefault();

    let formData = new FormData(e.currentTarget);

    let email = formData.get('email');
    let password = formData.get('password');
    let rePass = formData.get('rePass');

    if (password != rePass) {
        alert('Passwords does not match!');
        return;
    }


    fetch('http://localhost:3030/users/register', {
        method: "POST",
        body: JSON.stringify({ email, password })
    })
        .then(res => res.json())
        .then(data => {
            localStorage.setItem("token", data.accessToken);
            localStorage.setItem("ownerId", data._id);
            updateInfo();
            page.redirect('/catalog');
        })
        .catch(err => alert(err.message));
}

export const registerView = (ctx) => render(registerTamplate(), document.querySelector('.container'));