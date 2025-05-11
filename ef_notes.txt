ENTITY FRAMEWORK NOTES:
======================================================================

--> object-relational mapping which bridges a gap between object-oriented code and relational databases
--> key components: 
    - model: define data structures; conceptual model of application's domain; includes data and can include behavior
    - context: in-memory database, allows for querying database, grouping together changes, writing back to database store as a unit
    simply serves as a representation of a session with the database.
--> other core concepts: 
    - entity: object which is mapped to a table or view in the database
    - DbSet<T>: represents table in database usually; collection of entities
    - entity state: describe state of entity in context
        - added
        - modified
        - deleted
        - detached
        - unchanged
    - EF supports these model development approaches:
        - generating models from existing db (database first)
        - hand-code model to match database
        - once model is created, use migration to create DB from model
    - EF Core has built-in support for creating and managing database migrations, which allows for easy management of database changes over time.
    - supports one-to-one, one-to-many, many-to-many relationships
    - supports use of LINQ to query database
    - strong typing:
        - db schemais defined using C# classes known as entities
--> features ORMs/EF provide:
    - caching, lazy loading, connection pooling
    - provide abstract layer between application and database so that code can be insulated from changes to underlying DB schema
    - strongly-typed approaches mean that we work with properties of predefined classes that form a domain model in a OOP way
        public class Product
        {
            int ProductId { get; set; }
            string ProductName { get; set; }
        }
        int productId = myProduct.ProductId;
        string productName = myProduct.ProductName;
