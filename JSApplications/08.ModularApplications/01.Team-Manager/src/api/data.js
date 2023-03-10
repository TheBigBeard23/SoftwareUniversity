import * as api from "./api.js";

const endpoint = {
    'teams': 'data/teams',
    'team': (id) => `data/teams/${id}`,
    'membersByTeam': (id) => `data/members?where=teamId%3D%22${id}%22`,
    'allMembers': 'data/members',
    'memberships': (teamId) => `data/members?where=teamId%3D%22${teamId}%22&load=user%3D_ownerId%3Ausers`,
    'create': 'data/teams',
    'edit': (id) => `data/teams/${id}`,
    'becomeMember': 'data/members',
    'approveMember': (id) => `data/members/${id}`,
    'deleteMember': (id) => `data/members/${id}`
}


export async function getAllTeams() {
    const data = await api.get(endpoint.teams);
    return data;
}
export async function getTeamData(id) {
    const data = await api.get(endpoint.team(id))
    return data;
}
export async function getTeamMembers(id) {
    const data = await api.get(endpoint.membersByTeam(id));
    return data.filter(member => member.status == "member");
}
export async function createTeam(data) {
    try {
        const res = await api.post(endpoint.create, data);
        return res;
    } catch (err) {
        throw err;
    }
}
export async function editTeam(id, data) {
    try {
        const res = await api.put(endpoint.edit(id), data);
        return res;
    } catch (err) {
        throw err;
    }
}
export async function becomeMember(teamId) {
    const res = await api.post(endpoint.becomeMember, teamId);
    return res;
}
export async function getMemberships(teamId) {
    const res = await api.get(endpoint.memberships(teamId));
    return res;
}
export function getApprovedMemberships(memberships) {
    return memberships.filter(member => member.status == "member");
}
export async function deleteMember(id) {
    const res = await api.del(endpoint.deleteMember(id));
    return res;
}
export async function approveMember(id, data) {
    const res = await api.put(endpoint.approveMember(id), data);
    return res;
}

