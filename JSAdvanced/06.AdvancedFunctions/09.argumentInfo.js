function solve(arr) {
    let result = {};

    arr.forEach(x => {
        printType(x);
        add(x);
    })

    Object.entries(result)
        .sort((a, b) => b[1] - a[1])
        .forEach(x => console.log(`${x[0]} = ${x[1]}`));


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
solve(['cat', 42, 3, function () { console.log('Hello world!'); }]);