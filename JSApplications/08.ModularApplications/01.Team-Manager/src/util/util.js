export function updateNav() {
    const user = getUserData();

    if (user) {
        document.querySelectorAll("#guest").forEach(e => e.style.display = 'none');
        document.querySelectorAll("#user").forEach(e => e.style.display = 'inline-block');
    } else {
        document.querySelectorAll("#guest").forEach(e => e.style.display = 'inline-block');
        document.querySelectorAll("#user").forEach(e => e.style.display = 'none');
    }
}
export function getUserData() {
    const user = JSON.parse(sessionStorage.getItem('user'));
    return user;
}
export function getFormData(e) {
    const data = new FormData(e.target);
    return Object.fromEntries(data);
}