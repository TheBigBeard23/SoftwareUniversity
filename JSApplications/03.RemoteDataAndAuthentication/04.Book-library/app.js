const baseUrl = `http://localhost:3030/jsonstore/collections/books`;
const table = document.querySelector('table tbody');
const form = document.querySelector('form');
const submitBtn = form.querySelector('button');
const formTitle = form.querySelector('h3');
let id;

document.getElementById('loadBooks').addEventListener('click', loadBooks);
form.addEventListener('submit', addBook);

function addBook(e) {
    e.preventDefault();

    const formData = new FormData(form);

    const data = {
        author: formData.get('author'),
        title: formData.get('title')
    };

    if (data.author && data.title) {

        if (submitBtn.textContent == 'Submit') {
            fetch(baseUrl, {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            })
                .catch(err => alert(err.message));
        }
        else {
            fetch(`${baseUrl}/${id}`, {
                method: 'PUT',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(data)
            })
                .then(res => {
                    submitBtn.textContent = "Submit";
                    formTitle.textContent = "FORM";
                })
                .catch(err => alert(err.message));
        }
    }
}
function loadBooks() {
    table.innerHTML = '';

    fetch(baseUrl)
        .then(res => res.json())
        .then(res => {
            Object.entries(res)
                .forEach(book => {
                    table.appendChild(createRow(book));
                });
        });

    function createRow([key, { title, author }]) {

        let tr = document.createElement('tr');
        createElement('td', title, tr);
        createElement('td', author, tr);

        let td = createElement('td', '', tr);
        td.id = key;

        let editBtn = createElement('button', 'Edit', td);
        let deleteBtn = createElement('button', 'Delete', td);

        editBtn.addEventListener('click', () => editBook([key, { title, author }]));
        deleteBtn.addEventListener('click', deleteBook);

        return tr;
    }
}
function editBook([key, { title, author }]) {
    id = key;
    submitBtn.textContent = "Save";
    formTitle.textContent = "Edit FORM";

    form.querySelector('[name="title"]').value = title;
    form.querySelector('[name="author"]').value = author;
}
function deleteBook(event) {

    let id = event.currentTarget.parentNode.id;

    fetch(`${baseUrl}/${id}`, {
        method: 'Delete'
    })
        .catch(err => alert(err.message));

    event.currentTarget.closest('tr').remove();

}
function createElement(type, textContent, parentNode) {

    let element = document.createElement(type);
    if (textContent) { element.textContent = textContent };
    if (parentNode) { parentNode.appendChild(element) };

    return element;
}