function addItem() {
    let items = document.getElementById('items');
    let input = document.getElementById('newItemText').value;

    let a = document.createElement('a');
    a.href = '#';
    a.textContent = '[Delete]';

    a.addEventListener('click',  (event) => {
        event.target.parentElement.remove();
    });

    let li = document.createElement('li');
    li.textContent = input;
    li.appendChild(a);
    items.appendChild(li);
}