(function slove() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    };
    Array.prototype.skip = function (n) {
        return this.slice(n);
    };
    Array.prototype.take = function (n) {
        let result = [];
        for (let i = 0; i < n; i++) {
            result.push(this[i]);
        }
        return result;
    };
    Array.prototype.sum = function () {
        let result = 0;
        for (let i = 0; i < this.length; i++) {
            result += this[i];
        }
        return result;
    };
    Array.prototype.average = function () {
        return this.sum() / this.length;
    };
})();



const arr = [1, 2, 3, 4, 5];
console.log(arr.last());     // 3
console.log(arr.skip(1));    // [2, 3]
console.log(arr.take(1));    // [1]
console.log(arr.sum());     // 6
console.log(arr.average()); // 2