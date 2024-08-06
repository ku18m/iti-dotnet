var currentColor = 'blue';
const CANVAS = document.getElementById('canvas');
const CONTEXT = CANVAS.getContext('2d');

window.onload = function() {
    let colorPicker = document.getElementById('color-picker');
    let generateBtn = document.getElementById('generate-btn');

    colorPicker.addEventListener('input', () => {
        if (colorPicker.value !== currentColor) {
            clearCanvas();
        }
        currentColor = colorPicker.value;
    });

    generateBtn.addEventListener('click', () => {
        generate();
    });
}


// clear the canvas
function clearCanvas() {
    CONTEXT.clearRect(0, 0, CANVAS.width, CANVAS.height);
}


// generate the pattern
function generate() {
    let numOfCircles = Math.random() * 100;

    for (let i = 0; i < numOfCircles; i++) {
        CONTEXT.beginPath();
        let x = Math.random() * CANVAS.width;
        let y = Math.random() * CANVAS.height;

        CONTEXT.arc(x, y, 10, 0, 2 * Math.PI);
        CONTEXT.fillStyle = currentColor;
        CONTEXT.fill();
    }
}
