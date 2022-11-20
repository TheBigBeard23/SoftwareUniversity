import { hideHtml } from "./cleaner.js";

const months = {
    Jan: '1',
    Feb: '2',
    Mar: '3',
    Apr: '4',
    May: '5',
    Jun: '6',
    Jul: '7',
    Aug: '8',
    Sept: '9',
    Oct: '10',
    Nov: '11',
    Dec: '12'
}

export function displayMonths(year) {
    hideHtml();

    const month = document.querySelector(`#year-${year}`);
    month.style.display = 'block';

    month.addEventListener('click', (e) => displayDays(e, year))
}

function displayDays(e, year) {
    let month;

    if (e.target.className == 'date') {
        month = e.target.textContent;
    }
    else if (e.target.className == 'day') {
        month = e.target.children[0].textContent;
    }

    hideHtml();
    document.querySelector(`#month-${year}-${months[month]}`).style.display = 'block';
}

