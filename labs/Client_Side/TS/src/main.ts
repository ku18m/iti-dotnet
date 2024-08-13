
// 1
var arrOfNum: number[] = [1, 2, 3, 4, 5];


// 2
type stringOrNum = string | number;

var arrOfNumOrStr: stringOrNum[] = [1, 2, 3, 4, 5, 'a', 'b', 'c'];


// 3
// Define Course type
type course = {
    courseName: string,
    duration: number,
    insName: string
};

// Define function to show course details
function showCourse(course: course): void {
    console.log(course.courseName);
    console.log(course.duration);
    console.log(course.insName);
}

// Create course object
var course1: course = {
    courseName: 'Angular',
    duration: 2,
    insName: 'Arun'
};

// Call function to show course details
showCourse(course1);


// 4

// Create IEmloyee interface
interface IEmployee {
    id: number,
    name: string,
    age: number,
    address: string,
    salary: number,

    bonus: (bonusValue: number) => number;
}

// Create Class Employee that implement IEmployee interface
class Employee implements IEmployee {
    constructor(public id: number, public name: string, public age: number, public address: string, public salary: number) {
    }

    bonus(bonusValue: number): number {
        this.salary = this.salary + this.salary * bonusValue;
        return this.salary;
    }
}

// Create class manager that extends Employee class
class Manager extends Employee {
    constructor(id: number, name: string, age: number, address: string, salary: number) {
        super(id, name, age, address, salary);
    }
}

// Define Array of IEmployees
var arr: IEmployee[] = [];

// Create and add Employee objects to the arr.
for (var i = 1; i < 5; i++) {
    // Create Employee object
    var emp: IEmployee = new Employee(i, `Name ${i}`, 30 + i, `St ${i}`, 10000 + i);

    // Call bonus method
    console.log(emp.bonus(0.3));

    // Add Employee object to array
    arr.push(emp);
}

// Log the array of employees.
console.log(arr);
