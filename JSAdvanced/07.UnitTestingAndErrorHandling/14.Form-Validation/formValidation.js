function validate() {
    let [username, email, password, confirmPassword, isCompany, companyNumber] = document.querySelectorAll('input');
    let button = document.querySelector('button');

    isCompany.addEventListener('change', (event) => {
        let companyInfo = document.querySelector('#companyInfo');

        if (event.target.checked) {
            companyInfo.style.display = "block";
        } else {
            companyInfo.style.display = "none";
        }
    })
    button.addEventListener('click', (event) => {
        event.preventDefault();

        let nameIsValid = validateName(username.value);
        let emailIsValid = validateEmail(email.value);
        let passwordIsValid = validatePassword(password.value);
        let companyNumberIsValid = true;

        if (isCompany.checked) {
            companyNumberIsValid = validateCompanyNumber(companyNumber.value);
        }

        if (nameIsValid
            && emailIsValid
            && passwordIsValid
            && companyNumberIsValid) {

            document.querySelector('#valid').style.display = 'block';
        }
        else {
            document.querySelector('#valid').style.display = 'none';
        }
    })

    function validateName(name) {
        if (/^[A-Za-z0-9]{3,20}$/.test(name)) {
            username.style.borderColor = '';
            return true;
        }
        username.style.borderColor = 'red';
        return false;
    }
    function validateEmail(crnEmail) {
        const index = email.value.indexOf('@');
        if (index > 0 && email.value.includes('.', index)) {
            email.style.borderColor = '';
            return true;
        }
        email.style.borderColor = 'red';
        return false;

    }
    function validatePassword(crnPassword) {
        if (/^\w{5,15}$/.test(crnPassword) && crnPassword == confirmPassword.value) {
            password.style.borderColor = '';
            confirmPassword.style.borderColor = '';
            return true;
        }
        password.style.borderColor = 'red';
        confirmPassword.style.borderColor = 'red';
        return false;
    }
    function validateCompanyNumber(number) {
        if (Number(number) >= 1000 && Number(number) <= 9999) {
            companyNumber.style.borderColor = '';
            return true;
        }
        companyNumber.style.borderColor = 'red';
        return false;
    }

}
