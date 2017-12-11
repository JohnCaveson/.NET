var Person = function (height, weight, age) {
    // These are the private attributes of Person
    var _height = height;
    var _weight = weight;
    var _age = age;

    // These are the getters for the private attributes.
    // They are functions defined in the Person constructor function. They
    // 'close' over the private attributes, so are called closures

    this.getHeight = function () {
        return _height;
    };

    this.getWeight = function () {
        return _weight;
    };

    this.getAge = function () {
        return _age;
    }

    // These are the methods of Person.

    this.getHatSize = function () {
        return _weight / _height * 2.9;
    };

    this.getJacketSize = function () {
        let size = 0;
        if (_age > 30){
            let age = (_age - 30) / 10;
            size = Math.floor(age) * 0.125;
        }

        return _height * _weight / 288 + size
    }

    this.getWaistSize = function () {
        let size = 0
        if (_age > 28){
            let age = (_age - 28) / 2;
            size = Math.floor(age) * 0.1;
        }
        return _weight / 5.7 + size;
    }
};
