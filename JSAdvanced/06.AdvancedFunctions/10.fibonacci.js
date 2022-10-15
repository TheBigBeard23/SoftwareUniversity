function getFibonator() {
    let prevNum = 0;
    let crnNum = 1;

    function calculate() {
        let newNum = prevNum + crnNum;
        prevNum = crnNum;
        crnNum = newNum;
        return prevNum;
    }

    return calculate;
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13


