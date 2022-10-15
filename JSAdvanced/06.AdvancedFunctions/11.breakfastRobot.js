function solution() {
    let stock = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    }

    const recipes = {
        apple: {
            carbohydrate: 1,
            flavour: 2
        },
        lemonade: {
            carbohydrate: 10,
            flavour: 20
        },
        burger: {
            carbohydrate: 5,
            fat: 7,
            flavour: 3
        },
        eggs: {
            protein: 5,
            fat: 1,
            flavour: 1
        },
        turkey: {
            protein: 10,
            carbohydrate: 10,
            fat: 10,
            flavour: 10
        }
    }

    let processes = {
        restock: (microelement, quantity) => {
            stock[microelement] += Number(quantity);
            return 'Success';
        },
        prepare: (recipe, count) => {

            for (let ingredient of Object.entries(recipes[recipe])) {
                let name = ingredient[0];
                let quantity = ingredient[1] * count;

                if (stock[name] >= quantity) {
                    stock[name] -= quantity;
                }
                else {
                    return `Error: not enough ${name} in stock`;
                }
            }
            return 'Success';

        },
        report: () =>
            `protein=${stock['protein']} carbohydrate=${stock['carbohydrate']} fat=${stock['fat']} flavour=${stock['flavour']}`
    }

    function processor(input) {
        let [command, entity, quantity] = input.split(' ');
        let result = processes[command](entity, quantity);
        return result;

    }
    return processor;
}

let manager = solution();
console.log(manager('restock carbohydrate 10'));
console.log(manager('restock flavour 10'));
console.log(manager('prepare apple 1'));
console.log(manager('restock fat 10'));
console.log(manager('prepare burger 1'));
console.log(manager('report'));

