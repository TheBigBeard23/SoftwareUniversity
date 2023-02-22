import { html, render } from "../../node_modules/lit-html/lit-html.js";

const detailsTamplate = (data) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>Furniture Details</h1>
    </div>
</div>
<div class="row space-top">
    <div class="col-md-4">
        <div class="card text-white bg-primary">
            <div class="card-body">
                <img src="${data.img}" />
            </div>
        </div>
    </div>
    <div class="col-md-4">
        <p>Make: <span>${data.make}</span></p>
        <p>Model: <span>${data.model}</span></p>
        <p>Year: <span>${data.year}</span></p>
        <p>Description: <span>${data.description}</span></p>
        <p>Price: <span>${data.price}</span></p>
        <p>Material: <span>${data.material}</span></p>
        <div>
            <a href="/edit/${data._id}" class="btn btn-info" style="display: ${data._ownerId == localStorage.ownerId ? "inline" : "none"}">Edit</a>
            <a href="#" id=${data._id} class="btn btn-red" style="display: ${data._ownerId == localStorage.ownerId ? "inline" : "none"}">Delete</a>
        </div>
    </div>
</div>
`;

export const detailsView = (ctx) => {
    fetch(`http://localhost:3030/data/catalog/${ctx.params.detailsId}`)
        .then(res => res.json())
        .then(data => {
            render(detailsTamplate(data), document.querySelector('.container'));
        })
}