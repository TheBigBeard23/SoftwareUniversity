function solve() {
    const [input, open, inProgress, complete] = document.querySelectorAll('section > div:nth-child(2)');
    document.querySelector('#add').addEventListener('click', addTask);

    function addTask(event) {
        event.preventDefault();

        let task = input.querySelector('#task');
        let description = input.querySelector('#description');
        let date = input.querySelector('#date');

        if (task.value &&
            description.value &&
            date.value) {

            const article = document.createElement('article');
            article.appendChild(createElement('h3', task.value));
            article.appendChild(createElement('p', `Description: ${description.value}`));
            article.appendChild(createElement('p', `Due Date: ${date.value}`));
            const div = createElement('div', '', 'flex');

            [task.value, description.value, date.value] = ['', '', ''];

            const startBtn = createElement('button', 'Start', 'green');
            const deleteBtn = createElement('button', 'Delete', 'red');
            const finishBtn = createElement('button', 'Finish', 'orange');

            div.appendChild(startBtn);
            div.appendChild(deleteBtn);
            article.appendChild(div);
            open.appendChild(article);


            startBtn.addEventListener('click', start);
            deleteBtn.addEventListener('click', remove);
            finishBtn.addEventListener('click', finish);

            function start() {
                inProgress.appendChild(article);
                startBtn.remove();
                div.appendChild(finishBtn);
            }
            function remove() {
                article.remove();
            }
            function finish() {
                div.remove();
                complete.appendChild(article);
            }
        }
    }
    function createElement(type, content, className) {
        let element = document.createElement(type);
        element.textContent = content;
        className ? element.className = className : null;
        return element;

    }
}
