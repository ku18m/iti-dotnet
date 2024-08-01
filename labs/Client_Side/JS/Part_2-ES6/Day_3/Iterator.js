
let iter_generator = function* () {
    for (let key in this) {
        yield `${key}: ${this[key]}`;
    }
}

// Test
// let obj = {
//     name: 'Mona',
//     address: 'Pet',
//     age: 30
// };
// obj[Symbol.iterator] = iter;

// for (let prop of obj) {
//     console.log(prop);
// }



let iter_iterator = function () {
    let keys = Object.keys(this);
    let idx = 0;
    return {
        next: () => {
            if (idx < keys.length) {
                return {
                    value: `${keys[idx]}: ${this[keys[idx++]]}`,
                    done: false
                }
            }
            return {
                value: undefined,
                done: true
            }
        }
    }
}

// Test
// let obj = {
//     name: 'Mona',
//     address: 'Pet',
//     age: 30
// };

// obj[Symbol.iterator] = iter_iterator;

// for (let prop of obj) {
//     console.log(prop);
// }

export default {iter_generator, iter_iterator}