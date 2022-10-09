function lockedProfile() {
    document.getElementById('main').addEventListener('click', showInformation);

    function showInformation(event) {

        let type = event.target.type;

        if (type == 'submit') {

            if (event.target.parentElement.children[4].checked) {

                let hiddenElement = event.target.parentElement.children[9];

                if (hiddenElement.style.display == '') {
                    hiddenElement.style = 'display:block'
                    event.target.textContent = 'Hide it'
                }
                else {
                    hiddenElement.style = 'display:'
                    event.target.textContent = 'Show more'
                }
            }
        }

    }
}