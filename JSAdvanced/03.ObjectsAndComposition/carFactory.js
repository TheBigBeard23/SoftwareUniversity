function carFactory(wantedCar) {
    let engines = [
        { power: 90, volume: 1800 },
        { power: 120, volume: 2400 },
        { power: 200, volume: 3500 }
    ];
    let carriages = [
        { type: 'hatchback', color: wantedCar.color },
        { type: 'coupe', color: wantedCar.color }
    ];
    let wheelsize =
        wantedCar.wheelsize % 2 == 0
            ? wantedCar.wheelsize - 1
            : wantedCar.wheelsize;

    return {
        model: wantedCar.model,
        engine: engines.filter(e => e.power >= wantedCar.power)[0],
        carriage: carriages.filter(c => c.type == wantedCar.carriage)[0],
        wheels: [0, 0, 0, 0].fill(wheelsize, 0)
    };
}
console.log(
    carFactory({
        model: 'VW Golf II',
        power: 90,
        color: 'blue',
        carriage: 'hatchback',
        wheelsize: 14
    }));