function solve(arr) {
    let result = [];
    let count = 1;
    for (let comand of arr) {
        switch (comand) {
            case 'add': result.push(count); break;
            case 'remove': result.pop(); break;
        }
        count++;
    }
    if (result.length == 0) {
        return 'Empty';
    }
    return result.join('\n');
}
console.log(solve([
    'add',
    'add',
    'add',
    'add']
));