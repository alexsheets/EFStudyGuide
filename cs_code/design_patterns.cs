/*
Examples of the most common design patterns in .NET
*/

// =========================================================================================

// SINGLETON PATTERN: ensure a class only has one instance/provides global point of access
// must be sealed to prevent class inheritance through external or nested classes
public sealed class Singleton {
    // constructor should be private to prevent direct construction with 'new' operator
    private Singleton() { }
    // instance stored in static field
    private static Singleton _instance;
    public static Singleton GetInstance() {
        if (_instance) {
            _instance == new Singleton();
        }
        return _instance;
    }
    // singleton should define some business logic and can be executed on its instance
    public void someBusinessLogic() { }
}
class Program {
    static void Main(string[] args)
    {
        Singleton s1 = Singleton.GetInstance();
        Singleton s2 = Singleton.GetInstance();

        // in this case, s1 == s2 is evaluated to true
        // thus meaning the singleton has worked -- both variables contain same instance
    }
}

// =========================================================================================

// FACTORY PATTERN: create objects without exposing creation logic to client
// example: doc mgmt system where users can create different documents, each should have their
// own behavior and logic. 
// factory pattern allows us to define common interface and subclasses determine type of doc
public abstract class DocumentCreator {
    // factory method
    public abstract Document CreateDocument();
    public void SomeOperation() { Document document = CreateDocument(); document.Render(); }
}
public class TextDocumentCreator : DocumentCreator {
    public override Document CreateDocument() => new TextDocument();
}
public class SpreadsheetDocumentCreator : DocumentCreator
{
    public override Document CreateDocument() => new SpreadsheetDocument();
}
public abstract class Document
{
    public abstract void Render();
}
public class TextDocument : Document
{
    public override void Render()
    {
        Console.WriteLine("Rendering Text Document");
    }
}
public class SpreadsheetDocument : Document
{
    public override void Render()
    {
        Console.WriteLine("Rendering Spreadsheet Document");
    }
}

// =========================================================================================

// DEPENDENCY INJECTION PATTERN: creational pattern which provides a way to create objects
// without having to know the details of how they are constructed
public interface IDataAccessLayer { void SaveData(string data); }
public class SqlDataAccessLayer : IDataAccessLayer {
    public void SaveData(string data) { /* implementation of saving data to server */ }
}
public class BusinessLogicLayer {
    private readonly IDataAccessLayer _dataAccessLayer;
    // statically declare class' required dependencies by defining them in constructor
    public BusinessLogicLayer(IDataAccessLayer dataAccessLayer) {
        _dataAccessLayer = dataAccessLayer;
    }
    public void SaveData(string data) { _dataAccessLayer.SaveData(data); }
}

// =========================================================================================

// ADAPTER PATTERN: converts interface of a class into another interface which clientexpect
// useful to use a class that is not compatible with existing codebase
public interface ITarget { void Request(); }
public class Adaptee {
    public void SpecificRequest() { Console.WriteLine("specific request"); }
}
public class Adapter : ITarget {
    private readonly Adaptee _adaptee;
    public Adapter(Adaptee adaptee) { _adaptee = adaptee; }
    public void Request() { _adaptee.SpecificRequest() }
}

// =========================================================================================

// DECORATOR PATTERN: used to add functionality to an object dynamically. 
// useful to add functionality without changing an interface
public interface ICoffee {
    string GetDescription();
    double GetCost();
}
public class SimpleCoffee : ICoffee {
    public string GetDescription() { return "Simple coffee"; }
    public double GetCost() { return 1.0; }
}
public class CoffeeWithMilk : ICoffee {
    private readonly ICoffee _coffee;
    public CoffeeWithMilk(ICoffee coffee) { _coffee = coffee; }
    public string GetDescription() { return _coffee.GetDescription() + ", with milk"; }
    public double GetCost() { return _coffee.GetCost() + 0.5; }
}