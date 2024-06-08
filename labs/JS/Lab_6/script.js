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


// Reverse Array functions

// Entry point to add my event listener to the form submission event.
function handleReverseArrayForm() {
    var form = document.getElementById('reverseArray');
    form.addEventListener("submit", processReverseArrayForm);
}


// Process the form data on submit.
function processReverseArrayForm(e) {
    e.preventDefault();
    var outPutDiv = document.getElementsByClassName('reverseMethod')[0];
    var data = new FormData(e.target); // Create form data object
    var array = data.get('array');
    array = array.split(",");
    for (var i = 0; i < array.length; i++) {
        if (Number(array[i]))
            array[i] = Number(array[i]);
        else
            array[i] = array[i];
    }
    reverseArrayMethodOne(array);
    console.log(array);
    reverseArrayMethodTwo(array);
    console.log(array);
    try {
        add(...array);
    } catch (error) {
        document.getElementById('addingNumbersPlaceholder').innerHTML = error.message;
    }
    outPutDiv.style.display = "block";
}

// Reverse Array functions

// Reverse Array first method.
function reverseArrayMethodOne(array) {
    var reversedArray = [];
    var outPut = document.getElementById('reverseMethodOnePlaceholder');
    for (var i = array.length - 1; i >= 0; i--) {
        reversedArray.push(array[i]);
    }
    outPut.innerHTML = JSON.stringify(reversedArray);
}

// Reverse Array second method.
function reverseArrayMethodTwo(array) {
    var rightHand = 0, leftHand = array.length - 1, tmp;
    var outPut = document.getElementById('reverseMethodTwoPlaceholder');
    while (rightHand < leftHand) {
        tmp = array[rightHand];
        array[rightHand] = array[leftHand];
        array[leftHand] = tmp;
        rightHand++;
        leftHand--;
    }
    outPut.innerHTML = JSON.stringify(array);
}


// Adding Numbers function
function add() {
    console.log(arguments, "arguments");
    if (!arguments[0]) {
        throw new Error("No Arguments Provided");
    }
    var sum = 0;
    for (var i = 0; i < arguments.length; i++) {
        if (typeof arguments[i] != "number") {
            throw new Error("Argument is not a number");
        }
        sum += arguments[i];
    }
    var outPut = document.getElementById('addingNumbersPlaceholder');
    outPut.innerHTML = sum;
}

// Users Form functions
var Users = []; // Array to store the users.

// Entry point to add my event listener to the form submission event.
function handleUsersForm() {
    var form = document.getElementById('newUser');
    console.log(form);
    form.addEventListener("submit", processUsersForm);
}

// Process the form data on submit.
function processUsersForm(e) {
    e.preventDefault();
    getUsers();
    notificationPlaceHolderHandler("Users Generated Successfully", "success");
    console.log(Users);
}

// Get Users from the API
function getUsers() {
    var request = new XMLHttpRequest();

    request.open('GET', 'https://jsonplaceholder.typicode.com/users');
    request.send();
    request.onreadystatechange = function() {
        if (request.readyState == 4 && request.status == 200) {
            Users = JSON.parse(request.responseText);
            console.log(Users);
            processTable();
        }
    }
}

// Process the table
function processTable() {
    var table = document.getElementsByClassName('usersTable')[0];
    if (table) {
        table.remove();
    }
    if (Users.length == 0) {
        return;
    }
    table = createTable();
    document.getElementsByClassName('outPutDiv')[0].insertAdjacentElement('beforebegin', table);
}

// Create the table
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
    th3.innerHTML = "Email";
    th4.innerHTML = "Action";
    tr.appendChild(th1);
    tr.appendChild(th2);
    tr.appendChild(th3);
    tr.appendChild(th4);
    thead.appendChild(tr);
    table.appendChild(thead);
    table.appendChild(tbody);
    table.className = "usersTable";
    for (var i = 0; i < Users.length; i++) {
        var tr = document.createElement('tr');
        var td1 = document.createElement('td');
        var td2 = document.createElement('td');
        var td3 = document.createElement('td');
        var td4 = document.createElement('td');
        var deleteButton = document.createElement('button');
        var viewButton = document.createElement('button');
        deleteButton.appendChild(addRemoveImg());
        deleteButton.className = "deleteButton";
        deleteButton.setAttribute("onclick", `deleteUser(${i})`);
        viewButton.appendChild(addViewImg());
        viewButton.className = "viewButton";
        viewButton.setAttribute("onclick", `viewUser(${i})`);
        td1.innerHTML = Users[i].id;
        td2.innerHTML = Users[i].name;
        td3.innerHTML = Users[i].email;
        td4.appendChild(deleteButton);
        td4.appendChild(viewButton);
        console.log(td4);
        tr.appendChild(td1);
        tr.appendChild(td2);
        tr.appendChild(td3);
        tr.appendChild(td4);
        tbody.appendChild(tr);
    }
    return table;
}

