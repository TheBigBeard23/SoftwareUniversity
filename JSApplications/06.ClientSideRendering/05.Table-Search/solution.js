import { html, render } from '../node_modules/lit-html/lit-html.js';

const input = document.querySelector('#searchField');
const tbody = document.querySelector('tbody');

const cellsTamplate = (item) => html`
<td>${item.firstName} ${item.lastName}</td>
<td>${item.email}</td>
<td>${item.course}</td>
`;

const tableRowTemplate = (item) =>
   input.value && search(item)
      ? html`<tr class="select">${cellsTamplate(item)}</tr>`
      : html`<tr>${cellsTamplate(item)}</tr>`;

update();
document.querySelector('#searchBtn').addEventListener('click', onClick);

function onClick() {
   if (input.value) {
      update();
   }
}
function search(item) {

   let isIncludes = false;

   Object.values(item).map(x => {
      if (x.toLowerCase().includes(input.value.toLowerCase())) {
         isIncludes = true;
      }
   });

   return isIncludes;
}
async function update() {

   const data = await getData();

   render(Object.values(data).map(tableRowTemplate), tbody);

   input.value = '';
}
async function getData() {

   const res = await fetch('http://localhost:3030/jsonstore/advanced/table');
   const data = await res.json();

   return data;
}