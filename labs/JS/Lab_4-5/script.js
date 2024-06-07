// Main Global Variables
var intervals = {}; // Object to store all the intervals.


clear(); // Call clear function to hide the tasks initially.


// Handle displaying of the tasks, also clear the tasks and it's intervals.
function display(taskNumber) {
    document.getElementById('title').style.display = 'none';
    clear(); // Clear all the tasks
    console.log("Task " + taskNumber + " is displayed"); // Log the task number
    taskToDisplay = document.querySelector(`.task${taskNumber}`);
    taskToDisplay.style.display = "block";
    console.log(taskToDisplay); // Log the displayed task
}

// Clear the display and the intervals
function clear() {
    tasks = document.getElementsByClassName("task");
    console.log(intervals);
    for (var i = 0; i < tasks.length; i++) {
        tasks[i].style.display = "none";
    }
    if (intervals) {
        for (var interval in intervals) {
            clearInterval(intervals[interval]);
        }
    }
}

// Ready Go functions

// Same as main clear functions but for the circles.
function clearCircles() {
    var circles = document.getElementsByClassName("circle");
    for (var i = 0; i < circles.length; i++) {
        circles[i].style.backgroundColor = "#f8f9fa";
    }
    document.getElementById("resultPhrase").innerHTML = "";
}

// Lights interval handler
function triggerLights() {
    var light = 0;
    if (intervals['triggerLights']) {
        console.log(intervals);
        clearInterval(intervals['triggerLights']);
    }
    var interval = setInterval(function() {
        readyGo(light++);
    }, 1000);
    intervals['triggerLights'] = interval;
}

// Main ready go function that will be called in the interval
function readyGo(light) {
    clearCircles();
    console.log(light);
    switch ((light % 3) + 1) {
        case 1:
            document.getElementById("circle1").style.backgroundColor = "green";
            var phrase = document.getElementById("resultPhrase");
            phrase.innerHTML = "Go";
            phrase.style.backgroundColor = "green";
            break;
        case 2:
            document.getElementById("circle2").style.backgroundColor = "yellow";
            var phrase = document.getElementById("resultPhrase");
            phrase.innerHTML = "Ready";
            phrase.style.backgroundColor = "yellow";
            break;
        case 3:
            document.getElementById("circle3").style.backgroundColor = "red";
            var phrase = document.getElementById("resultPhrase");
            phrase.innerHTML = "Stop";
            phrase.style.backgroundColor = "red";
            break;
        default:
            break;
    }
}

// Slide Show functions
var slide = 0; // Make slide global to keep track of the current slide.

// Play Pause button handler > Play and Pause the slide show and change the button icon.
function playPause() {
    var playPauseImg = document.getElementById("play-pause").childNodes[0];
    if (playPauseImg.src.includes("play.png")) {
        playPauseImg.src = "./assets/slider/pause.png";
        triggerSlider();
    } else {
        playPauseImg.src = "./assets/slider/play.png";
        clearInterval(intervals['triggerSlider']);
    }
}

// Slide Show interval handler
function triggerSlider() {
    if (intervals['triggerSlider']) {
        clearInterval(intervals['triggerSlider']);
    }
    var interval = setInterval(function() {
        slideShow(slide++);
    }, 2000);
    intervals['triggerSlider'] = interval;
}

// Main slide show function that will be called in the interval
function slideShow(slideNum) {
    slideNum = (slideNum % 4) + 1;
    var sliderImg = document.getElementById("sliderImage");
    console.log(slideNum);
    sliderImg.src = `./assets/slider/${slideNum}.jpg`;
}

// Next and Previous button handler
function nextPrevious(direction) {
    var sliderImg = document.getElementById("sliderImage");
    var slideImgsrc = sliderImg.src;
    var slideNum = parseInt(slideImgsrc[slideImgsrc.length - 5]);
    if (direction == "next") {
        slideNum++;
    } else {
        slideNum--;
    }
    slideNum = (slideNum > 4)? 1 : slideNum;
    slideNum = (slideNum < 1)? 4 : slideNum;
    sliderImg.src = `./assets/slider/${slideNum}.jpg`;
}

