import { html } from '../node_modules/lit-html/lit-html.js';
import { editBook } from './api.js';
import { update, updateBook } from './loadBooks.js';


const editFormTamplate = () => html`
    <form id="edit-form" style="display: none;">
        <input type="hidden" name="id">
        <h3>Edit book</h3>
        <label>TITLE</label>
        <input type="text" name="title" placeholder="Title...">
        <label>AUTHOR</label>
        <input type="text" name="author" placeholder="Author...">
        <input type="submit" value="Save" @click=${save}>
    </form>
`;
export async function save(e) {
    e.preventDefault();
    const form = document.querySelector('#edit-form');
    const formData = new FormData(form);
    const data = {
        "author": formData.get('author'),
        "title": formData.get('title')
    }
    editBook(e.target.id, data);
    form.reset();
    updateBook();
    update();
}

export { editFormTamplate };