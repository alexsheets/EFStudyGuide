JAVASCRIPT PROPERTY NOTES:
============================================================================================

--> property flags:
    - object properties, besides a value, have three special attributes/flags:
        - writable: if true, value can be changed. otherwise, read only
        - enumerable: if true, then listed in loops. otherwise not listed
        - configurable: if true, property can be deleted and these attributes can be modified
    
    - can set these flags to individual variables
    Object.defineProperty(user, "name", {
        writable: false
    });

--> property getters and setters:
    - two kinds of object properties:   
        - data properties
        - accessor property: functions that execture on getting and setting a value, but look like regular properties to external code
    
    - accessor properties are represented by getter and setter methods:
    let obj = {
        get propName() {
            // getter, the code executed on getting obj.propName
        },

        set propName(value) {
            // setter, the code executed on setting obj.propName = value
        }
    };