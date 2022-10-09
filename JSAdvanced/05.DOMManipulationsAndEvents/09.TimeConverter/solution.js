function attachEventsListeners() {
    let daysValue = document.getElementById('days');
    let hoursValue = document.getElementById('hours');
    let minutesValue = document.getElementById('minutes');
    let secondsValue = document.getElementById('seconds');

    let buttons = document.querySelector('main').addEventListener('click', (event) => {

        if (event.target.type == 'button') {
            let value = event.target.parentElement.children[1].value;
            let typeOfInput = event.target.parentElement.children[1].id;
            let timeInSeconds = 0;

            switch (typeOfInput) {
                case 'days':
                    timeInSeconds = value * 86400;
                    break;
                case 'hours':
                    timeInSeconds = value * 3600;
                    break;
                case 'minutes':
                    timeInSeconds = value * 60;
                    break;
                case 'seconds':
                    timeInSeconds = Number(value);
                    break;

            }

            daysValue.value = timeInSeconds / 86400;
            hoursValue.value = timeInSeconds / 3600;
            minutesValue.value = timeInSeconds / 60;
            secondsValue.value = timeInSeconds;
        }

    });
}