function biggerHalf(numbers) {
    numbers = numbers.sort((a, b) => a - b);
    return numbers.slice(numbers.length / 2, numbers.length);
}
biggerHalf([3, 19, 14, 7, 2, 19, 6]);