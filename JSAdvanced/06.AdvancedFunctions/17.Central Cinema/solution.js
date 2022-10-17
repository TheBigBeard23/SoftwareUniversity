function solve() {
    const [name, hall, price] = document.querySelectorAll('input');
    const [onScreenButton, clearButton] = document.querySelectorAll('button');
    const [moviesOnScreen, archive] = document.querySelectorAll('section ul');

    onScreenButton.addEventListener('click', addToScreen);
    clearButton.addEventListener('click', (clear));


    function addToScreen(event) {
        event.preventDefault();

        if (name.value && hall.value && Number(price.value)) {
            const li = document.createElement('li');
            li.appendChild(createElement('span', name.value));
            li.appendChild(createElement('strong', `Hall: ${hall.value}`, ''));

            const div = createElement('div', '', '');
            div.appendChild(createElement('strong', `${Number(price.value).toFixed(2)}`));
            const input = createElement('input', '', 'Tickets Sold');
            div.appendChild(input);
            div.appendChild(createElement('button', 'Archive'));

            li.appendChild(div);

            moviesOnScreen.appendChild(li);

            div.querySelector('button').addEventListener('click', () => {

                if (Number(input.value)) {

                    let totalAmount = Number(input.value) * Number(price.value);

                    li.innerHTML = '';
                    li.appendChild(createElement('span', `${name.value}`));
                    li.appendChild(createElement('strong', `Total amount: ${totalAmount.toFixed(2)}`));
                    let deleteButton = createElement('button', 'Delete');
                    li.appendChild(deleteButton);

                    archive.appendChild(li);

                    deleteButton.addEventListener('click', () => li.remove());
                }
            });
        }
    }
    function clear() {
        archive.remove();

    };
}
function createElement(type, textContent, placeholder) {
    let element = document.createElement(type);
    textContent ? element.textContent = textContent : null;
    placeholder ? element.placeholder = placeholder : null;
    return element;
}