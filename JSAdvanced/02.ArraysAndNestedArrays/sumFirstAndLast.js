function sumFirstLast(numbers) {
    numbers = numbers.map(Number);
    let result = numbers.shift() + numbers.pop();
    return result;
}
console.log(sumFirstLast(['20', '30', '40']));