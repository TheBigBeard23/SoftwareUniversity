function solve() {
    let buttons = document.querySelector('tfoot').addEventListener('click', operations);
    let table = document.querySelector('tbody');
    let result = document.querySelector('#check p');

    function operations(event) {
        if (event.target.textContent == 'Quick Check') {

            if (checkMatrix()) {
                result.style.color = 'green';
                table.parentElement.style.border = "2px solid green";
                result.textContent = "You solve it! Congratulations!";
            }
            else {
                result.style.color = 'red';
                table.parentElement.style.border = "2px solid red";
                result.textContent = "NOP! You are not done yet...";
            }

        } else if (event.target.textContent == 'Clear') {

            let cells = table.querySelectorAll('tr td input');
            for (let cell of cells) {
                cell.value = '';
            }
            result.textContent = '';
            table.parentElement.style.border = 'none';

        }

        function checkMatrix() {

            let rows = [
                [0, 0, 0],
                [0, 0, 0],
                [0, 0, 0]
            ];
            let cols = [
                [0, 0, 0],
                [0, 0, 0],
                [0, 0, 0]
            ];

            let matrix = table.querySelectorAll('tr');

            for (row = 0; row < matrix.length; row++) {

                let crnCol = matrix[row].querySelectorAll('td input');

                for (col = 0; col < crnCol.length; col++) {
                    rows[row][col] = crnCol[col].value;
                    cols[col][row] = crnCol[col].value;
                }
            }

            for (let row = 0; row < rows.length; row++) {

                for (let col = 0; col < rows[row].length; col++) {

                    if (rows[row].filter(x => x == rows[row][col]).length > 1 ||
                        cols[row].filter(x => x == cols[row][col]).length > 1) {
                        return false;
                    }
                }
            }
            return true;

        }
    }
}