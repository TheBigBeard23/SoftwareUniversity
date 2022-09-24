function extract(arr) {
    let n = 0;
    let result = [];
    for (let i = 0; i < arr.length; i++) {
        if (n < arr[i]) {
            n = arr[i];
            result.push(n);
        }
    }
    return arr.slice(0, n)
}
console.log(extract([
    1,
    2,
    3,
    4]));