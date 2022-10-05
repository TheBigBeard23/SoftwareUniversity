function search() {
    let listElements = document.querySelectorAll('ul li');
    let searchedWord = document.getElementById('searchText').value;
    let count = 0;

    for (let element of listElements) {
        if (element.textContent.match(searchedWord)) {
            element.style.fontWeight = 'bold';
            element.style.textDecoration = 'underline';
            count++;
        }
    }
    document.getElementById('result').textContent = `${count} matches found`;
}