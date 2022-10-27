function juiceFlavors(input) {

    class Storage {
        constructor() {
            this.fruits = {};
            this.juices = {};
        }

        addFruit(fruit, quantity) {

            if (this.fruits[fruit] == undefined) {
                this.fruits[fruit] = 0;
            }
            this.fruits[fruit] += Number(quantity);

            this.makeJuice(fruit);
        }

        addJuice(juice, quantity) {

            if (this.juices[juice] == undefined) {
                this.juices[juice] = 0;
            }
            this.juices[juice] += Number(quantity);
        }

        makeJuice(fruit) {

            if (this.fruits[fruit] >= 1000) {
                let quantity = Math.floor(this.fruits[fruit] / 1000);
                this.fruits[fruit] -= quantity * 1000;
                this.addJuice(fruit, quantity);
            }
        }
        
        print() {
            Object.entries(this.juices).forEach(x => console.log(`${x[0]} => ${x[1]}`));
        }
    }

    let storage = new Storage();

    for (let line of input) {
        let [fruit, quantity] = line.split(' => ');
        storage.addFruit(fruit, quantity);
    }

    storage.print();
}

juiceFlavors(
    ['Kiwi => 234',
'Pear => 2345',
'Watermelon => 3456',
'Kiwi => 4567',
'Pear => 5678',
'Watermelon => 6789']
);