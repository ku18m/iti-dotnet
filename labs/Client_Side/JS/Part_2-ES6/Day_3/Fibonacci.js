// Febonacci series
let feb_iter_counter = function () {
    let counter = 0;
    let first = 0;
    let second = 1;
    let values = [];
    return {
        next: iter = elementsCountMax => {
            if (counter < elementsCountMax) {
                let temp = first;
                first = second;
                second = temp + first;
                counter++;
                values.push(first);
                return iter(elementsCountMax);
            }
            return {
                value: values,
                done: true
            }
        }
    }
}

// Test
// let arr = [];

// arr[Symbol.iterator] = feb_iter_counter;

// console.log(arr[Symbol.iterator]().next(10));

let feb_generator_counter = function* (elementsCountMax) {
    let counter = 0;
    let first = 0;
    let second = 1;

    while (counter < elementsCountMax) {
        yield first;
        let temp = first;
        first = second;
        second = temp + first;
        counter++;
    }
}

// Test
// let generator = feb_generator_counter(10);

// for (let value of generator) {
//     console.log(value);
// }


let feb_iter_value = function () {
    let first = 0;
    let second = 1;
    let values = [];
    return {
        next: iter = maxValue => {
            if (first <= maxValue) {
                values.push(first);
                let temp = first;
                first = second;
                second = temp + first;
                return iter(maxValue);
            }
            return {
                value: values,
                done: true
            }
        }
    }
}

// Test
// let arr = [];

// arr[Symbol.iterator] = feb_iter_value;

// console.log(arr[Symbol.iterator]().next(10));


let feb_generator_value = function* (maxValue) {
    let first = 0;
    let second = 1;

    while (first < maxValue) {
        yield first;
        let temp = first;
        first = second;
        second = temp + first;
    }
}


// Test
// let generator = feb_generator_value(10);

// for (let value of generator) {
//     console.log(value);
// }

export default {feb_iter_counter, feb_generator_counter, feb_iter_value, feb_generator_value}