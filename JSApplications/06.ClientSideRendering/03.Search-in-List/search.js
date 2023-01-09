import { html, render } from '../node_modules/lit-html/lit-html.js';
import { towns } from './towns.js';

const list = document.querySelector('#towns');
const result = document.querySelector('#result');
let matchCount;
let searchText;

const listTamplate = (towns) => html`
<ul>
   ${towns.map(town => {
      if(searchText && town.toLowerCase().includes(searchText.toLowerCase())){
         matchCount++;
         return html`<li class="active">${town}</li>`;
      }else{
         return html`<li>${town}</li>`;
      }
})}
</ul>
`;

update();

function update() {
   render(listTamplate(towns), list);
}

document.querySelector('article').addEventListener('click', search);

function search(event) {
   event.preventDefault();
   if (event.target.tagName == 'BUTTON') {
      searchText = document.querySelector('#searchText').value;
      matchCount = 0;
      update();
      result.textContent = `${matchCount} matches found`;
   }
}
