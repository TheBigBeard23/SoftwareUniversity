function solve(firstNumber, secondNumber, operator) {
    let result;

    switch (operator) {
        case '+': result = firstNumber + secondNumber; break;
        case '-': result = firstNumber - secondNumber; break;
        case '/': result = firstNumber / secondNumber; break;
        case '*': result = firstNumber * secondNumber; break;
        case '%': result = firstNumber % secondNumber; break;
        case '**': result = firstNumber ** secondNumber; break;
    }

    console.log(result);
}
solve(5, 2, '+');
solve(5, 2, '-');