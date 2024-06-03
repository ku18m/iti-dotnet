var userMessage = prompt("Enter your message: ", "Hello, World!");

for (var headerSize = 1; headerSize <= 6; headerSize++) {
    document.writeln("<h" + headerSize + ">" + userMessage + "</h" + headerSize + ">");
}