import { html } from "../lit.js";
import { editTeam, getTeamData } from "../api/data.js";
import { getFormData } from "../util/util.js";

let team;
let ctx;

const editTamplate = (team) => html`
<article class="narrow">
    <header class="pad-med">
        <h1>Edit Team</h1>
    </header>
    <form @submit="${onEdit}" id="edit-form" class="main-form pad-large">
        <div class="error"></div>
        <label>Team name: <input type="text" name="name" .value="${team.name}"></label>
        <label>Logo URL: <input type="text" name="logoUrl" .value="${team.logoUrl}"></label>
        <label>Description: <textarea name="description" .value="${team.description}"></textarea></label>
        <input class="action cta" type="submit" value="Save Changes">
    </form>
</article>
`;

export async function showEdit(context) {
    ctx = context;
    team = await getTeamData(ctx.params.id);
    ctx.render(editTamplate(team));
}

async function onEdit(e) {
    e.preventDefault();
    const data = getFormData(e);
    //data._ownerId = ctx.user._id;
    await editTeam(team._id, data);
    ctx.page.redirect('/catalog');
}