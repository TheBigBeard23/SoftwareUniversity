function solve(numbers) {
    console.log(aggregate(numbers, x => x));
    console.log(aggregate(numbers, x => 1 / x));
    console.log(aggregate(numbers, x => x.toString()).substring(1));

    function aggregate(numbers, func) {
        let result = 0;

        for (let i = 0; i < numbers.length; i++) {

            result += func(numbers[i]);
        }

        return result;
    }
} 
solve([2, 4, 8, 16])