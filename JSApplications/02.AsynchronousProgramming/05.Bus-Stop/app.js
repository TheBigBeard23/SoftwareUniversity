function getInfo() {
    let id = document.getElementById('stopId').value;
    let stopName = document.getElementById('stopName');
    let listBuses = document.getElementById('buses');

    fetch(`http://localhost:3030/jsonstore/bus/businfo/${id}`)
        .then(res => {
            listBuses.innerHTML = '';
            return res.json();
        })
        .then(res => {
            stopName.textContent = res.name;

            for (let [busId, time] of Object.entries(res.buses)) {
                listBuses.innerHTML += `<li>Bus ${busId} arrives in ${time} minutes</li>`
            }

        })
        .catch(error => {
            stopName.textContent = "Error"
        });
}