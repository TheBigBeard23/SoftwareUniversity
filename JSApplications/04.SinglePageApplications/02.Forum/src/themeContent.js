const url = `http://localhost:3030/jsonstore/collections/myboard/posts/`
document.querySelector('a').addEventListener('click', () => {
    window.location = 'index.html'
});

function loadPost(id) {
    fetch(url + id)
        .then(res => res.json())
        .then(data => createPost(data))
        .catch(err => alert(err.message));
}
function createPost({ title, username, content, time, _id }) {
    const h2 = document.querySelector('h2');
    h2.textContent = title;
}