JAVASCRIPT OBJECTS NOTES:
============================================================================================

--> objects are used to store keyed collections of various data and more complex entities
    - penetrate almost every aspect of the language
    - can be created using figure brackets {...} with an optional list of properties
        - properties of form "key: value" where key is a string and value can be anything

--> an empty object can be created using either syntax:
    - let user = new Object();
    - let user = {};
    - we can immediately put properties in as well:
    - let user = { name: "John", age: 30 };
        - we can add values of any type like:
            user.isAdmin = true;
        - we can remove properties
            delete user.age;
    
--> square brackets can be used (useful when multiword) 
    - user["likes birds"] = true;
    - delete user["likes birds"];

--> object references and copying:
    - objects are stored and copied by reference
    - primitive values are always copied as a whole value/themselves
    - when an object variable is copied, the reference is copied, but the object itself is not duplicated
        - in such a case we have two variables which store a reference to the same object, we can use either to access
        or modify its contents

--> object methods/this:
    - evaluated during runtime depending on the context

    let user = { name: "John" };
    let admin = { name: "Admin" };

    function sayHi() {
        alert( this.name );
    }

    // use the same function in two objects
    user.f = sayHi;
    admin.f = sayHi;

    // these calls have different this
    // "this" inside the function is the object "before the dot"
    user.f(); // John  (this == user)
    admin.f(); // Admin  (this == admin)

    admin['f'](); // Admin (dot or square brackets access the method – doesn't matter)

    - arrow functions HAVE NO this

--> optional chaining using ?: safe way to access nested objects properties
    - in optional chaining, ?. stops the evaluation if the value before ?. is undefined or null and returns undefined
    - value?.prop:
        - works as value.prop if value exists
        - otherwise returns undefined if null/undefined
        - example: alert(user?.address?.street);