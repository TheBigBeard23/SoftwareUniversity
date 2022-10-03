function calculate(arr) {
    let operands = arr.filter(x => /-?\d+/.test(x));
    let operators = arr.filter(x => /^[\/+*-]$/.test(x));
    let numbers = [];

    if (operands.length - operators.length > 1) {
        console.log("Error: too many operands!");
        return;
    }
    else if (operands.length - operators.length < 1) {
        console.log("Error: not enough operands!");
        return;
    }
    else {

        while (arr.length > 0) {

            let n = arr.shift();

            if (Number(n)) {
                numbers.push(n);
            }
            else {

                let a = numbers.pop();
                let b = numbers.pop();
                let newNum = 0;

                switch (n) {
                    case '+':
                        newNum = b + a;
                        break;
                    case '-':
                        newNum = b - a;
                        break;
                    case '/':
                        newNum = b / a;
                        break;
                    case '*':
                        newNum = b * a;
                        break;
                }

                numbers.push(Math.ceil(newNum));
            }
        }
    }
    console.log(numbers[0]);
}

calculate([
    5,
    3,
    4,
    '*',
    '-'
]);