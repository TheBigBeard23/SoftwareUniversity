function validate() {

    let input = document.querySelector('#email').addEventListener('change', (event) => {
        if (/^[a-z]+@[a-z]+.[a-z]+$/.test(event.target.value)) {
            event.target.classList.remove('error');
        }
        else {
            event.target.classList.add('error');
        }
    });
}