// Delete User from the table and users list.
function deleteUser(idx) {
    Users.splice(idx, 1);
    processTable();
    notificationPlaceHolderHandler("User Deleted Successfully", "success");
}

// View User from the users list.
function viewUser(idx) {
    var user = Users[idx];
    var outPutDiv = document.getElementsByClassName('outPutDiv')[0];
    var userData = document.createElement('div');
    for (var key in user) {
        var p = document.createElement('p');
        var span = document.createElement('span');
        p.className = "userData";
        span.className = "userProperty";
        span.innerHTML = key + ": ";
        p.appendChild(span);
        p.innerHTML += JSON.stringify(user[key]); // JSON.stringify to display the object as a string.
        userData.appendChild(p);
    }
    outPutDiv.replaceChild(userData, outPutDiv.childNodes[0]); // Replace the previous user data with the requested one.
    outPutDiv.style.display = "block";
    notificationPlaceHolderHandler("User Data Displayed Successfully", "success");
}

// Add the remove icon to delete button
function addRemoveImg() {
    var imgElement = document.createElement('img');
    imgElement.src = "./assets/form/delete.png";
    return imgElement;
}

// Add the view icon to view button
function addViewImg() {
    var imgElement = document.createElement('img');
    imgElement.src = "./assets/form/view.png";
    return imgElement;
}

// Notification Place Holder Handler
function notificationPlaceHolderHandler(message, className) {
    var text = document.getElementById('notificationPlaceholder');
    text.innerHTML = message;
    text.className = className;
    notificationsTimeOut(text);
}

// Notification Time Out Handler
function notificationsTimeOut(element) {
    setTimeout(function() {
        element.innerHTML = "";
    }, 3000);
}


// Cookies Handler functions

// Cookies Section Display Handler.
function cookiesDisplay(isUserLoggedIn) {
    var loginDiv = document.getElementsByClassName('userLoginInputsDiv')[0];
    var userDiv = document.getElementsByClassName('userLoggedInDiv')[0];
    if (isUserLoggedIn) {
        processLogin();
        loginDiv.style.display = "none";
        userDiv.style.display = "block";
    } else {
        userDiv.style.display = "none";
        loginDiv.style.display = "block";
        console.log(isUserLoggedIn, "Not logged in");
    }
}

// Section Entry Point.
function checkLogin() {
    cookiesDisplay(getCookie('loggedInUser'));
}

// Login entry point.
function login() {
    var user = {};
    var genders = document.getElementsByName('gender');
    for (var i = 0; i < genders.length; i++) {
        if (genders[i].checked) {
            user['gender'] = genders[i].value;
        }
    }
    user['name'] = document.getElementById('namePick').value;
    user['age'] = document.getElementById('agePick').value;
    user['favcolor'] = document.getElementById('colorPick').value;
    user['loggedInTimes'] = 0;
    setCookie('loggedInUser', JSON.stringify(user), 3);
    processLogin();
    console.log(user);
    cookiesDisplay(getCookie('loggedInUser'));
}

// Render the logged in div
function processLogin() {
    var user = JSON.parse(getCookie('loggedInUser'));
    var userNameSpan = document.getElementById('userName');
    var loggedInTimesSpan = document.getElementById('userLoggedInTimes');
    var userGenderImg = document.getElementById('userGenderImg');
    userNameSpan.innerHTML = user.name;
    userNameSpan.style.color = user.favcolor;
    loggedInTimesSpan.innerHTML = user.loggedInTimes;
    loggedInTimesSpan.style.color = user.favcolor;
    if (user.gender == "male") {
        userGenderImg.src = "./assets/cookies/male.jpg";
    } else {
        userGenderImg.src = "./assets/cookies/female.jpg";
    }
    user.loggedInTimes++;
    setCookie('loggedInUser', JSON.stringify(user), 3);
}

// Get cookie function
function getCookie(key) {
    var cookies = document.cookie.split(";");
    for (var i = 0; i < cookies.length; i++) {
        var cookie = cookies[i].split("=");
        if (cookie[0] == key) {
            return cookie[1];
        }
    }
}

// Logout function
function logout() {
    setCookie('loggedInUser', "", -1);
    cookiesDisplay(getCookie('loggedInUser'));
}

// Set cookie function
function setCookie(key, value, expireDays) {
    var expireDate = new Date();
    expireDate.setDate(expireDate.getDate() + expireDays);
    document.cookie = `${key}=${value}; expires=${expireDate}; path=/;`;
}
