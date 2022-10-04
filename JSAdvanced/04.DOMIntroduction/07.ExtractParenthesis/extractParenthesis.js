function extract(content) {
    let text = document.getElementById(content).textContent;
    let regex = /\([^)]+\)/g;
    let result = text.match(regex);
    return result.join(';');
}