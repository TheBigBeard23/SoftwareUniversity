function solve() {
    const [name, hall, price] = document.querySelectorAll('input');
    const [onScreenButton, clearButton] = document.querySelectorAll('button');
    const [moviesOnScreen, archive] = document.querySelectorAll('section ul');

    onScreenButton.addEventListener('click', addToScreen);
    clearButton.addEventListener('click', (clear));

    function addToScreen(event) {
        event.preventDefault();

        let movieName = name.value;
        let auditorium = hall.value;
        let ticketPrice = Number(price.value);

        if (movieName && auditorium && ticketPrice) {

            [name.value, hall.value, price.value] = ["", "", ""];

            const li = document.createElement('li');
            li.appendChild(createElement('span', movieName));
            li.appendChild(createElement('strong', `Hall: ${auditorium}`, ''));

            const div = createElement('div', '', '');
            div.appendChild(createElement('strong', `${ticketPrice.toFixed(2)}`));
            const input = createElement('input', '', 'Tickets Sold');
            div.appendChild(input);
            div.appendChild(createElement('button', 'Archive'));

            li.appendChild(div);

            moviesOnScreen.appendChild(li);

            div.querySelector('button').addEventListener('click', () => {

                let ticketsSold = Number(input.value);

                if (!Number.isNaN(ticketsSold) && input.value != "") {

                    let totalAmount = ticketsSold * ticketPrice;

                    li.innerHTML = '';
                    li.appendChild(createElement('span', `${movieName}`));
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
        
        Array.from(archive.children).forEach(li => li.remove());

    };

    function createElement(type, textContent, placeholder) {
        let element = document.createElement(type);
        textContent ? element.textContent = textContent : null;
        placeholder ? element.placeholder = placeholder : null;
        return element;
    };
}
