import { getAllAlbums } from "../api/data.js";
import { html } from "../lit.js";

const catalogTamplate = (albums) => html`
<section id="dashboard">
    <h2>Albums</h2>
    ${albums.length > 1
        ? html`
    <ul class="card-wrapper">
        ${albums.map(cardTamplate)}
    </ul>`
        : html`
    <h2>There are no albums added yet.</h2>
    `}
</section>
    `;

const cardTamplate = (album) => html`
    <li class="card">
        <img src="${album.imageUrl}" alt="travis" />
        <p>
            <strong>Singer/Band: </strong><span class="singer">${album.singer}</span>
        </p>
        <p>
            <strong>Album name: </strong><span class="album">${album.album}</span>
        </p>
        <p><strong>Sales:</strong><span class="sales">${album.sales}</span></p>
        <a class="details-btn" href="/details/${album._id}">Details</a>
    </li>
    `;

export async function showCatalog(ctx) {
    const albums = await getAllAlbums();
    ctx.render(catalogTamplate(albums));
}

