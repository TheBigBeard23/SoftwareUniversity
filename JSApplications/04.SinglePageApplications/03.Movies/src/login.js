import { loadHome } from "./home.js";
import { showView } from "./util.js";

const section = document.querySelector('#form-login');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

export function loadLogin() {
    showView(section);
}
async function onSubmit(e) {
    e.preventDefault();

    const formData = new FormData(form);

    const data = {
        'email': formData.get('email'),
        'password': formData.get('password')
    };

    await login(data);
    form.reset();
    loadHome();
}
async function login(data) {

    try {
        const res = await fetch('http://localhost:3030/users/login', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (!res.ok) {
            const err = await res.json();
            throw new Error(err.message);
        }

        const user = await res.json();
        localStorage.setItem('user', JSON.stringify(user));

    } catch (err) {
        alert(err.message);
        throw err;
    }
}



