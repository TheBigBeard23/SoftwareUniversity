function sort(arr) {
    arr
        .sort((a, b) => a.length - b.length || a.localeCompare(b));

    return arr.join(`\n`);
}
console.log(sort([
    'alpha',
    'beta',
    'gamma']));