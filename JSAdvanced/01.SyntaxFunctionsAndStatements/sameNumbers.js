function sameNumbers(number) {
    let sum = Array.from(number.toString())
    .map(Number)
    .reduce((a, b) => a + b, 0);
    
    let someDigit = number % 10;
    let areNotSame = Array.from(number.toString())
        .some(x => x != someDigit.toString());

    if (areNotSame) {
        console.log(false)
    }
    else {
        console.log(true);
    }
    console.log(sum);
}
sameNumbers(222);