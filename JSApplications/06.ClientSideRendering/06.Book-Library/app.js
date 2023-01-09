import { html, render } from '../node_modules/lit-html/lit-html.js';

const body = document.querySelector('body');

const tableTamplate = () => html`
<button id="loadBooks">LOAD ALL BOOKS</button>
<table>
    <thead>
        <tr>
            <th>Title</th>
            <th>Author</th>
            <th>Action</th>
        </tr>
    </thead>
    <tbody>
    </tbody>
</table>
`;
const tableRowTamplate = (book) => html`
<tr>
    <td>${book.title}</td>
    <td>${book.author}</td>
    <td>
        <button>Edit</button>
        <button>Delete</button>
    </td>
</tr>
`;

render(tableTamplate(), body);
loadBooks();

async function loadBooks() {
    const tbody = document.querySelector('tbody');
    const res = await fetch('http://localhost:3030/jsonstore/collections/books');
    const data = await res.json();
    render(Object.values(data).map(tableRowTamplate), tbody);
}