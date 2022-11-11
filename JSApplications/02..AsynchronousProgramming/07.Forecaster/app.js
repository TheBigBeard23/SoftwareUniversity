function attachEvents() {

    const weatherSymbols = {
        'Sunny': '&#x2600;',
        'Partly sunny': '&#x26C5;',
        'Overcast': '&#x2601;',
        'Rain': '&#x2614;',
        'Degrees': '&#176;'
    };

    const location = document.getElementById('location');
    const getBtn = document.getElementById('submit');
    const infoDiv = document.getElementById('forecast');
    const crnInfoDiv = document.getElementById('current');
    const upcomingInfoDiv = document.getElementById('upcoming');
    const baseUrl = 'http://localhost:3030/jsonstore/forecaster/';

    getBtn.addEventListener('click', () => {

        let crnForecast = document.querySelector('#current .forecast');
        let upcomingForecast = document.querySelector('#upcoming .forecast-info');

        if (crnForecast) {
            crnForecast.remove();
            upcomingForecast.remove();
        }

        let city = fetch(`${baseUrl}locations`)
            .then(res => res.json())
            .then(res => {

                let city = res.find(x => x.name == location.value);
                if (!city) { throw new Error('Invalid location!'); }

                getForecast(city);
                getUpcomingForecast(city);
            })
            .catch(err => {
                infoDiv.style.display = 'block';
                document.querySelector('#current div').textContent = "Error";
            });
    });

    function getForecast(city) {

        infoDiv.style.display = 'block';

        fetch(`${baseUrl}today/${city.code}`)
            .then(res => res.json())
            .then(res => {

                let div = createElement('div', '', 'forecast');
                let spanSymbol = createElement('span', weatherSymbols[res.forecast.condition], 'condition symbol');
                let spanCondition = createElement('span', '', 'condition');
                let spanCity = createElement('span', res.name, 'forecast-data');
                let spanDegrees = createElement('span', `${res.forecast.low}&#176;/${res.forecast.high}&#176;`, 'forecast-data');
                let spanSecondSymbol = createElement('span', res.forecast.condition, 'forecast-data');

                div.appendChild(spanSymbol);
                div.appendChild(spanCondition);
                spanCondition.appendChild(spanCity);
                spanCondition.appendChild(spanDegrees);
                spanCondition.appendChild(spanSecondSymbol);

                crnInfoDiv.appendChild(div);
            })
            .catch(err => {
                document.querySelector('#current div').textContent = "Error";
            });

    }
    function getUpcomingForecast(city) {

        fetch(`${baseUrl}upcoming/${city.code}`)
            .then(res => res.json())
            .then(res => {

                let div = createElement('div', '', 'forecast-info');
                upcomingInfoDiv.appendChild(div);
                appendChilds(div, res.forecast);
            })
            .catch(err => {
                document.querySelector('#upcoming div').textContent = "Error";
            });
    }
    function appendChilds(element, forecasts) {

        for (let forecast of forecasts) {

            let [condition, high, low] = Object.values(forecast);

            let span = createElement('span', '', 'upcoming');
            span.appendChild(createElement('span', weatherSymbols[condition], 'symbol'));
            span.appendChild(createElement('span', `${low}&#176;/${high}&#176;`, 'forecast-data'));
            span.appendChild(createElement('span', condition, 'forecast-data'));
            element.appendChild(span);

        }
    }
    function createElement(type, textContent, className) {
        let element = document.createElement(type);
        textContent ? element.innerHTML = textContent : null;
        className ? element.className = className : null;

        return element;

    }
}

attachEvents();