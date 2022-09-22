function sortNumbers(numbers) {
    let result = new Array(numbers.length);

    for (let i = 0; i < numbers.length; i++) {

        let n = numbers[i];
        
        if (n < 0) {
            result.unshift(n);
        }
        else {
            result.push(n);
        }
    }
}
sortNumbers([7, -2, 8, 9]);