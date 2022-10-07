function addItem() {
    let li = document.createElement('li');
    let input = document.getElementById('newItemText').value;
    li.textContent = input;

    document.getElementById('items').appendChild(li);

}