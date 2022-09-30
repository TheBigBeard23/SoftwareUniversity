function createSortedList() {
    class List {
        constructor() {
            this.list = [];
            this.size = 0;
        }
        sort() {
            return this.list = this.list.sort((a, b) => a - b);
        }
        add(element) {
            this.list.push(element);
            this.size++;
            return this.sort();
        }
        remove(index) {
            if (this.list.length - 1 >= index && index >= 0) {
                for (let i = index; i < this.list.length - 1; i++) {
                    this.list[i] = this.list[i + 1];
                }
                this.size--;
                return this.sort();
            }
            throw new Error('Index otside boundary');
        }
        get(index) {
            if (this.list.length - 1 >= index && index >= 0) {
                return this.list[index];
            }
            throw new Error('Index otside boundary');

        }
    }
    return new List();
}
let list = createSortedList();
list.add(5);
list.add(6);
list.add(3);
list.add(2);
list.add(1);
list.add(4);
list.get(list.size() - 1);