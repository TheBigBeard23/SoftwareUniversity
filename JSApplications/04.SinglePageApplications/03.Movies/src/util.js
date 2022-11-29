const views = [...document.querySelectorAll('.view-section')];
const userElements = document.querySelectorAll('.user');
const guestElements = document.querySelectorAll('.guest');
const greeting = document.querySelector('#welcome-msg');

export function hideElements(elements) {
    elements
        ? elements.forEach(s => s.style.display = 'none')
        : views.forEach(s => s.style.display = 'none');
}

export function showView(section) {
    hideElements();
    section.style.display = 'block';
}
export function auth() {
    const user = JSON.parse(localStorage.getItem('user'));
    if (user) {
        userElements.forEach(el => el.style.display = 'inline-block');
        guestElements.forEach(el => el.style.display = 'none');
        greeting.textContent = `Welcome, ${user.email}`;
    }
    else {
        userElements.forEach(el => el.style.display = 'none');
        guestElements.forEach(el => el.style.display = 'inline-block');
        greeting.textContent = "";
    }
}
