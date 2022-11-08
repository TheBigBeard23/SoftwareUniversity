function lockedProfile() {

    const main = document.querySelector('#main');
    const div = document.querySelector('.profile');
    const url = `http://localhost:3030/jsonstore/advanced/profiles`;

    fetch(url)
        .then(res => res.json())
        .then(res => {

            for (let obj of Object.values(res)) {

                let newDiv = div.cloneNode(true);
                let [id, username, email, age] = Object.values(obj);

                newDiv.querySelector('[name="user1Username"]').value = username;
                newDiv.querySelector('[name="user1Email"]').value = email;
                newDiv.querySelector('[name="user1Age"]').value = age;
                newDiv.querySelector('[name="user1Age"]').type = 'email';
                newDiv.querySelector('input[value="lock"]').name = id;
                newDiv.querySelector('input[value="unlock"]').name = id;

                let moreInfo = newDiv.querySelector('.user1Username');
                let btn = newDiv.querySelector('button');
                moreInfo.style.display = 'none';

                btn.addEventListener('click', (event) => {

                    const unlock = newDiv.querySelector('input[value="unlock"]').checked;

                    if (unlock && btn.textContent === 'Show more') {
                        moreInfo.style.display = 'block'
                        btn.textContent = 'Hide it';
                    } else {
                        moreInfo.style.display = 'none'
                        btn.textContent = 'Show more';
                    }
                })
                main.appendChild(newDiv);
            }
            div.remove();
        })
        .catch();
}