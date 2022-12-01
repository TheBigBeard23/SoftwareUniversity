import { createIdea } from "../api/data.js";

const section = document.querySelector('#createPage');
const form = section.querySelector('form');
form.addEventListener('submit', onSubmit);

let ctx;

export function showCreate(context) {
    ctx = context;
    context.showSection(section);
}

async function onSubmit() {

    const formData = new FormData(form);

    const title = formData.get('title');
    const description = formData.get('description');
    const img = formData.get('imageURL');

    createIdea({ title, description, img });
    ctx.goto('/');
}