var userInput = prompt("Enter a string: ");
var characterCounter = 0;

for (var stringIndex = 0; stringIndex < userInput.length; stringIndex++) {
    if (userInput[stringIndex] === "e")
        characterCounter++;
}

document.writeln("The number of 'e' characters in \"" + userInput + "\" is: " + characterCounter);
