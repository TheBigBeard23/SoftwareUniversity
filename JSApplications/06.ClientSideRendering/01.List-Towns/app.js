import { html, render } from '../node_modules/lit-html/lit-html.js';

const root = document.getElementById('root');
const input = document.querySelector('#towns');

const townList = (towns) => html`
<ul>
    ${towns.map(x => html`<li>${x}</li>`)}
</ul>`;


document.querySelector('#btnLoadTowns').addEventListener('click', (e) => {
    e.preventDefault();
    const towns = input.value.split(', ');
    render(townList(towns), root)
});