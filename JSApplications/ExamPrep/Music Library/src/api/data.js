import * as api from './api.js'

const endpoints = {
    'albums': 'data/albums?sortBy=_createdOn%20desc',
    'createAlbum': 'data/albums',
    'albumById': (id) => `data/albums/${id}`,
    'editAlbum': (id) => `data/albums/${id}`,
    'deleteAlbum': (id) => `data/albums/${id}`
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