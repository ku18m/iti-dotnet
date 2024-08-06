// // Select canvas

// const canvas = document.querySelector("canvas");

// // define context

// const context  = canvas.getContext("2d");


// console.log(context);

// // Rectangle

// // 1- filled rectangle 


// context.fillRect(50,50,100,50);

// context.fillStyle = "blue";

// context.fillRect(150 , 150, 100, 50);

// context.fillStyle = "pink"
// context.fillRect(50, 300, 50,50);


// canvas.addEventListener("mousemove", function(e){
//     console.log(e.clientX,e.clientY);
// })


// // 2- outlined rectangle

// context.strokeStyle = "red"

// context.lineWidth  = 3
// context.strokeRect(150 , 150, 100, 50);

// context.strokeRect(500, 200 , 50,50);


// // 3- Clear rect area

// context.fillRect(350,85, 200, 90);
// context.strokeRect(400,120,50,50)
// context.clearRect(400,120,50,50);

// // line 




// context.strokeStyle = "orange";
// context.lineWidth = 2
// context.moveTo(350,170);
// context.lineTo(400, 270);
// context.stroke();


// // horizontal 

// context.moveTo(280, 200);
// context.lineTo(480,200);
// context.stroke();

// // triangle 


// context.strokeStyle = "green"

// context.beginPath();
// context.moveTo(280,300);
// context.lineTo(335, 365);
// context.lineTo(250,365);
// // context.lineTo(280,300)
// context.closePath();
// // context.fill();
// context.stroke();


// // circle 

// context.beginPath();
// context.arc(500, 350 , 30 , 0 , Math.PI , true);

// context.fill();
// // context.stroke();


// // ellipse 

// context.beginPath();
// context.ellipse(600, 300 , 30, 10 ,0, 0 , Math.PI*2 );

// // context.fill();
// context.stroke();


// // text 

// context.font = "30px Arial"
// context.fillText("Hello, Canvas" ,220, 50)

// context.font = "50px Arial"

// context.strokeText("Hello,Canvas", 50 , 250)


// -----------------------------------------------

// const canvas = document.querySelector("canvas");

// define context

// const context  = canvas.getContext("2d");


// for(var i= 0 ; i<50 ; i++){
    
//     context.beginPath();
//     var x = parseInt( Math.random() * canvas.width);
//     var y = parseInt( Math.random() * canvas.height);
//     context.arc(x, y , 30 , 0, Math.PI *2);
//     context.stroke();
// }


// setInterval(function(){
//     context.clearRect(0,0, canvas.width , canvas.height);
//     for(var i= 0 ; i<50 ; i++){
//     context.beginPath();
//         var x = parseInt( Math.random() * canvas.width);
//         var y = parseInt( Math.random() * canvas.height);
//         context.arc(x, y , 30 , 0, Math.PI *2);
//         context.stroke();
//     }
// }, 1000)


