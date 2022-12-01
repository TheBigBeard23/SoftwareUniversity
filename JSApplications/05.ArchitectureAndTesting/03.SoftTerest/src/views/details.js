import { getIdea } from "../api/data.js";

const section = document.querySelector('#detailsPage');

let ctx;
export function showDetails(context) {
    ctx = context;
    context.showSection(section);
}

async function loadDetails(id) {
    const data = await getIdea(id);
    console.log(data);
}