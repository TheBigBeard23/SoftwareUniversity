function encodeAndDecodeMessages() {
    let divs = document.querySelectorAll('div');

    let sender = divs[1].querySelector('textarea');
    let receiver = divs[2].querySelector('textarea');

    document.getElementById('container').addEventListener('click', sendMessage);

    function sendMessage(event) {
        if (event.target.type == 'submit' &&
            event.target.innerText.startsWith('Encode')) {

            let message = sender.value;
            sender.value = '';
            message = encodeMessage(1, message);
            receiver.value = message;

        }
        else {
            let message = receiver.value;
            message = encodeMessage(-1, message);
            receiver.value = message;
        }
    }

    function encodeMessage(encodingValue, message) {
        let codedMessage = '';
        for (let i = 0; i < message.length; i++) {
            codedMessage += String.fromCharCode(message.charCodeAt(i) + encodingValue);
        }
        return codedMessage;
    }


}