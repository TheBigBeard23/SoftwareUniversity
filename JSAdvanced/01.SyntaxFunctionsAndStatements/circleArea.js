function circleArea(number) {

    let typeOfNumber = typeof (number);

    if (typeOfNumber != typeof (1)) {
        console.log(`We can not calculate the circle area, because we receive a ${typeOfNumber}.`);
    }
    else {
        console.log(`${(Math.PI * number * number).toFixed(2)}`);
    }
}
circleArea(`name`);