function attachGradientEvents() {
    let gradient = document.getElementById('gradient-box');
    let result = document.getElementById('result');

    gradient.addEventListener('mousemove', (event) => {
        let percentage = Math.trunc(event.offsetX / 300 * 100);
        result.textContent = percentage + '%';
    })
}