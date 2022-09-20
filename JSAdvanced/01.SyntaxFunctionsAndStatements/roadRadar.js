function radar(speed, area) {

    switch (area) {
        case "motorway":
            printResult(130, speed); break;
        case "interstate":
            printResult(90, speed); break;
        case "city":
            printResult(50, speed); break;
        case "residential":
            printResult(20, speed); break;
    } 

    function printResult(motorwayLimit, speed) {

        let overTheLimit = speed - motorwayLimit;

        if (overTheLimit <= 0) {
            console
                .log(`Driving ${speed} km/h in a ${motorwayLimit} zone`);
        }
        else {
            console
                .log(`The speed is ${overTheLimit} km/h faster than the allowed speed of ${motorwayLimit} - ${getStatus(overTheLimit)}`);
        }
        
    }

    function getStatus(speedOverTheLimit) {

        if (speedOverTheLimit <= 20) {
            return 'speeding';
        }
        else if (speedOverTheLimit <= 40) {
            return 'excessive speeding';
        }
        else {
            return 'reckless driving';
        }
    }

}

radar(21, 'residential');