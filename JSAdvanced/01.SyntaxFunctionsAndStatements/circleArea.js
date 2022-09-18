function CircleArea(number) {
    if (typeof (number) == typeof (`string`)) {
        console.log(`We can not calculate the circle area, because we receive a string.`);
    }
    else {
        console.log(`${(Math.PI * number * number).toFixed(2)}`);
    }
}
CircleArea(`name`);