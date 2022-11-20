import { displayMonths } from "./months.js";

const yearsSection = document.querySelector('#years');

yearsSection.querySelector('tbody').addEventListener('click', (e) => {

    let year;
    if (e.target.className == 'date') {
        year = e.target.textContent;
    }
    else if (e.target.className == 'day') {
        year = e.target.children[0].textContent;
    }
    displayMonths(year);

});

export function displayYears() {

    yearsSection.style.display = 'block';

}