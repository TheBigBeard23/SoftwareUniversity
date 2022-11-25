import { showDetails } from "./details.js";
import { hideSections } from "./util.js";

const homeView = document.querySelector('#homeView')
const sections = document.querySelectorAll('section');
const topicsContainer = document.querySelector('.topic-container');
const defaultTopic = document.querySelector('.topic-name-wrapper');
const form = document.querySelector('form');

form.addEventListener('submit', onSubmit);

export function showHome() {
    hideSections(sections);
    homeView.style.display = 'block';
    loadTopics();
}

async function loadTopics() {

    try {
        const res = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts');
        const data = await res.json();
        topicsContainer.replaceChildren();
        displayTopics(data);
    }
    catch (err) {
        alert(err.message);
    }

}
function displayTopics(data) {
    Object.values(data)
        .forEach(crnTopic => {

            const newTopic = defaultTopic.cloneNode(true);
            const a = newTopic.querySelector('a');
            a.id = crnTopic._id;
            a.addEventListener('click', showDetails);
            newTopic.querySelector('h2').textContent = crnTopic.title;
            newTopic.querySelector('time').textContent = crnTopic.time;
            newTopic.querySelector('span').textContent = crnTopic.username;
            topicsContainer.appendChild(newTopic);
        });
}

function onSubmit(e) {
    e.preventDefault();

    if (e.submitter.textContent == 'Cancel') {
        form.reset();
    } else {
        createTopic();
    }
}
async function createTopic() {

    const formData = new FormData(form);

    const data = {
        title: formData.get('topicName'),
        username: formData.get('username'),
        post: formData.get('postText'),
        time: new Date()
    };

    try {

        if (!data.title || !data.username || !data.post) {
            throw new Error('All fields must be filled')
        }

        const res = await fetch('http://localhost:3030/jsonstore/collections/myboard/posts', {
            method: 'POST',
            headers: {
                'Content-Type': 'application-json'
            },
            body: JSON.stringify(data)
        });

        if (res.ok) {
            form.reset();
            showHome();
        }

    } catch (err) {
        alert(err.message);
    }

}
