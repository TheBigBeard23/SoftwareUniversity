import { html, render } from '../node_modules/lit-html/lit-html.js';
import { deleteBookById, getBooks } from './api.js';

const tableRowTamplate = (books) => html`
${Object.entries(books).map(([id, info]) => html`
<tr id="${id}">
    <td>${info.title}</td>
    <td>${info.author}</td>
    <td>
        <button @click=${()=> updateBook(info.title, info.author, id)}>Edit</button>
        <button @click=${deleteBook}>Delete</button>
    </td>
</tr>`
)}`;

export async function update() {
    const tbody = document.querySelector('tbody');
    const books = await getBooks();
    render(tableRowTamplate(books), tbody);
}
async function deleteBook(e) {
    deleteBookById(e.target.parentNode.parentNode.id);
    update();
}
export async function updateBook(title, author, id) {
    const addForm = document.querySelector('#add-form');
    const editForm = document.querySelector('#edit-form');

    if (addForm.style.display == 'block') {
        editForm.style.display = 'block';
        addForm.style.display = 'none';
        editForm.querySelector('input[name=title]').value = title;
        editForm.querySelector('input[name=author]').value = author;
        editForm.querySelector('input[type=submit]').id = id;
    } else {
        editForm.style.display = 'none';
        addForm.style.display = 'block';
    }
}   