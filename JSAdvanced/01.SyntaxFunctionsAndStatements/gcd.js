function gcd(n, m) {
    let result = 0;
    let firstNumber = n;
    let secondNumber = m;
    for (let i = 1; i <= firstNumber; i++) {

        if (firstNumber % i == 0 &&
            secondNumber % i == 0) {
            result = i;
        }
        else if (i > secondNumber) {
            break;
        }
    }
    console.log(result);
}
gcd(15, 5)