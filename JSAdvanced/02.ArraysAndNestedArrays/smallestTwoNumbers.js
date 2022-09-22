function twoSmallestNumbers(numbers) {

    numbers = numbers.sort((a, b) => a - b);
    return numbers.slice(0, 2);;
}
console.log(twoSmallestNumbers([30, 15, 50, 5]));