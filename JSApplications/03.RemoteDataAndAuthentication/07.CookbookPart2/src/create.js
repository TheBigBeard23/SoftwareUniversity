const url = `http://localhost:3030/data/recipes`;
const form = document.querySelector('form');
form.addEventListener('submit', createRecipe);

function createRecipe(e) {
    e.preventDefault();

    const formData = new FormData(e.target);
    const token = localStorage.getItem('accessToken');

    const body = JSON.stringify({
        name: formData.get('name'),
        img: formData.get('img'),
        ingredients: formData.get('ingredients').trim().split('\n'),
        steps: formData.get('steps').trim().split('\n')
    });

    fetch(url, {
        method: 'POST',
        headers: {
            'Content-Type': 'applitcation/json',
            'X-Authorization': token
        },
        body
    })
        .then(res => {
            if (res.status == 200) {
                window.location.pathname = '07.CookbookPart2/index.html';
            }
            else {
                throw new Error(res.json());
            }
        })
        .catch(err => alert(err.message));

}