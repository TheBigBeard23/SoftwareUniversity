import { getAlbum } from "../api/data.js";
import { html, nothing } from "../lit.js";

let ctx;

const detailsTemplate = (album) => html`
    <section id="details">
        <div id="details-wrapper">
            <p id="details-title">Album Details</p>
            <div id="img-wrapper">
                <img src="${album.imageUrl}" alt="example1" />
            </div>
            <div id="info-wrapper">
                <p><strong>Band:</strong><span id="details-singer">${album.singer}</span></p>
                <p>
                    <strong>Album name:</strong><span id="details-album">${album.album}</span>
                </p>
                <p><strong>Release date:</strong><span id="details-release">${album.release}</span></p>
                <p><strong>Label:</strong><span id="details-label">${album.label}</span></p>
                <p><strong>Sales:</strong><span id="details-sales">${album.sales}</span></p>
            </div>
            <div id="likes">Likes: <span id="likes-count">0</span></div>
    
            <!--Edit and Delete are only for creator-->
            ${ctx.user
            ? html`
            <div id="action-buttons">
                ${ctx.user._id !== album._ownerId
                ? html`
                <a href="" id="like-btn">Like</a>
                `
                : html`
                <a href="/edit/${album._id}" id="edit-btn">Edit</a>
                <a href="" id="delete-btn">Delete</a>
                `}
            </div>
            `
            : nothing}
        </div>
    </section>
`;

export async function showDetails(context) {
    ctx = context;
    const album = await getAlbum(ctx.params.id)
    ctx.render(detailsTemplate(album));
}