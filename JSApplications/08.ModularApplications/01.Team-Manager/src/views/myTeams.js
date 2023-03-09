import { getAllTeams } from "../api/data.js";
import { html } from "../lit.js"
import { getTeamMembers } from "../api/data.js";

let ctx;

const myTeamsTamplate = async (teams) => html`
    <section id="my-teams">
        <article class="pad-med">
            <h1>My Teams</h1>
        </article>
    
        ${teams.length == 0
        ? html`
        <article class="layout narrow">
            <div class="pad-med">
                <p>You are not a member of any team yet.</p>
                <p><a href="#">Browse all teams</a> to join one, or use the button bellow to cerate your own
                    team.</p>
            </div>
            <div class=""><a href="#" class="action cta">Create Team</a></div>
        </article>
        `
        : await Promise.all(teams.map(teamViewTamplate))}
    
    </section>
`;
const teamViewTamplate = async (team) => html`
    <article class="layout">
        <img src="${team.logoUrl}" class="team-logo left-col">
        <div class="tm-preview">
            <h2>${team.name}</h2>
            <p>${team.description}</p>
            <span class="details">${(await getTeamMembers(team._id)).length}</span>
            <div><a href="/details/${team._id}" class="action">See details</a></div>
        </div>
    </article>
`
export async function showMyTeams(context) {
    ctx = context;
    const teams = (await getAllTeams()).filter(t => t._ownerId == ctx.user._id);
    ctx.render(await myTeamsTamplate(teams));
}