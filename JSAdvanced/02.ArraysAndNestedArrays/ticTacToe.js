function play(arr) {

    let matrix = [
        [false, false, false],
        [false, false, false],
        [false, false, false]];

    let playerWin = false;
    let player = 'X';
    let fields = 9;

    while (arr.length > 0 && !playerWin && fields > 0) {

        let [row, col] = arr.shift().split(' ').map(Number);

        if (!matrix[row][col]) {

            fields--;
            matrix[row][col] = player;
            
            if (checkForWin(player)) {
                playerWin = true;
                break;
            }
            player = player == 'X' ? 'O' : 'X';
        }
        else {
            console.log("This place is already taken. Please choose another!");
        }

    }
    if (playerWin) {
        console.log(`Player ${player} wins!`);
    }
    else {
        console.log(`The game ended! Nobody wins :(`);
    }
    matrix.forEach(line => {
        console.log(line.join('\t'));
    });
    function checkForWin(symbol) {

        for (let i = 0; i < 3; i++) {
            if (matrix[i][0] === symbol &&
                matrix[i][1] === symbol &&
                matrix[i][2] === symbol) {
                return true;
            }
            if (matrix[0][i] === symbol &&
                matrix[1][i] === symbol &&
                matrix[2][i] === symbol) {
                return true;
            }
        }

        if ((matrix[0][0] === symbol &&
            matrix[1][1] === symbol &&
            matrix[2][2] === symbol) ||
            (matrix[2][0] === symbol &&
                matrix[1][1] === symbol &&
                matrix[0][2] === symbol)) {
            return true;
        }
    }
}
play([
    "0 1",
    "0 0",
    "0 2",
    "2 0",
    "1 0",
    "1 2",
    "1 1",
    "2 1",
    "2 2",
    "0 0"]);