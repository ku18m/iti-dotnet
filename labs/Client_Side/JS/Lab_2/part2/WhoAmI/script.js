var userIdx = 5;

function doYouFly() {
    if (confirm("Do you fly?")) {
        userIdx -= 4;
        areYouWild();
    }
    else {
        doYouLiveUnderSea();
    }
}

function doYouLiveUnderSea() {
    if (confirm("Do you live under the sea?")) {
        userIdx -= 2;
        areYouWild();
    } else {
        areYouWild();
    }
}

function areYouWild() {
    if (confirm("Are you wild?")) {
        userIdx -= 1;
    }
}

var picsArray = [
    'https://t3.ftcdn.net/jpg/01/28/53/88/360_F_128538850_sodcCJbTk4MWOfXVf0QGpnftohKSdTLM.jpg',
    'https://t3.ftcdn.net/jpg/01/41/21/58/360_F_141215896_6zZwBij2ULG0ncbtYzGoTN4rN0dVCKN8.jpg',
    'https://static.vecteezy.com/system/resources/previews/013/536/671/original/cartoon-drawing-of-a-shark-vector.jpg',
    'https://t4.ftcdn.net/jpg/01/35/78/69/360_F_135786952_GY3VLshZXFDzJuhS02T4rT8tCd98eWik.jpg',
    'https://easydrawingguides.com/wp-content/uploads/2022/03/how-to-draw-an-easy-cartoon-lion-featured-image-1200.png',
    'https://cdn.vectorstock.com/i/1000v/96/78/cute-cat-cartoon-vector-16309678.jpg'
]
doYouFly();
document.write('<img src="' + picsArray[userIdx] + '">');