JAVASCRIPT OBJECTS NOTES:
============================================================================================

--> arrays: ordered collection
    - let arr = new Array(); 
    - let arr = [];
    - can access using index: fruits[1]
    - can replace using index: fruits[2] = 'pear';
    - can add to array using index: fruits[3] = 'lemon';
    - can use at() to access elements
        - if we want to access last element
            - fruits[fruits.length - 1]
            - fruits.at(-1)

--> queue/push/pop etc:
    - pop extracts last element of arr and returns it
    - push appends element to end of array
    - shift: extracts first element and returns it
    - unshift: add element to beginning of array

--> iterating over arrays
    - for (let fruit of fruits) {
        ...
    }
    - for (let i=0; i<arr.length; i++) {
        arr[i]
    }

--> map and set
    - map: collection of keyed data items, just like an Object; Map allows keys of any type
    - methods/properties:
        - new Map(): creates map
        - map.set(key, value): stores value by key
        - map.get(key): returns value by key or undefined
        - map.has(key): returns true if key exists, false otherwise
        - map.delete(key): removes element by key
        - map.clear(): removes everything
        - map.size: returns current element count
    - iterating over map:
        - map.keys(): returns iterable for keys
        - map.values(): returns iterable for values
        - map.entries(): returns iterable for entries [k, v]
    
    - set: special type of collection; a set of values without keys where each value may occur only once
        - main methods:
            - new Set([iterable]): creates the set, and if an iterable object is provided, copies values from it into a set
            - set.add(value): adds a value, returns set itself
            - set.delete(value): removes value, returns true if value existed at moment of call, otherwise false
            - set.has(value): returns true if the value exists in that set, otherwise false
            - set.clear(): removes everything from set
            - set.size: elements count
        - same methods for iterators are also supported for sets