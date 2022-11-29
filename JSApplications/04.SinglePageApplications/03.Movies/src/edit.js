import { loadHome } from "./home.js";
import { showView } from "./util.js";

const section = document.querySelector('#edit-movie');
const form = section.querySelector('form');
form.addEventListener('submit', (e) => onSubmit(e));
let crnMovie;
let crnUser;

export function loadEdit(movie, user) {
    crnMovie = movie;
    crnUser = user;
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
            throw new Error('All fields must be filled!');
        }
        if (crnUser._id != crnMovie._ownerId) {
            form.reset();
            throw new Error('You cannot edit this movie!');
        }
        const res = await fetch('http://localhost:3030/data/movies/' + crnMovie._id, {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'X-Authorization': crnUser.accessToken
            },
            body: JSON.stringify(data)
        });

        if (!res.ok) {
            const error = await response.json();
            throw new Error(error.message);
        }

        form.reset();
        loadHome();

    } catch (err) {
        alert(err.message);
    }

}
