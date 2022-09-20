function cookingByNumbers(number,...params) {

    let commands = new Array(params);

    for (let i = 0; i < params.length; i++) {
        number = calculate(params[i], number);
        console.log(number);
    }

    function calculate(command, number) {
        switch (command) {
            case 'chop': return number / 2;
            case 'dice': return Math.sqrt(number);
            case 'spice': return number + 1;
            case 'bake': return number * 3;
            case 'fillet': return number - (number * 0.2);
        }
    }
}

cookingByNumbers('32', 'chop', 'chop', 'chop', 'chop', 'fillet');
