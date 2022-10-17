function calculator() {

    let firstNum = null;
    let secondNum = null;
    let output = null;

    function init(firstInput, secondInput, result) {

        firstNum = document.querySelector(firstInput);
        secondNum = document.querySelector(secondInput);
        output = document.querySelector(result);

    }
    function add() {
        output.value = Number(firstNum.value) + Number(secondNum.value);
    }
    function subtract() {
        output.value = Number(secondNum.value) - Number(firstNum.value);
    }

    return {
        init,
        add,
        subtract
    }

}

const calculate = calculator();
calculate.init('#num1', '#num2', '#result');



