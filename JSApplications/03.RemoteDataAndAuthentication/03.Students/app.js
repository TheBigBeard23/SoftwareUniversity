const url = `http://localhost:3030/jsonstore/collections/students`

const table = document.querySelector('#results tbody');

const form = document.getElementById('form');
form.addEventListener('submit', addStudent);

loadStudents();

function addStudent(e) {
    e.preventDefault();

    const formData = new FormData(e.currentTarget);

    const data = {
        firstName: formData.get('firstName'),
        lastName: formData.get('lastName'),
        facultyNumber: formData.get('facultyNumber'),
        grade: formData.get('grade'),
    };

    if (data.firstName
        && data.lastName
        && Number(data.facultyNumber)
        && Number(data.grade)) {

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
            .then(res => loadStudents())
            .catch(err => alert('Error with submit student'));
    }
}
function loadStudents() {
    table.replaceChildren();

    fetch(url)
        .then(res => res.json())
        .then(res => {
            for (let student of Object.values(res)) {

                table.appendChild(createRow(
                    student.firstName,
                    student.lastName,
                    student.facultyNumber,
                    student.grade));
            }
        })
        .catch(err => alert(err.message));
}
function createRow(...columns) {

    let tr = document.createElement('tr');

    for (let column of columns) {

        let td = document.createElement('td');
        td.textContent = column;
        tr.appendChild(td);
    }

    return tr;
}