// Dynamic Element Creation functions

// Entry point to add my event listener to the form submission event.
function handleForm() {
    var form = document.getElementById('elementAttrs');
    form.addEventListener("submit", processForm);
}

// Process the form data on submit.
function processForm(e) {
    e.preventDefault();
    var data = new FormData(e.target); // Create form data object
    var tagName = data.get('tagName');
    var color = data.get('color');
    var text = data.get('text');
    var element = document.createElement(tagName);
    element.style.backgroundColor = color;
    element.innerHTML = text;
    document.getElementsByClassName('task3')[0].appendChild(element); // append the element to the task3 div.
}


// Flying Window functions

// Entry point to handle the flying window.
function flyTheWindow(command) {
    var flyingWindow = window.open("", "Flying Window", "width=50,height=50");
    if (command == 'start') {
        triggerFlying(flyingWindow);
    } else if (command == 'stop') {
        clearInterval(intervals['flyingWindow']);
    } else {
        flyingWindow.close();
        clearInterval(intervals['flyingWindow']);
    }
}


// Flying interval handler.
function triggerFlying(flyingWindow) {
    if (intervals['flyingWindow'])
        clearInterval(intervals['flyingWindow']);
    var horizontal = 0;
    var vertical = 0;
    var stepH = 1;
    var stepV = 1;
    var interval = setInterval(function() {
        horizontal += stepH; // Horizontal movement step
        vertical += stepV; // Vertical movement step
        flyingWindow.moveTo(horizontal, vertical);
        if (horizontal > (screen.width - 180) || horizontal < 0) { // -180 for stucking on the edge for a while.
            console.log(screen.width);
            stepH *= -1; // Switch the horizontal step direction.
        }
        if (vertical > (screen.height - 160) || vertical < 0) { // -160 for the taskbar
            console.log(screen.height);
            stepV *= -1; // Switch the vertical step direction.
        }
    }, 1);
    intervals['flyingWindow'] = interval;
}

// Writing Window functions

// Entry point to handle the writing window.
function writingWindowHandler() {
    var writingWindow = window.open("", "Writing Window", "width=500,height=500");
    var textToWrite = document.getElementById('textToWrite').value;

    writeCharacter(writingWindow, textToWrite, 0);
}

// Main function to write the text character by character.
function writeCharacter(writingWindow, textToWrite, idx) {
    if (idx < textToWrite.length) {
        setTimeout(function () {
            writeCharacter(writingWindow, textToWrite, idx); // Recursive call to write the next character.
        }, 100);
        writingWindow.document.write(textToWrite[idx]);
        idx++;
    } else {
        console.log("Writing is done.");
        writingWindow.close();
    }
}

// Moving Marbles functions
var currentMarble = 1; // Keep track of the current marble.

// Entry point to handle the moving marbles.
function triggerMarbles() {
    if (intervals['triggerMarbles']) {
        clearInterval(intervals['triggerMarbles']);
        intervals['triggerMarbles'] = null;
        return;
    }
    var interval = setInterval(function() {
        movingMarblesHandler();
    }, 500);
    intervals['triggerMarbles'] = interval;
}

// Main function to move the marbles.
function movingMarblesHandler() {
    var prevMarble = currentMarble - 1;
    if (currentMarble > 5) {
        currentMarble = 1;
        prevMarble = 5;
    }
    if (document.getElementById(`marble${prevMarble}`)) {
        document.getElementById(`marble${prevMarble}`).src = "./assets/marbles/off.jpg";
    }
    document.getElementById(`marble${currentMarble}`).src = "./assets/marbles/on.jpg";
    console.log(currentMarble);
    currentMarble++;
}

// Students Form functions
var Students = []; // Array to store the students.

// Entry point to add my event listener to the form submission event.
function handleStudentsForm() {
    var form = document.getElementById('newStudent');
    console.log(form);
    var nameInput = form.elements['name'];
    var ageInput = form.elements['age'];
    nameInput.addEventListener("input", validateName);
    ageInput.addEventListener("input", validateAge);
    form.addEventListener("submit", processStudentsForm);
}

