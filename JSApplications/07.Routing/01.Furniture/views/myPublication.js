import { html, render } from "../../node_modules/lit-html/lit-html.js";


const myPublicationsTamplate = (data) => html`
<div class="row space-top">
    <div class="col-md-12">
        <h1>My Furniture</h1>
        <p>This is a list of your publications.</p>
    </div>
</div>
<div class="row space-top">
    ${data.map(x=>
        html`
        <div class="col-md-4">
        <div class="card text-white bg-primary">
            <div class="card-body">
                <img src="${x.img}" />
                <p>${x.description}</p>
                <footer>
                    <p>Price: <span>${x.price} $</span></p>
                </footer>
                <div>
                    <a href="/details/${x._id}" class="btn btn-info">Details</a>
                </div>
            </div>
        </div>`
    )}
    </div>
`;

const getData = () => {
    return fetch("http://localhost:3030/data/catalog")
    .then(res=>res.json())
    .then(data=>{ 
        return Object.values(data.filter(x=>x._ownerId==localStorage.ownerId))
    })
}

export const myPublicationsView = (ctx) =>
getData()
.then(data=>render(myPublicationsTamplate(data),document.querySelector('.container')));