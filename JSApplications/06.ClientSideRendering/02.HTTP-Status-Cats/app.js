import { html, render } from '../node_modules/lit-html/lit-html.js';
import { cats } from "./catSeeder.js";

const section = document.getElementById('allCats');

const cardTamplate = (cats) => html`
<ul>
    ${cats.map(cat => createCard(cat))}
</ul>
`;

function createCard(cat) {
    return html`
<li>
    <img src="./images/${cat.imageLocation}.jpg" width="250" height="250" alt="Card image cap">
    <div class="info">
        <button class="showBtn">Show status code</button>
        <div class="status" style="display: none" id="100">
            <h4>Status Code: ${cat.statusCode}</h4>
            <p>${cat.statusMessage}</p>
        </div>
    </div>
</li>
`;
}

render(cardTamplate(cats), section);

section.addEventListener('click', (e) => {

    if (e.target.tagName == 'BUTTON') {

        if (e.target.nextElementSibling.style.display == 'none') {
            e.target.nextElementSibling.style.display = 'block'
            e.target.textContent = 'Hide status code';
        } else {
            e.target.nextElementSibling.style.display = 'none';
            e.target.textContent = 'Show status code';
        }
    }
});