function sumColumn() {
    let rowsInfo = document.querySelectorAll('td');
    let result = 0;

    for (let i = 1; i < rowsInfo.length; i += 2) {
        result += Number(rowsInfo[i].textContent);
    }

    document.getElementById('sum').textContent = result;
}