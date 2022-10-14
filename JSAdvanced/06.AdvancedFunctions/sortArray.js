function sort(arr, order) {

    const sortFuncs = {
        asc: (a, b) => a - b,
        desc: (a, b) => b - a
    };

    arr.sort(sortFuncs[order]);

    return arr;

}
console.log(sort([10, 9, 8, 7, 6, 5], 'desc'));
