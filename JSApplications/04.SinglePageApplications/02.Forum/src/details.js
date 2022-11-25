import { hideSections } from "./util.js";

const detailsView = document.querySelector('#detailsView')
const sections = document.querySelectorAll('section');
const defaultTopicDetails = detailsView.querySelector('.theme-content');
const defaultComment = defaultTopicDetails.querySelector('.topic-name-wrapper');
const commentsContainer = detailsView.querySelector('#user-comment');
const form = detailsView.querySelector('form');

let topicId;

form.addEventListener('submit', addComment);

export function showDetails(e) {
    hideSections(sections);
    displayTopicDetails(e.currentTarget.id);
    detailsView.style.display = 'block';
}
async function displayTopicDetails(id) {
    topicId = id;

    const res = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts/' + id);
    const data = await res.json();

    defaultTopicDetails.querySelector('h2').textContent = data.title;
    defaultTopicDetails.querySelector('span').textContent = data.username;
    defaultTopicDetails.querySelector('time').textContent = data.time;
    defaultTopicDetails.querySelector('.post-content').textContent = data.post;

    loadComments(defaultComment);
}
async function loadComments(defaultComment) {
    commentsContainer.replaceChildren();

    try {
        const res = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments')
        const data = await res.json();

        Object.values(data).forEach(comment => {

            if (comment.postId == topicId) {

                const crnComment = defaultComment.cloneNode(true);
                crnComment.querySelector('strong').textContent = comment.username;
                crnComment.querySelector('time').textContent = comment.time;
                crnComment.querySelector('.post-content p').textContent = comment.text;
                commentsContainer.appendChild(crnComment);
            }
        });
        
    } catch (err) {
        alert(err.message);
    }
}
async function addComment(e) {
    e.preventDefault();

    const formData = new FormData(form);

    const data = {
        text: formData.get('postText'),
        username: formData.get('username'),
        postId: topicId,
        time: new Date(),
    };
    try {

        if (!data.text || !data.username) {
            throw new Error('All fields must be filled!!!')
        }

        const res = await fetch('http://localhost:3030/jsonstore/collections/myboard/comments', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (res.ok) {
            form.reset();
            loadComments(defaultComment);
        }

    } catch (err) {
        alert(err.message);
    }
}