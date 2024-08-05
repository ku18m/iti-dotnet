const numInp = document.getElementById("numInp");

function increase(){
    numInp.stepUp(2)
    // console.log(numInp.value);
    
    // console.log(numInp.valueAsNumber);

}

function descrease(){
    numInp.stepDown(10)
}

// ------------------------

const rangeInp = document.getElementById("rangeInp");
const span = document.getElementById("rangeVal");

function printVal(){
    
    span.innerHTML  = rangeInp.value
}

// ----------------------------------


const audio = document.querySelector("audio");
const volumeInp = document.getElementById("rangeVolume")
const timeInp = document.getElementById("rangeTime")

function playAud(){

    audio.play()
}

function pauseAud(){
    audio.pause();
}


function stopAud(){
    audio.load();
    audio.pause();
}

function muteAud(){
    audio.muted = !audio.muted;
}


function changeVolume(){
     audio.volume = volumeInp.value
}

function changeTime (){

    audio.currentTime = timeInp.value;

}

audio.addEventListener("timeupdate",function(){
    timeInp.value = audio.currentTime
})

window.addEventListener("load",function(){
  
    timeInp.max = audio.duration
})

function test(){
    console.log(audio.volume);
    
}

// --------------------------------------

// Local storge 


// function saveData(){
//     // dot notation

//     localStorage.username = "mona";
//     localStorage["age"] = 23;
    
//     localStorage.setItem("grades",[100,60,70,50])


//     // brackets notion
// }

// function getData(){

//     console.log(localStorage.age);
//     console.log(localStorage["username"]);

//      var gradesAsString = localStorage.getItem("grades");

//      console.log(gradesAsString.split(",").map(Number));
//      console.log(localStorage.favColor);
//      console.log(localStorage.getItem("favColor"));
    
// }

// function removeData(){

//     localStorage.removeItem("username")
    
// }


// function removeAll(){
//     localStorage.clear();
// }


// --------------- Session storage --------------------


function saveData(){
    // dot notation

    sessionStorage.username = "mona";
    sessionStorage["age"] = 23;
    
    sessionStorage.setItem("grades",[100,60,70,50])


    // brackets notion
}

function getData(){

    console.log(sessionStorage.age);
    console.log(sessionStorage["username"]);

     var gradesAsString = sessionStorage.getItem("grades");

     console.log(gradesAsString.split(",").map(Number));
     console.log(sessionStorage.favColor);
     console.log(sessionStorage.getItem("favColor"));
    
}

function removeData(){

    sessionStorage.removeItem("username")
    
}


function removeAll(){
    sessionStorage.clear();
}


// ---------------  Geolocation   --------------------


// navigator.geolocation.getCurrentPosition(sucess,error)


// function sucess(pos){
//     console.log(pos.coords.longitude);
//     console.log(pos.coords.latitude); 
// }
// function error(e){
//     alert(e.message);
// }



// // Create request

// const request = new XMLHttpRequest();

// // define request 

// request.open("GET","https://nominatim.openstreetmap.org/search?format=json&q=Egypt");

// request.send();

// request.addEventListener("load",function (){
//     var data = JSON.parse(request.responseText);

//     console.log(data[0].lat);
    
// })

// ====================================


// Reverse geocoding api
navigator.geolocation.getCurrentPosition(success, error)

var lat;
var lng;
function success (pos){
        lat = pos.coords.latitude;
        lng = pos.coords.longitude;

}

function error(e){

}

// Create request

const request = new XMLHttpRequest();

// define request 

request.open("GET",`https://api.bigdatacloud.net/data/reverse-geocode-client?latitude=${lat}&longitude=${lng}&localityLanguage=en`);

request.send();

request.addEventListener("load",function (){
    var data = JSON.parse(request.responseText);

    console.log(data);
    
})











