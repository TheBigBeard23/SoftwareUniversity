function addCars(input) {
    let cars = {};

    input.forEach(x => {
        let [brand, model, quantity] = x.split(' | ');
        if (!cars.hasOwnProperty(brand)) {
            cars[brand] = {};
        }
        if (!cars[brand].hasOwnProperty(model)) {
            cars[brand][model] = 0;
        }
        cars[brand][model] += Number(quantity);
    });

    for (let brand in cars) {
        console.log(brand);
        Object.entries(cars[brand]).forEach(x => {
            console.log(`###${x[0]} -> ${x[1]}`);
        })
    }
}
addCars(
    ['Audi | Q7 | 1000',
        'Audi | Q6 | 100',
        'BMW | X5 | 1000',
        'BMW | X6 | 100',
        'Citroen | C4 | 123',
        'Volga | GAZ-24 | 1000000',
        'Lada | Niva | 1000000',
        'Lada | Jigula | 1000000',
        'Citroen | C4 | 22',
        'Citroen | C5 | 10']
);