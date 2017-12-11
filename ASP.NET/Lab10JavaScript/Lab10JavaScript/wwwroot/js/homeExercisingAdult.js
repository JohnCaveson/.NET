(function () {
    let minuteInput = document.getElementById("minutes");
    let minuteDisplay = document.getElementById("minutesDisplay");

    // Update the minutesDisplay
    minuteDisplay.innerHTML = minuteInput.value;
    minuteInput.oninput = function () {
        minuteDisplay.innerHTML = this.value;
    };

    let intensityInput = document.getElementById("intensity");
    let intensityDisplay = document.getElementById("intensityDisplay");

    // Update the intensityDisplay
    intensityDisplay.innerHTML = intensityInput.value;
    intensityInput.oninput = function () {
        intensityDisplay.innerHTML = this.value;
    };

    var calculateButton = document.getElementById("calculate");
    calculateButton.onclick = function () {
        // Get the input elements
        let caloriesInput = document.getElementById("calories");
        let weightInput = document.getElementById("weight");
        let minuteInput = document.getElementById("minutes");
        let intensityInput = document.getElementById("intensity");
        let basalInput = document.getElementById("basal");
        let physicalInput = document.getElementById("physical");
        let servingsInput = document.getElementById("servings");

        // Read the user inputs from the input elements
        let calories = caloriesInput.value;
        let weight = weightInput.value;
        let minutes = minuteInput.value;
        let intensity = intensityInput.value;

        // Instantiate the person object
        let exercisingAdult = new ExercisingPerson(weight, minutes, intensity);

        // Output the results in the appropriate GUI elements
        basalInput.value = exercisingAdult.calcBasal();
        physicalInput.value = exercisingAdult.calcPhys();
        servingsInput.value = exercisingAdult.calcDigestion(calories);

        return false; // Prevents the form from posting
    };
})();