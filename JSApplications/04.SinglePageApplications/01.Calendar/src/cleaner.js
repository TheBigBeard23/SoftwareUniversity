export function hideHtml() {
    [...document.querySelectorAll('section')].forEach(section => section.style.display = 'none');
}