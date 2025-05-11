JAVASCRIPT CLASSES
============================================================================================

--> class syntax:
    class MyClass {
        constructor() {...}
        method1() {...}
        method2() {...}
        method3() {...}
    }

    - then use new MyClass() to create object with all listed methods
    - constructor method is automatically called by new

--> just like functions, classes can be defined inside another expr, passed around, returned, assigned etc
    let User = class MyClass {
        sayHi() {
            alert(MyClass);
        }
    };
    new User().sayHi();
    
--> using getter and setter within class objects
    class User {
        constructor(name) {
            // invokes the setter
            this.name = name;
        }
        get name() {
            return this._name;
        }
        set name(value) {
            if (value.length < 4) {
            alert("Name is too short.");
            return;
            }
            this._name = value;
        }
    }
    let user = new User("John");
    alert(user.name); // John

--> class inheritance:
    - a way for one class to extend another so we can create new functionality on top of existing

    - small sample class:
    class Animal {
        constructor(name) {
            this.speed = 0;
            this.name = name;
        }
        run(speed) {
            this.speed = speed;
            alert(`${this.name} runs with speed ${this.speed}.`);
        }
        stop() {
            this.speed = 0;
            alert(`${this.name} stands still.`);
        }
    }
    let animal = new Animal("My animal");

    - we want to create another class, rabbit. all rabbits are animals, and thus should be based on animal and extend it
    class Rabbit extends Animal {
        hide() {
            alert(`{$this.name} hides`)
        }
    }
    let rabbit = new Rabbit("White Rabbit");
    rabbit.run(5);
    rabbit.hide();

--> we can override methods than we inherit
    - by default, all methods not specified in class Rabbit are taken from class Animal
    - usually we dont want to totally replace a parent method, but rather build on top of it to extend functionality 
    - classes provide 'super' keyword:
        - super.method(...) to call a parent method
        - super(...) to call a parent constructor 
        stop() {
            super.stop(); // call parent stop
            this.hide(); // and then hide
        }

--> MIXINS
    - in JS we can only inherit from a single object. there can only be one [[Prototype]] for an object, and classes may only extend one other class
    - mixin isa class containing methods that can be used by other classes without a need to inherit from it
        - in other words, provides methods that implement a certain behavior
    - simplest way to implement a mixin in JS is to make an object with useful methods so that we can easily merge them into a prototype of any class
    let sayHiMixin = {
        sayHi() {
            alert(`Hello ${this.name}`);
        },
        sayBye() {
            alert(`Bye ${this.name}`);
        }
    };
    // usage:
    class User {
        constructor(name) {
            this.name = name;
        }
    }
    // copy the methods
    Object.assign(User.prototype, sayHiMixin);
    // now User can say hi
    new User("Dude").sayHi();