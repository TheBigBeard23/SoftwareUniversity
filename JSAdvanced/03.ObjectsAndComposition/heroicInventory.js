function solve(arr) {
    let result = [];
    for (let line of arr) {
        let [name, level, items] = line.split(' / ');
        level = Number(level);
        items == undefined ? items = [] : items = items.split(', ');
        result.push({
            name: name,
            level: level,
            items: items
        })
    }
    console.log(JSON.stringify(result));
}

    solve([
        'Isacc / 25 ',
        'Derek / 12 / BarrelVest, DestructionSword',
        'Hes / 1 / Desolator, Sentinel, Antara']
    )
