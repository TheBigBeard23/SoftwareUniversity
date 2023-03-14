import * as api from './api.js'

const endpoints = {
    'albums': 'data/albums?sortBy=_createdOn%20desc',
    'createAlbum': 'data/albums',
    'albumById': (id) => `data/albums/${id}`,
    'editAlbum': (id) => `data/albums/${id}`,
    'deleteAlbum': (id) => `data/albums/${id}`,
    'likesCount': (id) => `data/likes?where=albumId%3D%22${id}%22&distinct=_ownerId&count`,
    'userLikes': (albumId, userId) => `data/likes?where=albumId%3D%22${albumId}%22%20and%20_ownerId%3D%22${userId}%22&count`,
    'addLike': 'data/likes'
}

export async function getAllAlbums() {
    return await api.get(endpoints.albums);
}
export async function getAlbum(id) {
    return await api.get(endpoints.albumById(id));
}
export async function createAlbum(data) {
    return await api.post(endpoints.createAlbum, data);
}
export async function editAlbum(id, data) {
    return await api.put(endpoints.editAlbum(id), data)
}
export async function deleteAlbum(id) {
    return await api.del(endpoints.deleteAlbum(id));
}
export async function getLikesCount(id) {
    return await api.get(endpoints.likesCount(id));
}
export async function getUserLikes(albumId, userId) {
    return await api.get(endpoints.userLikes(albumId, userId));
}
export async function addLike(albumId) {
    return await api.post(endpoints.addLike, { albumId });
}