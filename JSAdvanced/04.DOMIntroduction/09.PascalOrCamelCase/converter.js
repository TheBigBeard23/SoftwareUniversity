function convert() {
    let input = document.getElementById('text').value;
    let currentCase = document.getElementById('naming-convention').value;

    let result = '';
    let words = input.split(' ').map(x => x.trim());

    if (currentCase == 'Camel Case') {
        words = words
            .map(x => x.toLowerCase())
            .map(x => x[0].toUpperCase() + x.slice(1));
        words[0] = words[0].toLowerCase();
    }
    else if (currentCase == 'Pascal Case') {
        words = words
            .map(x => x.toLowerCase())
            .map(x => x[0].toUpperCase() + x.slice(1));
    }
    else {
        return document.getElementById('result').textContent = 'Error!';
    }
    result = words.join('');
    document.getElementById('result').textContent = result;
}