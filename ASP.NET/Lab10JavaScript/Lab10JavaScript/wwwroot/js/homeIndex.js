// This is a self-invoking function that creates a very localized scope.
(function () {
    // Stuff goes here
    console.log("Just testing");
})();

(function () {
    let person = new Person(68, 156, 0);
    console.log(person.getHatSize());
})();


(function () {
    let person = new Person(68, 156, 20);
    console.log("Expected Jacket Size: " + person.getJacketSize());
    console.log(person.getAge());
})();

(function () {
    let person = new Person(68, 156, 35);
    console.log("Expected Jacket Size: " + person.getJacketSize());
    console.log(person.getAge());
})();

(function () {
    let person = new Person(68, 156, 75);
    console.log("Expected Jacket Size: " + person.getJacketSize());
    console.log(person.getAge());
})();


(function () {
    let person = new Person(0,156,20);
    console.log("Expected Waist Size: " + person.getWaistSize());
    console.log(person.getAge());
})();

(function () {
    let person = new Person(0, 156, 29);
    console.log("Expected Waist Size: " + person.getWaistSize());
    console.log(person.getAge());
})();

(function () {
    let person = new Person(0, 156, 41);
    console.log("Expected Waist Size: " + person.getWaistSize());
    console.log(person.getAge());
})();


(function () {
    let ageInput = document.getElementById("age");
    let ageDisplay = document.getElementById("ageDisplay");

    // Update the ageDisplay
    ageDisplay.innerHTML = ageInput.value;
    ageInput.oninput = function () {
        ageDisplay.innerHTML = this.value;
    };

    var calculateButton = document.getElementById("calculate");
    calculateButton.onclick = function () {
        // Get the input elements
        let heightInput = document.getElementById("height");
        let weightInput = document.getElementById("weight");
        let ageInput = document.getElementById("age");
        let hatSizeInput = document.getElementById("hatSize");
        let jacketSizeInput = document.getElementById("jacketSize");
        let waistInput = document.getElementById("waistInInches");

        // Read the user inputs from the input elements
        let height = heightInput.value;
        let weight = weightInput.value;
        let age = ageInput.value;

        // Instantiate the person object
        let person = new Person(height, weight, age);

        // Output the results in the appropriate GUI elements
        hatSizeInput.value = person.getHatSize();
        jacketSizeInput.value = person.getJacketSize();
        waistInput.value = person.getWaistSize();

        return false; // Prevents the form from posting
    };
})();

