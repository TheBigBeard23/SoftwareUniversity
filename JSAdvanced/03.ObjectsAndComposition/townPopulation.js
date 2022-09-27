function townPopulation(towns) {

    towns = towns
        .map(x => {
            let data = x.split(" <-> ");
            return {
                name: data[0],
                population: Number(data[1])
            };
        })
        .reduce((result, town) => {
            if (result[town.name] === undefined) {
                result[town.name] = town.population;
            } else {
                result[town.name] += town.population;
            }
            return result;
        }, {});
        
    Object.entries(towns).forEach(x => {
        const [key, value] = x;
        console.log(`${key} : ${value}`);
    });
}

townPopulation([
    'Sofia <-> 1200000',
    'Montana <-> 20000',
    'New York <-> 10000000',
    'Washington <-> 2345000',
    'Las Vegas <-> 1000000']);
