const baseUrl = `http://localhost:3030/users/login`;
const form = document.querySelector('form');

form.addEventListener('submit', async (e) => {
    e.preventDefault();

    let formData = new FormData(e.currentTarget);

    let data = {
        email: formData.get('email'),
        password: formData.get('password')
    };

    try {
        
        if (!data.email) {
            throw new Error('Email is required!');
        }
        if (!data.password) {
            throw new Error('Password is required!');
        }

        const res = await fetch(baseUrl, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        });

        if (res.status != 200) {
            const err = await res.json();
            throw new Error(err.message);
        }

        const responseData = await res.json();

        localStorage.setItem('accessToken', responseData.accessToken);
        window.location.pathname = 'CookbookPart2/index.html';

    } catch (error) {
        alert(error.message);
    }



});