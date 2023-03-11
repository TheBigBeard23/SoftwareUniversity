import { approveMember, becomeMember, deleteMember, getMemberships, getTeamData, getApprovedMemberships } from "../api/data.js";
import { html, nothing } from "../lit.js"
import { showModal } from "./modal.js";

let ctx;
let team;
let memberships;
let members;

const detailsTeamplate = () => html`
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
                            ? memberInterface()
                            : nothing
                        }
                        </div>
                    </div>
                    <div class="pad-large">
                        <h3>Members</h3>
                        <ul class="tm-members">
                            ${loadMembers()}
                        </ul>
                    </div>
                    ${isOwner()
                    ? html`
                     <div class="pad-large">
                        <h3>Membership Requests</h3>
                        <ul class="tm-members">
                            ${loadRequests()}
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
    members = getApprovedMemberships(memberships);
    
    ctx.render(detailsTeamplate());
}
function loadMembers() {

    const result = html`
    Your email:
    ${ctx.user 
    ? html`${ctx.user.email}`
    : html `Guest`}
    ${members.map(m => 
      html`
    <li>${m.user.email} ${isOwner() 
    ? html `<a href="javascript:void(0)" @click=${() => onDelete(m._id)} class="tm-control action">Remove from team</a>`
    : nothing}
    </li>`)}
    `
    return result;

}
function memberInterface() {

    const membership = memberships.filter(m => m._ownerId == ctx.user._id)[0];

    if (membership && membership.status == "pending") {
        return html`Membership pending. <a @click="${() => deleteMember(membership._id)}" href="javascript:void(0)"> Cancel request</a>`;
    }
    if (membership && membership.status != "pending") {
        return html`<a @click="${() => deleteMember(membership._id)}" href="javascript:void(0)" class="action invert">Leave team</a>`;
    }
    else {
        return html`
        <a href="javascript:void(0)" @click="${() => becomeMember({ teamId: team._id })}" class="action">Join team</a>`
    }

}
 function loadRequests(){

     return memberships.filter(member => member.status == "pending")
            .map(x => html`
            <li>${x.user.email}
            <a @click="${() => onApprove(x._id, x)}" href="javascript:void(0)" class="tm-control action">Approve</a>
            <a @click="${() => onDelete(x._id)}" href="javascript:void(0)" class="tm-control action">Decline</a>
            </li>`)
}
async function onApprove(id, membership){

    membership.status="member";
    await approveMember(id, membership);
}
function isOwner() {

    return ctx.user && ctx.user._id === team._ownerId;

}
function onDelete(id){
     const message = `remove user ${ctx.user.username} from the team`;
     showModal(message, deleteMember, id);
     console.log(ctx.page)
     ctx.page.redirect(ctx.page.current);

}
