JAVASCRIPT BASICS NOTES:
============================================================================================

--> let/var/const: 
    - var: function-scoped or globally-scoped if outside a function. variables declared with var can be redeclared and reassigned
    - let: block-scoped, meaning only accessible within the block it is defined. can be reassigned but not redeclared within same scope
    - const: block-scoped, must be init upon declaration and cannot be reassigned 

--> <script> </script>: javascript programs can be inserted almost anywhere into HTML docs using the script tag
    - we can reference other files like: <script src="/path/to/script.js"></script>

--> data types:
    - number: can represent integer or floats (supports *, /, +, -). also Infinity, -Infinity and NaN.
    - string: surrounded by quotes either "" or ''
        - Backticks allow us to embed variables and expressions into a string by wrapping them in ${…}
    - boolean: 'true' or 'false'
    - null: separate type of its own which is a special value which means nothing or unknown or empty
    - undefined: value not assigned (declared but not assigned)
    - object: special type; is not primitive unlike the others.
    - typeof: returns the type of operand. ie typeof 0 will be number

--> conditions:
    - if, else, else if
    - assign variable depending on condition: let result = condition ? value1 : value2;
        - if condition true, value1, otherwise, value2
        let age = prompt('age?', 18);
        let message = (age < 3) ? 'Hi, baby!' :
        (age < 18) ? 'Hello!' :
        (age < 100) ? 'Greetings!' :
        'What an unusual age!';

        - multiple ? can be used in chain to basically be used as if/else
    
--> logical operators: ||, &&, ! all used
    - ?? operator: nullish coalescing
        - the result of a ?? b is:
            - if a is defined, then a. otherwise, b

--> loops etc.:
    - for and while are same
    - for (begin; condition; step) { }
    - do { // body } while (condition);
    - can use break to force an exit, or continue to next iteration
    - switch statement (basically if statements using cases)

--> functions: 
    - function declaration  
        - function keyword goes first, then name of function, then list of parameters
        - in parameters, we can specify a value for variable to be a default
    - function expressions: used to create a new function in the middle of any expression
        let sayHi = function() {
            alert( "Hello" );
        };

--> arrow functions (the basics)
    - let func = (arg1, arg2, argN) => expression;
    - creates function that accepts arguments and evaluates the expression on the right side with their use and returns its result
    - if there are no arguments, we must still pass empty parentheses
