JAVASCRIPT PROTOTYPES/INHERITANCE NOTES:
============================================================================================

--> exmple: we have a user object with properties and methods, and want to make admin and guest as slightly modified variants of it
    - we'd like to reuse what we have in user

--> in javascript, objects have a special hidden property [[Prototype]] that is either null or references another object
    - that object is called a prototype
    - when we read a property from object, and its missing, JS automatically takes it from prototype.

--> the [[Prototype]] property is internal and hidden, but there are ways to set it:
    - one of the ways:
    let animal = {
        eats: true
    };
    let rabbit = {
        jumps: true
    };
    rabbit.__proto__ = animal;

