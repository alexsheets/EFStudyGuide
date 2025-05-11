JAVASCRIPT FUNCTIONS NOTES:
============================================================================================

--> recursion and stack:
    - recursion is useful when a task can be naturally split into several tasks of same kind, but simpler; or, when tasks can be simplified
    into an easy action plus a simpler variant of the same task
    - when a function solves a task, in the process it can call many other funcs; a partial case of this is when a function calls itself (recursion)
    function pow(x, n) {
        if (n==1) { return x; } 
        else {
            return x * pow(x, n-1);
        }
    }

--> rest parameters and spread syntax: many JS built-in functions support arbitrary number of arguments
    - extra parameters can be included in the function definition by using three dots followed by name of array which will contain them
    - if using this, it must always be the last parameter 
    function sumAll(...args) {
        let sum = 0;
        for (let arg of args) sum += arg;
        return sum;
    }

--> setTimeout and setInterval
    - setTimeout: allows us to run a function once after the interval of time
    - setInterval: allows us to run a function repeatedly, starting after the interval of time, then repeating continuously at that interval


--> decorators and forwarding, call/apply:
    