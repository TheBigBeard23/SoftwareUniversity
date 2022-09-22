function diagonalSums(matrix) {
    let firstDiagonalIndex = 0;
    let secondDiagonalIndex = matrix.length - 1;

    let firstSum = 0;
    let secondSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        firstSum += matrix[row][firstDiagonalIndex + row];
        secondSum += matrix[row][secondDiagonalIndex - row]
    }

    return [firstSum, secondSum];
}
console.log(diagonalSums([[20, 40],
                          [10, 60]]));