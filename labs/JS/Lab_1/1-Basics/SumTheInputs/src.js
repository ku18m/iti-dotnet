var sumOfTheInputs = 0;
var userInput = 0;

while(true) {
    input = Number(prompt("Enter a number: "));
    if(input == 0 || isNaN(input) || (sumOfTheInputs + input) > 100) {
        break;
    }
    sumOfTheInputs += input;
}

document.writeln("Sum of the inputs: " + sumOfTheInputs);
