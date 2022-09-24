function magic(matrix) {

    let sum = matrix[0].reduce((sum, x) => sum + x);

    for (let row = 0; row < matrix.length; row++) {

        let rowSum = 0;
        let colSum = 0;

        for (let col = 0; col < matrix[row].length; col++) {

            if (col < matrix.length) {
                rowSum += matrix[col][row];
            }
            
            colSum += matrix[row][col];

        }
        if (rowSum != sum ||
            colSum != sum) {
            return false;
        }
    }

    return true; 

}
console.log(
    magic([
        [4, 5, 6],
        [6, 5, 4],
        [5, 5, 5]]));