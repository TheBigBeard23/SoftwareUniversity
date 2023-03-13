import { getUser } from "../util/util.js";

const host = `http://localhost:3030/`;

async function request(method, url, data) {

    const user = JSON.parse(getUser());

    const option = {
        method,
        headers: {}
    }

    if (data) {
        option.headers["Content-Type"] = "application/json";
        option.body = JSON.stringify(data);
    }

    if (user) {
        option.headers["X-Authorization"] = user.accessToken;
    }

    try {
        const res = await fetch(host + url, option);

        if (!res.ok) {

            if (res.status === 403) {
                sessionStorage.removeItem('user');
            }

            const error = await res.json();
            throw new Error(error.message);
        }
        if (res.status == 204) {
            return res;
        }
        else {
            return res.json();
        }

    } catch (error) {
        throw error;
    }

}

const get = request.bind(null, 'get');
const post = request.bind(null, 'post');
const del = request.bind(null, 'delete');
const put = request.bind(null, 'put');

export {
    get,
    post,
    del,
    put
}