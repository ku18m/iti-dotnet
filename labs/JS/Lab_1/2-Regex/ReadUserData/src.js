// Declare the variables
var userName;
var userPhoneNumber;
var userMobileNumber;
var userEmail;

// Validating Name loop
var userNameRegex = /^[a-zA-Z]+$/;
do {
    userName = prompt("Enter your name: ");
    alert(userNameRegex.test(userName) ? "Valid Name" : "Invalid Name");
} while (!userNameRegex.test(userName));

// Validating Phone Number loop
var userPhoneNumberRegex = /^\d{8}$/;
do {
    userPhoneNumber = prompt("Enter your phone number: ");
    alert(userPhoneNumberRegex.test(userPhoneNumber) ? "Valid Phone Number" : "Invalid Phone Number");
} while (!userPhoneNumberRegex.test(userPhoneNumber));

// Validating Mobile Number loop
var userMobileNumberRegex = /^(010|011|012)\d{8}$/;
do {
    userMobileNumber = prompt("Enter your mobile number: ");
    alert(userMobileNumberRegex.test(userMobileNumber) ? "Valid Mobile Number" : "Invalid Mobile Number");
} while (!userMobileNumberRegex.test(userMobileNumber));

// Validating Email loop
var userEmailRegex = /^[a-z]{3}@[0-9]{3}.com$/;
do {
    userEmail = prompt("Enter your email: ");
    alert(userEmailRegex.test(userEmail) ? "Valid Email" : "Invalid Email");
} while (!userEmailRegex.test(userEmail));

// Creating data div
var allUserDataDiv = `
    <div>
        <p><span class="colored">Welcome dear guest</span> ${userName}</p>
        <p><span class="colored">your telephone number is</span> ${userPhoneNumber}</p>
        <p><span class="colored">your mobile number is</span>: ${userMobileNumber}</p>
        <p><span class="colored">your email address is</span> ${userEmail}</p>
    </div>
`;

// Getting the color from the user
var userColor = prompt("Enter your favorite color: ");
var styleSheet = document.styleSheets[0];
styleSheet.insertRule(`.colored { color: ${userColor}; }`);

// Show the data for the user
document.writeln(allUserDataDiv);
