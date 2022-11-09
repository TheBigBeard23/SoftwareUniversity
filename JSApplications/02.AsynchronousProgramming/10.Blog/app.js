let posts = document.querySelector('#posts');
let postTitle = document.querySelector('#post-title');
let postBody = document.querySelector('#post-body');
let postComments = document.querySelector('#post-comments');

let loadBtn = document.querySelector('#btnLoadPosts');
let viewbtn = document.querySelector('#btnViewPost');

loadBtn.addEventListener('click', loadPosts);

function loadPosts() {

    fetch(`http://localhost:3030/jsonstore/blog/posts`)
        .then(res => res.json())
        .then(res => {

            posts.innerHTML = '';

            for (let comment in res) {

                const option = document.createElement('option');
                option.value = comment;
                option.textContent = res[comment].title;
                posts.appendChild(option);
            }

            viewbtn.addEventListener('click', () => viewPost(res));
        })
        .catch(err => console.log(err.message));
}

function viewPost(data) {

    fetch(`http://localhost:3030/jsonstore/blog/comments`)
        .then(res => res.json())
        .then(res => {

            let comments = Object.values(res).filter(c => c.postId == posts.value);
            let selectedOption = [...posts.options].find(o => o.value === posts.value);

            postTitle.textContent = selectedOption.textContent;
            postBody.textContent = data[posts.value].body;

            postComments.innerHTML = '';

            for (let comment of comments) {
                const li = document.createElement('li');
                li.id = comment.id;
                li.textContent = comment.text;
                postComments.appendChild(li);
            }
        })
        .catch(err => console.log(err.message));
}