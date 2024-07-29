// Part_1
//1- Write a function that takes an array of numbers and returns a new array containing only the positive numbers.

function getPositiveNumbers(array) {
    return array.filter((number) => number > 0);
}

// 2- Write a function that takes an array of numbers and returns the sum of all the numbers.(reduce)

function sumOfNumbers(array) {
    return array.reduce((acc, number) => acc + number);//, 100); If I wanna set Initial value.
}

// 3- Write a function that takes an array of names and returns a new array with each name capitalized.

function capitalizedWords(array) {
    return array.map((word) => word[0].toUpperCase() + word.slice(1));
}

// 4-Write a JavaScript program to check whether a string is lower case or not.

function isLower(string) {
    return string === string.toLowerCase();
}

// 5-Write an arrow function that takes an array of strings and a length, and returns a new array containing only the strings with length greater than the specified value.

let getOverLenStrings = (array, lengthToCheck) => {
    return array.filter((str) => str.length > lengthToCheck);
};

// Part_2

// 1- Swap the values of two variables using destructing.
let var1 = 10;
let var2 = 20;

//console.log(`var1: ${var1}, var2: ${var2}`);

[var1, var2] = [var2, var1];

//console.log(`var1: ${var1}, var2: ${var2}`);

/**
 * Using rest parameter and spread operator return max value from any array
 *  note: array length is not fixed return min and max value and display each of
 *  them separately after function call
*/

let minMax = (...array) => {
    let min = Math.min(...array);
    let max = Math.max(...array);
    return [min, max];
};

let [min, max] = minMax(20, 30, 60, 10, -100, 200, 250, -250);

// console.log(`Min: ${min}, Max: ${max}`);

/**
* Study new array api methods then create the following methods and apply
* it on this array var fruits = ["apple", "strawberry", "banana", "orange",
* "mango"]
* a. test that every element in the given array is a string
* b. test that some of array elements starts with "a"
* c. generate new array filtered from the given array with only elements that
*   starts with "b" or "s"
* d. generate new array each element of the new array contains a string
*   declaring that you like the give fruit element
* e. use forEach to display all elements of the new array from previous point
*/

var fruits = ["apple", "strawberry", "banana", "orange", "mango"];


// a
let isString = fruits.every((fruit) => typeof fruit === 'string');


// b
let startsWith_a = fruits.some((fruit) => fruit[0] === 'a');


// c
let arrStartsWith_b_s = fruits.filter((fruit) => fruit[0] === 'b' || fruit[0] === 's');


// d
let messagesArr = fruits.map((fruit => `I Love ${fruit}`));


// e
messagesArr.forEach((message) => console.log(message));