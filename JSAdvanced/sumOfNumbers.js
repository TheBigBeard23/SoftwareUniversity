function solve(n, m) {
    let firstNumber = Number(n);
    let secondNumber = Number(m);
    let result = 0;
    for (let a = firstNumber; a <= secondNumber; a++) {
        result += a;
    }
    return result;
}
console.log(solve(1, 5));