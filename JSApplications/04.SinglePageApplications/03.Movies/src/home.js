import { loadDetails } from "./details.js";
import { auth, showView } from "./util.js";

const section = document.querySelector('#home-page');
const container = section.querySelector('#movie .card-deck.d-flex.justify-content-center')

export function loadHome() {
    auth();
    showView(section);
    loadMovies();
}

async function loadMovies() {
    const data = await getMovies();
    container.replaceChildren(...data.map(createMoviePreview));
}

function createMoviePreview(movie) {

    const element = document.createElement('li');
    element.className = 'card mb-4';
    element.innerHTML = `
    <img class="card-img-top" src="${movie.img}"
        alt="Card image cap" width="400">
    <div class="card-body">
        <h4 class="card-title">${movie.title}</h4>
    </div>
    <div class="card-footer">
        <a href="#">
            <button type="button" class="btn btn-info">Details</button>
        </a>
    </div>`;

    element.querySelector('button').addEventListener('click', (e) => {

            e.preventDefault();
            loadDetails(movie._id);  
    });

    return element;

}
async function getMovies() {
    const res = await fetch('http://localhost:3030/data/movies');
    return await res.json();
}
