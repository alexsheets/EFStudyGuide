/*
Examples of the most common design patterns in .NET
*/

// =========================================================================================

// singleton pattern: ensure a class only has one instance/provides global point of access
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

