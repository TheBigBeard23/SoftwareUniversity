
function createAssemblyLine() {
    return {
        hasClima(car) {
            car.temp = 21;
            car.tempSettings = 21;
            car.adjustTemp = () => {
                if (car.temp < car.tempSettings) {
                    car.temp++;
                }
                else if (car.temp > car.tempSettings) {
                    car.temp--;
                }
            }
        },
        hasAdudio(car) {
            car.currentTrack = {
                name: null,
                artist: null
            };
            car.nowPlaying = () => {
                car.currentTrack.name != null &&
                    car.currentTrack.artist != null ?
                    console.log(`Now playing '${currentTrack.name}' by ${currentTrack.artist}`) :
                    null;
            }
        },
        hasParktronic(car) {
            car.checkDistance = (distance) => {
                if (distance < 0.1) {
                    console.log("Beep! Beep! Beep!");
                }
                else if (0.1 <= distance < 0.25) {
                    console.log("Beep! Beep!");
                }
                else if (0.25 <= distance < 0.5) {
                    console.log("Beep! Beep!");
                }
                else {
                    console.log();
                }
            }
        }
    };
}
const assemblyLine = createAssemblyLine();

const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};
assemblyLine.hasParktronic(myCar);
myCar.checkDistance(0.4);
myCar.checkDistance(0.2);