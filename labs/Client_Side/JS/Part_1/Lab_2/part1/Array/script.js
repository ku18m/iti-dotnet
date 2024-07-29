function threeElementsArray() {
    var arr = [];

    //Taking numbers from the user
    for (let i = 0; i < 3; i++) {
        arr.push(Number(prompt(`Enter number ${i + 1}: `)));
    }

    //Making calculations
    var sum = arr[0];
    var multiplication = arr[0];
    var division = arr[0];
    for (var idx = 1; idx < arr.length; idx++) {
        sum += arr[idx];
        multiplication *= arr[idx];
        division /= arr[idx];
    }

    //Creating the output
    var documentOutput = `
    <h1>Adding -- Multiplying -- and dividing ${arr.length} values</h1>
    <hr>
    <p><span class="colored">sum of the ${arr.length} values</span> ${arr.join(" + ")} = ${sum}</p>
    <p><span class="colored">multiplication of the ${arr.length} values </span>${arr.join(" / ")} = ${multiplication}</p>
    <p><span class="colored">division of the ${arr.length} values</span> ${arr.join(" * ")} = ${division}</p>
    `;

    // Returning the output
    return documentOutput;
}

function fiveElementsArray() {
    var arr = [];
    
    //Taking numbers from the user
    for (let i = 0; i < 5; i++) {
        arr.push(Number(prompt(`Enter number ${i + 1}: `)));
    }
    
    //Sorting the array
    var descendingOrderArray = [...arr].sort(function (a, b) {return b - a});
    var ascendingOrderArray = [...arr].sort(function (a, b) {return a - b});

    //Creating the output
    var documentOutput = `
    <h1>Sorting</h1>
    <hr>
    <p><span class="colored">u've entered </span>${arr.join()}</p>
    <p><span class="colored">ur values after being sorted descending </span>${descendingOrderArray.join()}</p>
    <p><span class="colored">ur values after being sorted ascending </span>${ascendingOrderArray.join()}</p>
    `;
    
    // Returning the output
    return documentOutput;
}

function mathTask() {
    // Defining the functions
    var circleArea = function () {
        var circleRadius = Number(prompt('What is the value of your circles raduis'));
        alert(`Total area of the circle is ${Math.PI * Math.pow(circleRadius, 2)}`);
    }

    var squareRoot = function () {
        var number = Number(prompt('What is the value you want to calculate its square root'));
        alert(`square root of ${number} is ${Math.sqrt(number)}`);
    }

    var angleCosValue = function () {
        var angle = Number(prompt('What is the angle value'));
        document.writeln(`<p>cos ${angle}&deg is ${Math.round(Math.cos((angle * Math.PI) / 180))}</p>`);
    }
    
    // Taking the task number
    var taskNumber = prompt('Enter the task number:\n1/Circle Area\n2/Square Root\n3/Angle cos value\n');
    switch (taskNumber) {
        case '1':
            circleArea();
            break;
        case '2':
            squareRoot();
            break;
        case '3':
            angleCosValue();
            break;
        default:
            alert('Invalid task number');
            break;
    }

}

var taskNumer = prompt('Enter the task number:\n1/Three elements array\n2/Five elements array\n3/Math task\n');
var output;
switch (taskNumer) {
    case '1':
        output = threeElementsArray();
        break;
    case '2':
        output = fiveElementsArray();
        break;
    case '3':
        mathTask();
        break;
    default:
        alert('Invalid task number');
        break;
}
if (output)
    document.writeln(output);
