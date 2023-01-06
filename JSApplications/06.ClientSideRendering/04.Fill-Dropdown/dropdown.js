import { html, render } from '../node_modules/lit-html/lit-html.js';
import { getItems } from "./items.js";

const list = document.querySelector('#menu');
const form = document.querySelector('form');
const input = document.querySelector('#itemText');

form.addEventListener('submit', addItem);

const itemTamplate = (item) => html`
<option value="${item._id}">${item.text}</option>
`;

update();

async function update() {
    const items = await getItems();
    render(Object.values(items).map(itemTamplate), list);
}

async function addItem(e) {
    e.preventDefault();

    if (input.value) {
        await fetch('http://localhost:3030/jsonstore/advanced/dropdown', {
            method: 'POST',
            headers: {
                'Content-Type': 'Application/json'
            },
            body: JSON.stringify({ text: input.value })
        });
    }
    form.reset();
    update();
}
