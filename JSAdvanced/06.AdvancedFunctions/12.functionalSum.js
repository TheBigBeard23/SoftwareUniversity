function add(a) {

    inner = (b) => {
        a += b;
        return inner;
    }
    inner.toString = () => a;

    return inner;
}

console.log(add(1).toString());
console.log(add(1)(6)(-3).toString());