function getSequence(n, k) {
    let result = new Array(n);
    result[0] = 1;
    result.fill(0, 1);

    for (let i = 1; i < n; i++) {
        let count = 0;
        let current = 0;
        for (let a = i - 1; a >= 0; a--) {
            count++;
            current += result[a];
            if (count == k) {
                break;
            }
        }
        result[i] = current;
    }
    return result;
}

console.log(getSequence(8, 4));