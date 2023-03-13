import * as api from './api.js'

const endpoints = {
    'albums': 'data/albums?sortBy=_createdOn%20desc',
    'createAlbum': 'data/albums',
    'albumById': (id) => `data/albums/${id}`
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