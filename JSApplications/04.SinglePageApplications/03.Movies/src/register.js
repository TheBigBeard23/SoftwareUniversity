import { loadHome } from "./home.js";
import { showView } from "./util.js";

const section = document.querySelector('#form-sign-up');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

export function loadRegister() {
    showView(section);
}

async function onSubmit(e) {
    e.preventDefault();

    const formData = new FormData(form);

    const email = formData.get('email');
    const password = formData.get('password');
    const rePass = formData.get('repeatPassword')

    try {
        if (!email || !password || !rePass) {
            throw new Error('All fields are required!');
        }
        if (password.length < 6) {
            throw new Error('Password must be at least 6 characters!');
        }
        if (password !== rePass) {
            throw new Error('Passwords don\'t match!');
        }

        register({ email, password });

    } catch (err) {
        alert(err.message);
    }
}
async function register(data) {

    try {
        const res = await fetch('http://localhost:3030/users/register', {
            method: 'POST',
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(data)
        });

        if (!res.ok) {
            throw new Error(res.message);
        }

        const result = await res.json();

        form.reset();
        localStorage.setItem('user', JSON.stringify(result));

        loadHome();
    }
    catch (err) {
        throw err;
    }

}