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

            const data = await res.json();

            if (res.ok) {
                localStorage.setItem('accessToken', data.accessToken);
                window.location.pathname = '07.CookbookPart2/index.html';
            }
            else {
                throw new Error(data.message);
            }

        } catch (err) {
            alert(err.message);
        }

    }
}