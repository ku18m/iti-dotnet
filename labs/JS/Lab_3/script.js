document.onload = clear();
function display(taskNumber) {
    document.getElementById('title').style.display = 'none';
    clear(); // Clear all the tasks
    console.log("Task " + taskNumber + " is displayed");
    taskToDisplay = document.querySelector(`.task${taskNumber}`);
    taskToDisplay.style.display = "block";
    console.log(taskToDisplay)
}


function clear() {
    tasks = document.getElementsByClassName("task");
    for (var i = 0; i < tasks.length; i++) {
        tasks[i].style.display = "none";
}
}

function countElements() {
    // Getting the values from the input fields
    var tagName = document.getElementById("tagName").value;
    var className = document.getElementById("className").value;
    var id = document.getElementById("id").value
    var name = document.getElementById("name").value;
    
    // Getting the elements from the document
    var tagNameElements = document.getElementsByTagName(tagName);
    var classNameElements = document.getElementsByClassName(className);
    var idElement = document.getElementById(id);
    var nameElements = document.getElementsByName(name);

    // Displaying the count of elements
    document.getElementById("tagNameResult").innerHTML = tagNameElements.length;
    document.getElementById("classNameResult").innerHTML = classNameElements.length;
    document.getElementById("idResult").innerHTML = idElement ? 1 : 0;
    document.getElementById("nameResult").innerHTML = nameElements.length;
}

function clearCircles() {
    var circles = document.getElementsByClassName("circle");
    for (var i = 0; i < circles.length; i++) {
        circles[i].style.backgroundColor = "#f8f9fa";
    }
    document.getElementById("resultPhrase").innerHTML = "";
}

function readyGo() {
    var inputValue = document.getElementById("readyGoInput").value;
    clearCircles();
    console.log(inputValue);
    switch (inputValue[0]) {
        case "1":
            document.getElementById("circle1").style.backgroundColor = "green";
            var phrase = document.getElementById("resultPhrase");
            phrase.innerHTML = "Go";
            phrase.style.backgroundColor = "green";
            break;
        case "2":
            document.getElementById("circle2").style.backgroundColor = "yellow";
            var phrase = document.getElementById("resultPhrase");
            phrase.innerHTML = "Ready";
            phrase.style.backgroundColor = "yellow";
            break;
        case "3":
            document.getElementById("circle3").style.backgroundColor = "red";
            var phrase = document.getElementById("resultPhrase");
            phrase.innerHTML = "Stop";
            phrase.style.backgroundColor = "red";
            break;
        default:
            break;
    }
}

function manipulateArray() {
    var array = document.getElementById("arrayToManipulate").value.split(", ");
    var max = 0;
    var secondMax = 0;
    var min = array[array.length - 1];
    var secondMin = array[array.length - 1];
    for (var i = 0; i < array.length; i++) {
        if (Number(array[i] > max) ) {
            secondMax = max;
            max = Number(array[i]);
        } else if (Number(array[i]) > secondMax && Number(array[i]) != max) {
            secondMax = Number(array[i]);
        }
        if (Number(array[i]) < min) {
            secondMin = min;
            min = Number(array[i]);
        } else if (Number(array[i]) < secondMin && Number(array[i]) != min) {
            secondMin = Number(array[i]);
        }
    }
    document.getElementById("secondMaxElm").innerHTML = secondMax;
    document.getElementById("secondMinElm").innerHTML = secondMin;
}
function capitalizeString() {
    var string = document.getElementById("stringToCapitalize").value;
    var words = string.split(" ");
    var capitalizedWords = [];
    for (var i = 0; i < words.length; i++) {
        capitalizedWords.push(words[i].charAt(0).toUpperCase() + words[i].slice(1));
    }
    document.getElementById("capitalizedString").innerHTML = capitalizedWords.join(" ");
}
