function buildOrbit(arr) {
    arr.map(Number);
    let width = arr[0];
    let height = arr[1];
    let x1 = arr[2];
    let y1 = arr[3];
    let matrix = [...Array(width)].map(x => Array(height))

    for (let row = 0; row < height; row++) {

        for (let col = 0; col < width; col++) {

            matrix[row][col] = Math.max(Math.abs(x1 - row), Math.abs(y1 - col)) + 1;
        }
    }

    return matrix.forEach(x => console.log(x.join(' ')));

}
buildOrbit([4, 4, 0, 0]);