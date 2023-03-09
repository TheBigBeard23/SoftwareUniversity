import { createTeam } from '../api/data.js';
import { html } from '../lit.js'
import { getFormData } from '../util/util.js';

let ctx;

const createTamplate = () => html`
<article class="narrow">
    <header class="pad-med">
        <h1>New Team</h1>
    </header>
    <form @submit=${onCreate} id="create-form" class="main-form pad-large">
        <div class="error"></div>
        <label>Team name: <input type="text" name="name"></label>
        <label>Logo URL: <input type="text" name="logoUrl"></label>
        <label>Description: <textarea name="description"></textarea></label>
        <input class="action cta" type="submit" value="Create Team">
    </form>
</article>
`;

export function showCreate(context) {
    ctx = context;
    ctx.render(createTamplate());
}

async function onCreate(e) {
    e.preventDefault();
    const data = getFormData(e);
    try {
        await createTeam(data);
        ctx.page.redirect('/catalog');

    } catch (err) {
        document.querySelector('.error').textContent = err.message;
    }

}