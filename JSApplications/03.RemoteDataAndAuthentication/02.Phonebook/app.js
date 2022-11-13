function attachEvents() {

    const url = `http://localhost:3030/jsonstore/phonebook`;

    const person = document.querySelector('#person');
    const phone = document.querySelector('#phone');
    const phonebook = document.querySelector('#phonebook');

    loadBtn = document.querySelector('#btnLoad');
    createBtn = document.querySelector('#btnCreate');

    loadBtn.addEventListener('click', loadContacts);
    createBtn.addEventListener('click', addContact);

    function loadContacts() {
        fetch(url)
            .then(res => res.json())
            .then(res => {
                for (let contact of Object.values(res)) {
                    loadContact(contact);
                }

            })
            .catch(err => console.log(err));

        function loadContact(data) {

            let li = document.createElement('li');
            li.textContent = `${data.person}: ${data.phone}`;

            let deleteBtn = document.createElement('button');
            deleteBtn.textContent = 'Delete';

            li.appendChild(deleteBtn);
            phonebook.appendChild(li);

            deleteBtn.addEventListener('click', () => deleteContact(data._id, li));
        }
    }
    function addContact() {

        let body = {
            person: person.value,
            phone: phone.value,
        };

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'applications/json'
            },
            body: JSON.stringify(body)
        })
        
        person.value = '';
        phone.value = '';
    }
    function deleteContact(id, li) {

        fetch(`${url}/${id}`, {
            method: 'DELETE'
        })
            .then(res => {
                li.remove();
                console.log(res);
            })
            .catch(err => console.log(err));
    }
}

attachEvents();