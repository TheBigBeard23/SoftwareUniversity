function spiralMatrix(height, width) {
    
    const arr = Array.from({ length: height }, () => [width]);
    let row = 0;
    let col = 0;
    let rowEnd = height - 1;
    let colEnd = width - 1;
    let counter = 1;

    while (col <= colEnd && row <= rowEnd) {

        for (let i = col; i <= colEnd; i++) {
            arr[row][i] = counter;
            counter++;
        }
        row++;

        for (let i = row; i <= rowEnd; i++) {
            arr[i][colEnd] = counter;
            counter++;
        }
        colEnd--;

        for (let i = colEnd; i >= col; i--) {
            arr[rowEnd][i] = counter;
            counter++;
        }
        rowEnd--;

        for (let i = rowEnd; i >= row; i--) {
            arr[i][col] = counter;
            counter++;
        }
        col++;
    }
    return arr.forEach(x => console.log(x.join(' ')));
}
spiralMatrix(5, 5);