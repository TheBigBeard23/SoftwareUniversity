function toJson(arr) {
    let result = [];
    class Town {
        constructor(town, latitude, longitude) {
            this.Town = town;
            this.Latitude = Number(latitude);
            this.Longitude = Number(longitude);
        }
    }
    for (let i = 1; i < arr.length; i++) {
        let [name, latitude, longitude] = arr[i]
            .split('|')
            .map(x => x.trim())
            .filter(x => x.length != 0);

        latitude = Number(latitude).toFixed(2);
        longitude = Number(longitude).toFixed(2);
        let town = new Town(name, latitude, longitude);

        result.push(town);
    }
    console.log(JSON.stringify(result));
}
toJson([
    '| Town | Latitude | Longitude |',
    '| Sofia | 42.696552 | 23.32601 |',
    '| Beijing | 39.913818 | 116.363625 |'
]);