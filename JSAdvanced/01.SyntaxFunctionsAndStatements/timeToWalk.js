function timeToWalk(steps, footprint, speed) {

    let distanceInMeters = steps * footprint;
    let speedMetersPerSec = speed / 3.6;
    let time = distanceInMeters / speedMetersPerSec;
    let rest = Math.floor(distanceInMeters / 500);

    let timeMn = Math.floor(time / 60);
    let timeSs = Math.round(time - timeMn * 60);
    let timeH = Math.round(time / 3600);

    console.log(
        (timeH < 10 ? "0" : "") +
        timeH +
        ":" +
        (timeMn + rest < 10 ? "0" : "") +
        (timeMn + rest) +
        ":" +
        (timeSs < 10 ? "0" : "") + timeSs
    );
}
timeToWalk(4000, 0.60, 5);