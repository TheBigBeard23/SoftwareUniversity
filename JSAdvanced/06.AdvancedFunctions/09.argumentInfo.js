function solve(arr) {
    let result = {};

    for (let obj of Array.from(arr)) {
        printType(obj);
        add(obj);
    }

    Object.entries(result)
        .sort((a, b) => b[1] - a[1])
        .forEach(([type, count]) => console.log(`${type} = ${count}`));


    function printType(element) {
        console.log(`${typeof element}: ${element}`)
    }
    function add(element) {
        if (result[typeof element] == undefined) {
            result[typeof element] = 0;
        }
        result[typeof element]++;
    }
}
solve(['cat', 42, function () { console.log('Hello world!'); }]);