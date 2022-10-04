function colorizeTable() {
    let rows = document.querySelectorAll('table tr')

    for (let i = 1; i < rows.length; i += 2) {
        document.querySelectorAll('table tr')[i].style = 'background-color: teal';
    }
}