function equalNeighbors(matrix) {

    let pairs = 0;

    function right(row, col, element) {
        if (matrix[row][col + 1] == element) {
            pairs++;
        }
    }
    function down(row, col, element) {
        if (matrix[row + 1][col] == element) {
            pairs++;
        }
    }

    for (let row = 0; row < matrix.length; row++) {

        for (let col = 0; col < matrix[row].length; col++) {

            let crnElement = matrix[row][col];

            if (row == matrix.length - 1 && col == matrix[row].length - 1) {
                break;
            }
            if (col == matrix[row].length - 1) {
                down(row, col, crnElement);
            }
            else if (row == matrix.length - 1) {
                right(row, col, crnElement);
            }
            else {
                right(row, col, crnElement);
                down(row, col, crnElement);
            }

        }
    }

    return pairs;
}

console.log(equalNeighbors(
    [['2', '3', '4', '7', '0'],
    ['4', '0', '5', '3', '4'],
    ['2', '3', '5', '4', '2'],
    ['9', '8', '7', '5', '4']]
));
