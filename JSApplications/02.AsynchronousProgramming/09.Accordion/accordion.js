solution();

function solution() {

    const main = document.getElementById('main');

    fetch(`http://localhost:3030/jsonstore/advanced/articles/list`)
        .then(res => res.json())
        .then(res => {

            for (let article of res) {

                fetch(`http://localhost:3030/jsonstore/advanced/articles/details/${article._id}`)
                    .then(res => res.json())
                    .then(res => {
                        createBlock(res);
                    })
                    .catch();
            }
        })
        .catch();

    function createBlock(data) {
        let div = createElement('div', '', 'accordion', '', main);

        let head = createElement('div', '', 'head', '', div);
        createElement('span', data.title, '', '', head);
        let btn = createElement('button', 'More', 'button', ['id', data._id], head);
        btn.addEventListener('click', showMore);

        let extra = createElement('div', '', 'extra', '', div);
        createElement('p', data.content, '', '', extra);
    }
    function showMore(event) {
        let btn = event.target;
        let extra = btn.parentNode.nextSibling;

        if (btn.textContent == 'More') {
            extra.style.display = 'block';
            btn.textContent = 'Less';
        } else {
            extra.style.display = 'none';
            btn.textContent = 'More';
        }
    }
}

function createElement(type, textContent, className, attribute, parentNode) {

    let element = document.createElement(type);
    if (textContent) { element.textContent = textContent };
    if (className) { element.classList.add(className) };
    if (Array.isArray(attribute)) { element.setAttribute(attribute[0], attribute[1]) };
    if (parentNode) { parentNode.appendChild(element) };

    return element;
}
