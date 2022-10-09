function addItem() {
    let list = document.getElementById('menu');

    let text = document.getElementById('newItemText');
    let value = document.getElementById('newItemValue');

    let option = document.createElement('option');
    option.textContent = text.value;
    option.value = value.value;

    list.appendChild(option);
    text.value = '';
    value.value = '';

}