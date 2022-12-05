function classHierarchy() {

    class Figure {
        constructor() {
            this.units = 'cm';
        }
        get area() { }

        changeUnits(units) {
            this.units = units;
        }
        calculateUnits(value) {
            const unitsCollection = {
                m: (x) => x / 10,
                cm: (x) => x,
                mm: (x) => x * 10,
            };
            return unitsCollection[this.units](value);
        }
        toString() {
            return `Figures units: ${this.units}`
        }
    }

    class Circle extends Figure {
        constructor(radius) {
            super();
            this._radius = radius;
        }
        get area() {
            this.radius = this.calculateUnits(this._radius);
            return this.calculateUnits(this.radius ** 2 * Math.PI);
        }
        toString() {
            return `${super.toString()} Area: ${this.area} - radius: ${this.radius}`
        }

    }

    class Rectangle extends Figure {
        constructor(width, height, units) {
            super();
            this._width = width;
            this._height = height;
            this.units = units;
        }
        get area() {
            this.width = this.calculateUnits(this._width);
            this.height = this.calculateUnits(this._height);
            return this.width * this.height;
        }
        toString() {
            return `${super.toString()} Area: ${this.area} - width: ${this.width}, height: ${this.height}`
        }

    }

    return {
        Figure,
        Circle,
        Rectangle
    }
}

let obj = classHierarchy();

let c = new obj.Circle(5);
console.log(c.area); // 78.53981633974483
console.log(c.toString()); // Figures units: cm Area: 78.53981633974483 - radius: 5

let r = new obj.Rectangle(3, 4, 'mm');
console.log(r.area); // 1200
console.log(r.toString()); //Figures units: mm Area: 1200 - width: 30, height: 40

r.changeUnits('cm');
console.log(r.area); // 12
console.log(r.toString()); // Figures units: cm Area: 12 - width: 3, height: 4

c.changeUnits('mm');
console.log(c.area); // 7853.981633974483
console.log(c.toString()); // Figures units: mm Area: 7853.981633974483 - radius: 50