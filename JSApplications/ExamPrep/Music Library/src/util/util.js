export function updateNav() {
    if (getUser()) {
        document.querySelector('.user').style.display = 'inline-block';
        document.querySelector('.guest').style.display = 'none';
    } else {
        document.querySelector('.guest').style.display = 'inline-block';
        document.querySelector('.user').style.display = 'none';
    }
}
export function getUser() {
    return sessionStorage.getItem('user');
}
export function getFormData(e) {
    e.preventDefault();
    const data = new FormData(e.target);
    return Object.fromEntries(data);
}