// Process the form data on submit.
function processStudentsForm(e) {
    e.preventDefault();
    var data = new FormData(e.target); // Create form data object
    var studentName = data.get('name');
    var studentAge = data.get('age');
    console.log(e.target.checkValidity(), "validity");
    
    var student = {name: studentName, age: studentAge};
    for (var i = 0; i < Students.length; i++) {
        if (Students[i].name == student.name && Students[i].age == student.age) {
            notificationPlaceHolderHandler("User already Exists", "failed");
            return;
        }
    }
    Students.push(student);
    notificationPlaceHolderHandler("User Added Successfully", "success");
    processTable();
    console.log(Students);
}

// Form Validation
function validateName(e) {
    var name = e.target.value;
    var nameRegex = /^[a-zA-Z]{3,}$/;
    if (!nameRegex.test(name)) {
        e.target.style.borderColor = "red";
        e.target.setCustomValidity('Name Must be 3 characters long');
        notificationPlaceHolderHandler("Name Must be 3 characters long", "failed")
    } else {
        e.target.style.borderColor = "green";
        e.target.setCustomValidity('');
        notificationPlaceHolderHandler("", "success");
    }
}

function validateAge(e) {
    var age = Number(e.target.value);
    console.log(age);
    if (age > 18 && age < 60) {
        e.target.style.borderColor = "green";
        e.target.setCustomValidity('');
        notificationPlaceHolderHandler("", "success");
    } else {
        e.target.style.borderColor = "red";
        e.target.setCustomValidity('Age must be 18-60');
        notificationPlaceHolderHandler("Age must be 18-60", "failed");
    }
}

function processTable() {
    var table = document.getElementsByClassName('studentsTable')[0];
    if (table) {
        table.remove();
    }
    if (Students.length == 0) {
        return;
    }
    table = createTable();
    document.getElementsByClassName('task7')[0].appendChild(table);
}

function createTable() {
    var table = document.createElement('table');
    var thead = document.createElement('thead');
    var tbody = document.createElement('tbody');
    var tr = document.createElement('tr');
    var th1 = document.createElement('th');
    var th2 = document.createElement('th');
    var th3 = document.createElement('th');
    var th4 = document.createElement('th');
    th1.innerHTML = "ID";
    th2.innerHTML = "Name";
    th3.innerHTML = "Age";
    th4.innerHTML = "Action";
    tr.appendChild(th1);
    tr.appendChild(th2);
    tr.appendChild(th3);
    tr.appendChild(th4);
    thead.appendChild(tr);
    table.appendChild(thead);
    table.appendChild(tbody);
    table.className = "studentsTable";
    for (var i = 0; i < Students.length; i++) {
        var tr = document.createElement('tr');
        var td1 = document.createElement('td');
        var td2 = document.createElement('td');
        var td3 = document.createElement('td');
        var td4 = document.createElement('td');
        var deleteButton = document.createElement('button');
        deleteButton.appendChild(removeImg());
        deleteButton.className = "deleteButton";
        deleteButton.setAttribute("onclick", `deleteStudent(${i})`);
        td1.innerHTML = i + 1;
        td2.innerHTML = Students[i].name;
        td3.innerHTML = Students[i].age;
        td4.appendChild(deleteButton);
        console.log(td4);
        tr.appendChild(td1);
        tr.appendChild(td2);
        tr.appendChild(td3);
        tr.appendChild(td4);
        tbody.appendChild(tr);
    }
    return table;
}

function deleteStudent(idx) {
    Students.splice(idx, 1);
    processTable();
    notificationPlaceHolderHandler("User Deleted Successfully", "success");
}

function removeImg() {
    var imgElement = document.createElement('img');
    imgElement.src = "./assets/form/delete.png";
    return imgElement;
}

function notificationPlaceHolderHandler(message, className) {
    var text = document.getElementById('notificationPlaceholder');
    text.innerHTML = message;
    text.className = className;
    notificationsTimeOut(text);
}

function notificationsTimeOut(element) {
    setTimeout(function() {
        element.innerHTML = "";
    }, 3000);
}
