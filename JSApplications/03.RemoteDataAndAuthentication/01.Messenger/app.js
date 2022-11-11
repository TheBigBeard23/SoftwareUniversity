function attachEvents() {
    const url = `http://localhost:3030/jsonstore/messenger`;

    const messages = document.querySelector("#messages");
    const messageAuthor = document.querySelector('[name="author"]');
    const message = document.querySelector('[name="content"]');

    const sendBtn = document.querySelector('#submit');
    const refreshBtn = document.querySelector('#refresh');

    sendBtn.addEventListener('click', sendMessage);
    refreshBtn.addEventListener('click', showMessages);

    function sendMessage() {
        let body = {
            author: messageAuthor.value,
            content: message.value
        }
        fetch(url, {
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify(body)
        })
            .then(res => res.json())
            .then(user => console.log(user))
            .catch(err => console.log(err));
    }

    function showMessages() {
        fetch(url)
            .then(res => res.json())
            .then(res => {
                messages.value = Object.values(res)
                    .map(m => `${m.author}: ${m.content}`)
                    .join('\n');
            })
            .catch(err => console.log(err));
    }
}

attachEvents();