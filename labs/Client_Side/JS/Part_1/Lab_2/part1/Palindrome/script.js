// Variables declaration
var userInput = prompt("Enter a string");
var isItCaseSensitive = confirm("Is it case sensitive?");
var rightHand = userInput.length - 1;

// Check if the user wants to make the string case sensitive
if (!isItCaseSensitive) {
    userInput = userInput.toLowerCase();
}

// Check if the string is a palindrome
for (var leftHand = 0; leftHand < userInput.length; leftHand++) {
    if (userInput[leftHand] !== userInput[rightHand]) {
        alert("Not a palindrome");
        break;
    }
    rightHand--;
    if (leftHand >= rightHand) {
        alert("It's a palindrome");
        break;
    }
}
