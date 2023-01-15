import { html } from '../node_modules/lit-html/lit-html.js';
import { createBook } from './api.js';
import { update } from './loadBooks.js';

const addFormTamplate = () => html`
        <form id="add-form" style="display: block;">
            <h3>Add book</h3>
            <label>TITLE</label>
            <input type="text" name="title" placeholder="Title...">
            <label>AUTHOR</label>
            <input type="text" name="author" placeholder="Author...">
            <input type="submit" value="Submit" @click=${submit}>
        </form>
`;
async function submit(e) {
    e.preventDefault();
    const form = document.querySelector('form');
    const formData = new FormData(form);
    const data = {
        "author": formData.get('author'),
        "title": formData.get('title')
    }
    createBook(data);
    form.reset();
    update();
}

export { addFormTamplate };