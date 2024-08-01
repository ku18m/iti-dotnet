class Shape {
    constructor() {
    if (this.constructor === Shape) {
            throw new Error('Abstract class, cannot be instantiated');
        }
    }

    area() {
        throw new Error('Method is not implemented');
    }

    parameter() {
        throw new Error('Method is not implemented');
    }

    toString() {
        return `Area: ${this.area()}, Parameter: ${this.parameter()}`;
    }
}

class Rectangle extends Shape {
    constructor(width, height) {
        super();
        this.width = width;
        this.height = height;
    }

    area() {
        return this.width * this.height;
    }

    parameter() {
        return 2 * (this.width + this.height);
    }
}

class Square extends Rectangle {
    constructor(side) {
        super(side, side);
    }
}


class Circle extends Shape {
    constructor(radius) {
        super();
        this.radius = radius;
    }

    area() {
        return Math.PI * (this.radius * this.radius);
    }

    parameter() {
        return 2 * Math.PI * this.radius;
    }
}

export default { Rectangle, Square, Circle };