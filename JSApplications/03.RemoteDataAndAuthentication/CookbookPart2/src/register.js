document.querySelector('form').addEventListener('submit', onSubmit);

async function onSubmit(e) {
    e.preventDefault();

    const formData = new FormData(e.target);
    const { email, password, rePass } = Object.fromEntries(formData.entries());

    if (email
        && password
        && rePass
        && password == rePass) {

        try {
            const res = await fetch('http://localhost:3030/users/register', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify({
                    email,
                    password
                })
            });

            if (!res.ok) {
                const err = await res.json();
                throw new Error(err.message);
            }

            const resData = await res.json();

            localStorage.setItem('accessToken', resData.accessToken);
            window.location.pathname = 'CookbookPart2/index.html';

        } catch (err) {
            alert(err.message);
        }

    }
}