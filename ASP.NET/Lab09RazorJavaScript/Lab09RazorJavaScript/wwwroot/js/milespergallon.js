var litersToGallons = function (liters) {
    return liters * 0.264179;
};

var getMilesPerGallon = function (litersUsed, milesTraveled) {
    var gallonsUsed = litersToGallons(litersUsed);
    return milesTraveled / gallonsUsed;
};

var calculateButton = document.getElementById("calculate");
calculateButton.onclick = function () {
    var litersUsed = document.getElementById("litersUsed").value;
    var milesTraveled = document.getElementById("milesTraveled").value;
    var milesPerGallon = getMilesPerGallon(litersUsed, milesTraveled);
    document.getElementById("milesPerGallon").value = milesPerGallon;
};
