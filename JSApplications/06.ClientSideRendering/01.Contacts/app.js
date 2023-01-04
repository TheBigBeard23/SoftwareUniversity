import { html, render, nothing } from '../node_modules/lit-html/lit-html.js';
import { contacts } from './contacts.js';

const root = document.getElementById('contacts');

const contactCard = (contact) => html`
<div class="contact card">
    <div>
        <i class="far fa-user-circle gravatar"></i>
    </div>
    <div class="info">
        <h2>Name: ${contact.name}</h2>
        <button class="detailsBtn">Details</button>
        <div class="details" id="${contact.id}">
            <p>Phone number: ${contact.phoneNumber}</p>
            <p>Email: ${contact.email}</p>
        </div>
    </div>
</div>`;

render(contacts.map(contactCard), root);


root.addEventListener('click', ontoggle);

function ontoggle(e) {
 
    if (e.target.tagName == 'BUTTON') {

        const div = e.target.nextElementSibling;

        div.style.display == 'block'
            ? div.style.display = 'none'
            : div.style.display = 'block';
    }

}