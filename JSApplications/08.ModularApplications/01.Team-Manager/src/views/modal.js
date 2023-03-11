const body = document.querySelector('body');
const div = document.createElement('div');

div.className = 'overlay';
div.innerHTML = `
<div class="modal">
<p></p>
<a href="javascript:void(0)" id="modal-ok" class="action">OK</a>
<a href="javascript:void(0)" id="modal-cancel" class="action">CANCEL</a>
</div>
`;

div.querySelector("#modal-ok").addEventListener('click', () => onClick(true))
div.querySelector("#modal-cancel").addEventListener('click', () => onClick(false))

let operation;
let params;

export function showModal(message, callback, ...prms) {
    operation = callback;
    params = prms;
    div.querySelector('p').textContent = `Are you sure you want to ${message}?`
    body.appendChild(div);
}

function onClick(choice) {

    if (choice) {
        operation(...params);
    }
    
    div.remove();
}