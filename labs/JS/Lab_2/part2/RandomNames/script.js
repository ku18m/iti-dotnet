var names = ["Saber", "Sara", "Mona", "Ali", "Mahmoud", "Mazen"];
// Choose two random names from the names with no equality validation.
var choosenNames = [
    names[Math.floor(Math.random() * names.length)],
    names[Math.floor(Math.random() * names.length)],
];


// To not match the same name twice, you can use the following code:
var firstNameIdx = Math.floor(Math.random() * names.length);
var secondNameIdx = Math.floor(Math.random() * names.length);
while (secondNameIdx === firstNameIdx) {
    secondNameIdx = Math.floor(Math.random() * names.length);
}
choosenNames = [names[firstNameIdx], names[secondNameIdx]];

document.write(`<h1>Choosen names are ${choosenNames.join(" and ")}.</h1>`);
