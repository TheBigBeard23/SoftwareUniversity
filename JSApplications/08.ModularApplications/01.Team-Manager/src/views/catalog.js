import { getAllTeams, getTeamMembers } from "../api/data.js";
import { html, nothing } from "../lit.js"

let ctx;

const catalogTamplate = async (teams) => html`
            <section id="browse">
                <article class="pad-med">
                    <h1>Team Browser</h1>
                </article>
            
                ${ctx.user 
                ? html`<article class="layout narrow">
                    <div class="pad-small"><a href="/create" class="action cta">Create Team</a></div>
                </article>`
                : nothing}
            
                ${await Promise.all(teams.map(cardTemplate))}
            </section>
`;

const cardTemplate = async (team) => html`
<article class="layout">
    <img src="${team.logoUrl}" class="team-logo left-col">
    <div class="tm-preview">
        <h2>${team.name}</h2>
        <p>${team.description}</p>
        <span class="details">${await getMembersCount(team._id)}</span>
        <div><a href="/details/${team._id}" class="action">See details</a></div>
    </div>
</article>
`;

export async function showCatalog(context) {
    ctx = context;
    ctx.render(await catalogTamplate(await getAllTeams()));
}

async function getMembersCount(id) {
    const members = await getTeamMembers(id);
    return members.length;
}