import { html, render } from "../lit.js"

const body = document.querySelector('body');

const modalTamplate = (massage) => html`
<div class="overlay">
    <div class="modal">
        <p>Are you sure you want to ${massage}</p>
        <a @click=${onOkay} href="javascript:void(0)" class="action">OK</a>
        <a @click=${onCancel} href="javascript:void(0)" class="action">CANCEL</a>
    </div>
</div>
`

export function showModal(massage) {
    render(modalTamplate(massage), body);
}

function onOkay(){
    console.log("okay");
}
function onCancel(){
    console.log("cancel");
}