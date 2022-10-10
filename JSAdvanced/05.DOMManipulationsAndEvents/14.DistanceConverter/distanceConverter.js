function attachEventsListeners() {

    let input = document.getElementById('inputDistance');
    let output = document.getElementById('outputDistance');
    let from = document.getElementById('inputUnits');
    let to = document.getElementById('outputUnits');

    let button = document.getElementById('convert').addEventListener('click', convertDistance);

    function convertDistance() {

        let metricUnits = {
            km: 1000,
            m: 1,
            cm: 0.01,
            mm: 0.001,
            mi: 1609.34,
            yrd: 0.9144,
            ft: 0.3048,
            in: 0.0254
        };

        let inputInMeters = input.value * metricUnits[from.value];
        output.value = inputInMeters / metricUnits[to.value];

    }

}