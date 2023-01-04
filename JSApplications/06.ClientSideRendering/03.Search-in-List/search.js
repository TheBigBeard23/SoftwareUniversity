import { html, render } from '../node_modules/lit-html/lit-html.js';
import { towns } from './towns.js';

const list = document.querySelector('#towns');
let searchText;

const listTamplate = (towns) => html`
<ul>
   ${towns.map(town => searchText && town.toLowerCase().includes(searchText.toLowerCase())
      ? html`<li class="active">${town}</li>`
      : html`<li>${town}</li>`)}
</ul>
`;

render(listTamplate(towns), list);

document.querySelector('article').addEventListener('click', search);

function search(event) {
   event.preventDefault();
   if (event.target.tagName == 'BUTTON') {
      searchText = document.querySelector('#searchText').value;
      render(listTamplate(towns), list);
   }
}
