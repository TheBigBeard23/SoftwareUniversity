function attack(matrix) {
    let firstSum = 0;
    let secondSum = 0;

    for (let row = 0; row < matrix.length; row++) {
        matrix[row] = matrix[row].split(' ').map(Number);
    }
    for (row = 0; row < matrix.length; row++) {
        firstSum += matrix[row][row];

        let lastIndex = matrix.length - 1;
        secondSum += matrix[row][lastIndex - row];
    }
    if (firstSum == secondSum) {

        for (let row = 0; row < matrix.length; row++) {
            for (let col = 0; col < matrix.length; col++) {

                if (row != col &&
                    col != matrix.length - 1 - row) {
                    matrix[row][col] = firstSum;
                }
            }
        }
    }
    return matrix.join(' ' + `\n`);
}
console.log(attack([
    '5 3 12 3 1',
    '11 4 23 2 5',
    '101 12 3 21 10',
    '1 4 5 2 2',
    '5 22 33 11 1']));