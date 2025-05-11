JAVASCRIPT PROMISE CHAINING
============================================================================================

--> we have a sequence of asynchronous tasks to be performed one after another -- how can we code it well?
    - promise chain example syntax:
    new Promise(function(resolve, reject) {
        setTimeout(() => resolve(1), 1000);
    }).then(function(result) {
        alert(result);  // 1
        return result * 2;
    }).then(function(result) {
        alert(result);  // 2
        return result * 2;
    }).then(function(result) {
        alert(result);  // 4
        return result * 2;
    })

    explanation of flow:
        - initial promise resolves in 1 second
        - the first .then handler is called which in turn creates a new promise (resolved with 2)
        - the next .then handler gets result of previous one, doubles it and passes to next handler
        - and so on

--> returning promises
    - a handler, used in .then(handler) may create and return a promise. in that case further handlers wait until it settles then get its result
    new Promise(function(resolve, reject) {
        setTimeout(() => resolve(1), 1000);
    }).then(function(result) {
        alert(result);  // 1
        return new Promise((resolve, reject) => {
            setTimeout(() => resolve(result*2), 1000);
        });
    }).then(function(result) {
        alert(result);  // 2
        return new Promise((resolve, reject) => {
            setTimeout(() => resolve(result*2), 1000);
        });
    }).then(function(result) {
        alert(result);  // 4
    });


--> bigger example: fetch
    - in frontend programming, we often use promises for network requests
    - example: using fetch to load information about user from remote server

    let promise = fetch(url)
    - this makes a network request to the url and returns a promise. it resolves with a response object when the remote server 
    responds with headers before the full response is downloaded
    
    example:
    fetch('/article/promise-chaining/user.json')
        // load it as json
        .then(response => response.json())
        // make request to github
        .then(user => fetch(`https://api.github.com/users/${user.name}`))
        // load response as json
        .then(response => response.json())
        // show avatar img for 3 seconds
        .then(githubUser => {
            let img = document.createElement('img');
            img.src = githubUser.avatar_url;
            img.className = 'promise-avatar-example';
            document.body.append(img);

            setTimeout(() => img.remove(), 3000);
        })

