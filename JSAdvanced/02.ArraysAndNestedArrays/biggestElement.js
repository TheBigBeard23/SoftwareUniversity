function biggestNumber(matrix) {
    let result = matrix[0][0];

    for (let row = 0; row < matrix.length; row++) {
        for (let col = 0; col < matrix[row].length; col++) {
            if (result < matrix[row][col]) {
                result = matrix[row][col]
            }
        }
    }

    return result;
}
console.log(biggestNumber([[20, 50, 10], [8, 33, 145]]));
