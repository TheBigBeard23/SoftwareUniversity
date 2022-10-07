function solve() {

    const selectMenu = document.getElementById('selectMenuTo');

    const binaryOption = document.createElement('option');
    binaryOption.textContent = 'Binary';
    binaryOption.value = 'binary';
    const hexadcimalOption = document.createElement('option');
    hexadcimalOption.textContent = 'Hexadecimal';
    hexadcimalOption.value = 'hexadecimal';

    selectMenu.appendChild(binaryOption);
    selectMenu.appendChild(hexadcimalOption);

    document.querySelectorAll('#selectMenuTo option')[0].remove;

    document.querySelectorAll('#selectMenuTo option')
    .filter(function() {
        return !this.value || $.trim(this.value).length == 0 || $.trim(this.text).length == 0;
    })
   .remove();
    document.querySelector('button').addEventListener('click', convert);
    function convert() {
        let number = parseFloat(document.getElementById('input').value);
        let type = selectMenu.value;
        let result = document.getElementById('result');

        if (type == 'hexadecimal') {
            result.value = number.toString(16).toUpperCase();
        }
        else if (type == 'binary') {
            result.value = number.toString(2);
        }
    }

}