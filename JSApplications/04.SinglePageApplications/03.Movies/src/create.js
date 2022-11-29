import { loadHome } from "./home.js";
import { showView } from "./util.js";

const section = document.querySelector('#add-movie');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

export function loadCreate() {
    showView(section);
}
async function onSubmit(e) {
    e.preventDefault();

    const formData = new FormData(form);

    const data = {
        'title': formData.get('title'),
        'description': formData.get('description'),
        'img': formData.get('img')
    };

    try {
        if (!data.title || !data.description || !data.img) {
            throw new Error('All Fields must be completed!');
        }
        const res = await fetch('http://localhost:3030/data/movies', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                "X-Authorization": JSON.parse(localStorage.getItem('user')).accessToken
            },
            body: JSON.stringify(data)
        });

        if (!res.ok) {
            const err = await res.json();
            throw new Error(err.message);
        }

        form.reset();
        loadHome();

    } catch (err) {
        alert(err.message);
    }

}
