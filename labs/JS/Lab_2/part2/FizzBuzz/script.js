// Talking number from the user
var userNumber = prompt("Enter a number: ");
var outPut = "";
if (userNumber % 3 == 0)
    outPut += "fizz";
if (userNumber % 5 == 0)
    outPut += "buzz";

document.writeln(`<h1>${outPut? outPut: "none"}</h1>`);
