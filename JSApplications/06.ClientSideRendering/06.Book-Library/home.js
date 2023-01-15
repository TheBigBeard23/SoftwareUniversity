import { html, render } from '../node_modules/lit-html/lit-html.js';
import { addFormTamplate } from './addBook.js';
import { editFormTamplate } from './editBook.js';
import { update } from './loadBooks.js';

const body = document.querySelector('body');

const tableTamplate = () => html`
<button id="loadBooks" @click=${update}>LOAD ALL BOOKS</button>
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
${addFormTamplate()}
${editFormTamplate()}
`;

render(tableTamplate(), body);
update();

