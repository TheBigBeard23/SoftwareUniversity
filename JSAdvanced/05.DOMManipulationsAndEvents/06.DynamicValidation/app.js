function validate() {
    let input = document.getElementById('email');

    input.addEventListener('change', (event) => {
        
        let email = event.target.value;
        let regex = /^[a-z]+@[a-z]+\.[a-z]+$/;

        if (!regex.test(email)) {
            event.target.classList.add('error');
        }
        else {
            event.target.classList.remove('error');
        }
    });
}