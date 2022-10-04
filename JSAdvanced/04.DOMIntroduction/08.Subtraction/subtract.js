function subtract() {
    let a = document.getElementById('firstNumber').value;
    let b = document.getElementById('secondNumber').value;
    document.getElementById('result').textContent = Number(a) - Number(b);
}