Reviewing .NET, C#, OOP, and all related concepts
========================================================================

--> unit/integration testing:



--> SOLID principles:
    - single responsibility principle: each class should be responsible for one part/functionality of the system

    - open closed principle: a class should be open for extension but closed for modification; good for adding new features without altering existing code

    - liskov substitution principle: objects of a superclass should be replaceable with objects of a subclass without affecting the correctness of the program; in other words, you should be able to use any subclass where you use its parent class
        - a derived class should not break base class type definition and behavior, which means objects of base class shall be replaceable with objects of its derived classes without breaking application

    - interface segregation principle: a class should not be forced to implement interface it doesn't use; principle encourages creation of small, client-specific interfaces

    - dependency inversion principle: suggests high-level modules should not depend on low-level modules, but both should depend on abstractions. abstractions should not depend on details, only details should depend on abstractions


--> patterns often implemented:
    == Creational Design Patterns
    - singleton pattern:
        - used to ensure a class only has one instance
        - provides global point of access to that instance
        - implemented using a private constructor and static field that holds single instance of class
    - factory pattern:
        - used to create objects without exposing creation logic to client
        - implemented using a class or method that creates objects based on set of params
        - defines an interface for creating an object, lets subclass decide which class to instantiate
    - builder pattern:
        - separates construction of complex objects from its representation
        - builder pattern is implemented using a separate class or method that constructs the
        object step by step
        - useful to create complex objects with many components and want to separate construction logic from representation
    - dependency injection: IMPORTANT
        - creational pattern which provides a way to create objects without having to know the details of how they were constructed
        - useful to creat objects with complex dependencies or difficult to instantiate
        - statically declare a class's required dependencies by defining them in constructor

    == Structural Design Patterns
    - adapter pattern:
        - used to convert interface of class into another interface that clients expect
        - implemented using a separate class which acts like a bridge btwn two incompatible interfaces
        - pattern is useful when you want to use a class which is not compatible with existing codebase, and you want to convert interface to make it compatible
    - decorator pattern:
        - used to add functionality to an object dynamically
        - implemented using a separate class which wraps the original object and provides additional functionality
        - useful when you want to add functionality to an obj w/o changing interface
    - bridge pattern: 
        - used to decouple an abstraction from its implementation, allowing them to vary independently
        - provides a way to create a family of related classes w/ different implementations
        - useful when we have multiple variations of a class we want to use interchangeably

    == Other patterns
        - observer pattern:
            - allows an object (subject) to notify a list of observers when state changes
            - the observers are automatically noified and updated

    - mediator pattern/CQRS: 
        - cqrs: command and query responsibility segregation. used to separate operations that read data from operations that write/update data
        - pattern aims to reduce dependencies between objects by restricting direct communication and instead creating a way to collaborate only through the mediator object
            - there is an object that encapsulates and manages how objects interact 

    - scoped pattern:
        - new instance of service is created per HTTP request
        - each request gets its own service instance, but same instance is used throughout life of that request
        - used to maintain some form of state across single request but need isolation btwn requests

    - transient pattern:
        - new instance of service is created every time its requested from container
        - use when service is stateless and you want new instance every time to ensure no residual state is carried over between uses

    - Inversion of Control: broader principal behind DI
        - instead of an object controlling its own dependencies, a central container or factory does it
        - concept of letting a framework call back into user code

--> SDLC:


--> SPA: