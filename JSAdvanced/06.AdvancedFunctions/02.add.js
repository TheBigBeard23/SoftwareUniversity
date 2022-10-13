function solution(a) {
    function sum(b) {
        return a + b;
    }
    return sum;
}

let add5 = solution(5);
console.log(add5(2));
console.log(add5(3)); 