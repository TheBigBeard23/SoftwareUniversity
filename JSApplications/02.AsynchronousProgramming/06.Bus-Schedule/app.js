function solve() {

    const departBtn = document.getElementById('depart');
    const arriveBtn = document.getElementById('arrive');
    const info = document.querySelector('#info span');

    let nextStopId = 'depot';
    let stopName;

    function depart() {

        fetch(`http://localhost:3030/jsonstore/bus/schedule/${nextStopId}`)
            .then(res => res.json())
            .then(res => {
                stopName = res.name;
                nextStopId = res.next;

                info.textContent = `Next stop ${stopName}`;
            })
            .catch();

        departBtn.disabled = true;
        arriveBtn.disabled = false;
    }

    function arrive() {

        info.textContent = `Arriving at ${stopName}`;

        departBtn.disabled = false;
        arriveBtn.disabled = true;
    }

    return {
        depart,
        arrive
    };
}

let result = solve();