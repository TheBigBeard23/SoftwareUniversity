function deleteByEmail() {
    let input = document.querySelector('label input').value;
    let cells = document.querySelectorAll('tbody tr td');
    let isDeleted = false;

    for (let cell of cells) {
        if (cell.textContent == input) {
            cell.parentElement.remove();
            document.getElementById('result').textContent = "Deleted.";
            isDeleted = true;
        }
    }
    if (!isDeleted) {
        document.getElementById('result').textContent = "Not found.";
    }
    document.querySelector('label input').value = '';
}