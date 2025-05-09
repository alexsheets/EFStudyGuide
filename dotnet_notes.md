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

    - IOC
    - mediator pattern/CQRS: 
    - transient pattern:
    - repository pattern: 

--> SDLC:


--> SPA: