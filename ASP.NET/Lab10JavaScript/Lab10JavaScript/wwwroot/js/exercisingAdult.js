var ExercisingPerson = function (weightInPound, minutesExercising, intensity) {
    var _weightInPound = weightInPound;
    var _minutesExercising = minutesExercising;
    var _intensity = intensity;


    this.getWeightInPounds = function () {
        return _weightInPound;
    }

    this.getMinutesExercising = function () {
        return _minutesExercising;
    }

    this.getIntensity = function () {
        return _intensity;
    }

    this.calcBasal = function () {
        return 70 * Math.pow((_weightInPound / 2.2), 0.756);
    }

    this.calcPhys = function () {
        return 0.0385 * _intensity * _weightInPound * _minutesExercising;
    }

    this.calcDigestion = function (caloriesInServing) {
        let exercise = (this.calcBasal() + this.calcPhys()) / caloriesInServing;
        let digestion = (caloriesInServing * 0.1 * exercise) / caloriesInServing;
        return exercise + digestion;
            
    }
}