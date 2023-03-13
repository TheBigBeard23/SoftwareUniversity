import { html } from "../lit.js";
import { editAlbum, getAlbum } from "../api/data.js";
import { getFormData } from "../util/util.js";

let ctx;
let album;

const editTamplate = () => html`
    <section id="edit">
        <div class="form">
            <h2>Edit Album</h2>
            <form @submit=${onEdit} class="edit-form">
                <input type="text" name="singer" id="album-singer" placeholder="Singer/Band" value="${album.singer}" />
                <input type="text" name="album" id="album-album" placeholder="Album" value="${album.album}" />
                <input type="text" name="imageUrl" id="album-img" placeholder="Image url" value="${album.imageUrl}" />
                <input type="text" name="release" id="album-release" placeholder="Release date" value="${album.release}" />
                <input type="text" name="label" id="album-label" placeholder="Label" value="${album.label}" />
                <input type="text" name="sales" id="album-sales" placeholder="Sales" value="${album.sales}" />
    
                <button type="submit">post</button>
            </form>
        </div>
    </section>
`;

export async function showEdit(context) {
    ctx = context;
    album = await getAlbum(ctx.params.id)
    ctx.render(editTamplate());
}

async function onEdit(e) {
    const data = getFormData(e);
    console.log(data);
    await editAlbum(album._id, data);
    ctx.page.redirect('/catalog');
}