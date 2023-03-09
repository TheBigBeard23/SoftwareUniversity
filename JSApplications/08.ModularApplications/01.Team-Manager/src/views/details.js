import { approveMember, becomeMember, getMemberships, getTeamData } from "../api/data.js";
import { html,nothing } from "../lit.js"

let ctx;
let team;
let memberships;

const detailsTeamplate = async (members, memberships) => html`
            <section id="team-home">
                <article class="layout">
                    <img src="${team.logoUrl}" class="team-logo left-col">
                    <div class="tm-preview">
                        <h2>${team.name}</h2>
                        <p>${team.description}</p>
                        <span class="details">${members.length} Members</span>
                        <div>
                            ${isOwner()
                            ? html`<a href="/edit/${team._id}" class="action">Edit team</a>`
                            : ctx.user
                            ? memberInterface(memberships)
                            : nothing
                        }
                        </div>
                    </div>
                    <div class="pad-large">
                        <h3>Members</h3>
                        <ul class="tm-members">
                            ${loadMembers(members)}
                        </ul>
                    </div>
                    ${isOwner()
                    ? html`
                     <div class="pad-large">
                        <h3>Membership Requests</h3>
                        <ul class="tm-members">
                            ${await loadRequests(memberships)}
                        </ul>
                    </div>
                    `
                    : nothing}     
                </article>
            </section>
`;

export async function showDetails(context) {

    ctx = context;
    team = await getTeamData(ctx.params.id);

    memberships = await getMemberships(team._id);
    const members = getTeamMembers(memberships);
    
    ctx.render(await detailsTeamplate(members, memberships));
}
function loadMembers(members) {
    console.log(members);
    const result = html`
    Your nickname:
    ${ctx.user 
    ? html`${ctx.user.username}`
    : html `Guest`}
    ${members.map(m => 
      html`
    <li>${m.user.username} ${isOwner() 
    ? html `<a href="#" class="tm-control action">Remove from team</a>`
    : nothing}
    </li>`)}
    `
    return result;

}
function memberInterface(memberships) {

    if (memberships.filter(m => m._ownerId == ctx.user._id && m.status == "pending").length > 0) {
        return html`Membership pending. <a href="#"> Cancel request</a>`;
    }
    if (memberships.filter(m => m._ownerId == ctx.user._id && m.status != "pending").length > 0) {
        return html`<a href="javascript:void(0)" class="action invert">Leave team</a>`;
    }
    else {
        return html`
        <a href="javascript:void(0)" @click=${joinTeam} class="action">Join team</a>`
    }


}
async function loadRequests(){
    memberships = await getMemberships(team._id);
     return memberships.filter(member => member.status == "pending")
            .map(x => html`
            <li>${x.user.email}
            <a @click="${() => onApprove(x._id, x)}" href="javascript:void(0)" class="tm-control action">Approve</a>
            <a href="javascript:void(0)" class="tm-control action">Decline</a>
            </li>`)
}
async function onApprove(id, membership){
    membership.status="member";
    await approveMember(id, membership);
}
function isOwner() {
    return ctx.user && ctx.user._id === team._ownerId;
}
function getTeamMembers(memberships) {
    return memberships.filter(member => member.status == "member");
}
async function joinTeam() {
   await becomeMember({ teamId: team._id });
   let membership =  (await getMemberships(team._id)).pop();
   //membership.user.username = ctx.user.username;
   console.log(ctx.user);
   console.log(membership);
   await approveMember(membership._id, membership);
}