function solve(numbers) {
    let result = [];

    for (let i = 0; i < numbers.length; i += 2) {
        result.push(numbers[i]);
    }

    console.log(result.join(" "));
}
solve(['20', '30', '40', '50', '60']);