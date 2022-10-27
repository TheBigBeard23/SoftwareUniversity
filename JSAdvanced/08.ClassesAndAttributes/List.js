class List {
    constructor() {
        this.list = [];
        this.size = 0;
    }

    add(number) {
        this.list.push(Number(number));
        this.list.sort((a, b) => a - b);
        this.size++;
    }
    remove(index) {
        this.checkIndex(index);
        this.list.splice(index, 1);
        this.size--;
    }
    get(index) {
        this.checkIndex(index);
        return this.list[index];
    }
    checkIndex(index) {
        if (index > this.size - 1 || index < 0) {
            throw new Error("Index out of range");
        }
    }
}

let list = new List();
list.add(5);
list.add(6);
list.add(7);
console.log(list.get(1)); 
list.remove(1);
console.log(list.get(1));

