"use strict";
// 1
var arrOfNum = [1, 2, 3, 4, 5];
var arrOfNumOrStr = [1, 2, 3, 4, 5, 'a', 'b', 'c'];
// Define function to show course details
function showCourse(course) {
    console.log(course.courseName);
    console.log(course.duration);
    console.log(course.insName);
}
// Create course object
var course1 = {
    courseName: 'Angular',
    duration: 2,
    insName: 'Arun'
};
// Call function to show course details
showCourse(course1);
// Create Class Employee that implement IEmployee interface
class Employee {
    constructor(id, name, age, address, salary) {
        this.id = id;
        this.name = name;
        this.age = age;
        this.address = address;
        this.salary = salary;
    }
    bonus(bonusValue) {
        this.salary = this.salary + this.salary * bonusValue;
        return this.salary;
    }
}
// Create class manager that extends Employee class
class Manager extends Employee {
    constructor(id, name, age, address, salary) {
        super(id, name, age, address, salary);
    }
}
// Define Array of IEmployees
var arr = [];
// Create and add Employee objects to the arr.
for (var i = 1; i < 5; i++) {
    // Create Employee object
    var emp = new Employee(i, `Name ${i}`, 30 + i, `St ${i}`, 10000 + i);
    // Call bonus method
    console.log(emp.bonus(0.3));
    // Add Employee object to array
    arr.push(emp);
}
// Log the array of employees.
console.log(arr);
