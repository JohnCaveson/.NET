var c = document.getElementById("drawingArea");
var ctx = c.getContext("2d");
var startingX = 320, endingX = 320, startingY = 100, endingY = 610;

// Draw a filled, red rectangle
ctx.fillStyle = "#FF0000";
// x, y, width, height
ctx.fillRect(0, 0, 150, 75);

// Draw a line
ctx.moveTo(0, 0); // x, y
ctx.lineTo(200, 100); // x, y
ctx.stroke();

// Draw a circle
ctx.beginPath();
// arc(x, y, radius, start angle, end angle)
// angles are expressed in radians and 2 * PI radians = 360 degrees
ctx.arc(95, 50, 40, 0, 2 * Math.PI);
ctx.stroke();

for (i = 0; i < 100; i++){
    ctx.moveTo(i*3, 100);
    ctx.lineTo(i*3, 200);
    ctx.stroke();
}

for (var i = 0; i < 52; i++) {
    ctx.moveTo(startingX, startingY);
    ctx.lineTo(endingX, endingY);
    ctx.stroke();
    startingY += 10;
    endingX += 10;
}