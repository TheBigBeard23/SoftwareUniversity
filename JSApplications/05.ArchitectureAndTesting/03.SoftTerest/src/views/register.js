import { register } from "../api/users.js";

const section = document.querySelector('#registerPage');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

let ctx;

export function showRegister(context) {
    ctx = context;
    context.showSection(section);
}

async function onSubmit(e) {
    e.preventDefault();

    const formData = new FormData(form);

    const email = formData.get('email');
    const password = formData.get('password');
    const repass = formData.get('repeatPassword');

    if (password != repass) {
        alert("Passwords don\'t match!");
    }
    else {
        await register(email, password);
        ctx.goto('/');
    }
} 