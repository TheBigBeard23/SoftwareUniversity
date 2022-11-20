const url = `http://localhost:3030/jsonstore/collections/myboard/posts`;
const form = document.querySelector('form');
const postBtn = form.querySelector('.public');
const cancleBtn = form.querySelector('.cancel');
const topics = document.querySelector('.topic-container');

showPosts();

cancleBtn.addEventListener('click', (e) => {
    e.preventDefault();
    form.reset();
});
postBtn.addEventListener('click', (e) => {
    e.preventDefault();

    const formData = new FormData(form);

    const data = {
        title: formData.get('topicName'),
        username: formData.get('username'),
        post: formData.get('postText'),
        time: new Date()
    };

    if (data.title
        && data.username
        && data.post) {

        fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
            .then(res => {
                form.reset();
                showPosts();
            })
            .catch(err => alert(err.message));
    }
    else {
        alert('All fields have to be filled!')
    }

});
function showPosts() {
    fetch(url)
        .then(res => res.json())
        .then(res => {
            const elements = Object.values(res).map(p => createPostPreview(p));
            topics.replaceChildren(...elements);
        });
}
function createPostPreview(data) {
    const div = document.createElement('div');
    div.className = 'topic-name-wrapper';
    div.id = data._id;

    div.innerHTML = `
<div class="topic-name">
    <a href="#" class="normal">
        <h2>${data.title}</h2>
    </a>
    <div class="columns">
        <div>
            <p>Date: <time>${data.time}</time></p>
            <div class="nick-name">
                <p>Username: <span>${data.username}</span></p>
            </div>
        </div>
    </div>
</div>`;

div.addEventListener('click', (e) => {
    window.location = 'theme-content.html'
});
    return div;
}
