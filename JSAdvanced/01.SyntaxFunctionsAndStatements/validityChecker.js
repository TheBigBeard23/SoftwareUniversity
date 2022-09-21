function pointsChecker(x1, y1, x2, y2) {

    let result = calculateDistance(x1, y1, 0, 0);
    printResult(result, x1, y1, 0, 0);

    result = calculateDistance(x2, y2, 0, 0);
    printResult(result, x2, y2, 0, 0);

    result = calculateDistance(x1, y1, x2, y2);
    printResult(result, x1, y1, x2, y2);

    function calculateDistance(x1, y1, x2, y2) {
        
        return Math.sqrt(((x2 - x1) ** 2) + ((y2 - y1) ** 2));
    }
    
    function printResult(number, x1, y1, x2, y2) {

        if (Number.isInteger(number)) {
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is valid`)
        }
        else {
            console.log(`{${x1}, ${y1}} to {${x2}, ${y2}} is invalid`)
        }
    }
}

pointsChecker(2, 1, 1, 1);