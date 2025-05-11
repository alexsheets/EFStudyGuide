JAVASCRIPT PROMISES/ASYNC/AWAIT
============================================================================================

--> callbacks
    - many function are provided by JS which allow you to schedule async actions (initiate now, finish later) such as setTimeout
    - for example, when we load an execute a given JS file using a function to load the script
        - it may be executed async, because it starts now and runs later, but if there is any code below where we call said function,
        the code below will not be waiting for the script to finish. and this script may be crucial to the functionality of the page.
    - we can add a callback function as a second argument to our function which should execute when the script loads
    function loadScript(src, callback) {
        let script = document.createElement('script');
        script.src = src;
        script.onload = () => callback(script);
        document.head.append(script);
    }

--> promise:
    - imagine you're a singer, and fans ask for upcoming song. to get relief, you promise to send it when it has been published.
        - promises also occur in javascript. it links producing and consuming code together
    - syntax:
    let promise = new Promise(function(resolve, reject) {
        // executor
    });

    - the function passed to new Promise is called the executor. when new pomise is created, the executor runs automatically.
        - it contains the producing code which should eventually produce the result; in the analogy, this is the singer
    - arguments resolve and reject are callbacks provided by JS itself. our code is only inside the executor
        - when executor obtains result, it should be one of these callbacks:
            - resolve(value): if job has finished successfully with result value
            - reject(error): if error has occurred

    - execute blocks will ignore a second resolve if more than one occurs. the first resolve is taken into account.

--> consumers: then, catch
    - a promise obect serves as a link between executor/producing code and consuming function, which receives the result or error
        - consuming functions can be subcribed to updates using the methods .then and .catch
    - most fundamental one: .then.
    - syntax:
    promise.then(
        function(result) { ..handle successful result }
        function(error) { ..handle error }
    )

    - the first argument of .then is a function which runs when promise is resolved and receives result
    - the second argument of .then is a function which runs when promise is rejected and receives error

    example:
    let promise = new Promise(function(resolve, reject) {
        setTimeout(() => resolve("done!"), 1000);
    });
    // resolve runs the first function. if the promise were reject, it would run the second
    promise.then(
        result => alert(result),
        error => alert(error)
    );

--> cleanup: finally
    - there is finally in promises similar to try catch blocks. it will always run when promise is settled whether resolve or reject
    - the idea of finally is to set up a handler for performing cleanup/finalizing after previous operations are complete
        - analogous to party finisher: irrespective of party being good or bad, there still needs to be a cleanup after

    example syntax:
    new Promise((resolve, reject) => {
        // do something which takes time and then call resolve or reject
    })
    .finally(() => stop loading indicator)
    .then(result => show result, err => show error)

    - finally handler doesn't get outcome of previous handler. this outcome is passed through instead, to next suitable handler
    - if finally handler returns something, its ignored
    - when finally throws error, execution goes to nearest error handler