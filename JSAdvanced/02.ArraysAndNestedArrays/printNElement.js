function print(arr, n) {
    return arr.filter((x, i) => i % n == 0);
}
console.log(print([
    '5',
    '20',
    '31',
    '4',
    '20'],
    2
));
