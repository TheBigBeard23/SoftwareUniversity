import { post } from '.api.js';

export async function getAll() {
    return post('linka');
}