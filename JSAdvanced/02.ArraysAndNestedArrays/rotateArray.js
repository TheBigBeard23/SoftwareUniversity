function rotate(arr, count) {

    count = count % arr.length;
    
    for (let i = 0; i < count; i++) {
        arr.unshift(arr.pop());
    }

    return arr.join(' ');
}
console.log(rotate([
    'Banana',
    'Orange',
    'Coconut',
    'Apple'],
    15));