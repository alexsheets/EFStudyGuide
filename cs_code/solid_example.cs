/* GOAL: applying SOLID principles via C# code
S: single responsibility principle
    - every module should have only one reason to change -- every class should have
    one specified job
O: open-closed principle
L: liskov substitution principle
I: interface segregation principle
D: dependency inversion principle
*/
// ====================================================================================

// SINGLE RESPONSIBILITY PRINCIPLE
public class UserService {
    public void Register(string email, string pass) {
        if (!ValidateEmail(email)) {
            throw new ValidationException("Email is not an email");
            var user = new User(email, password);
            SendEmail(new MailMessage("mysite@nowhere.com", email) { Subject="Hello" });
        }
    }
    public virtual bool ValidateEmail(string email) { return email.Contains("@"); }
    public bool SendEmail(MailMessage msg) { _smtpClient.Send(msg); }
}

// looks good, but not following single responsibility principle, as the email methods have
// nothing to do with user service class.
// notice the separation of logic
public class UserService {
    EmailService _emailService;
    DbContext _dbContext;
    public UserService(EmailService service, DbContext context) {
        _emailService = service;
        _dbContext = context;
    }
    public void Register(string email, string pass) {
        if (!_emailService.ValidateEmail(email)) {
            throw new ValidationException("Email is not an email");
            var user = new User(email, password);
            _dbContext.Save(user);
            emailService.SendEmail(new MailMessage("myname@mydomain.com", email) {Subject="Hi. How are you!"});
        }
    }
}
public class EmailService {
    SmtpClient _smtpClient;
    public EmailService(SmtpClient client) {
        _smtpClient = client;
    }
    public virtual bool ValidateEmail(string email) { return email.Contains("@"); }
    public bool SendEmail(MailMessage msg) { _smtpClient.Send(msg); }
}

// ====================================================================================

// OPEN/CLOSED PRINCIPLE: 
// we must design our class so new functionality can be added only when reqs aregenerated
// closed for modification means we have developed a class/unit tested
public class Rectangle {
    public double Height { get; set; }
    public double Width { get; set; }
}

// we need to calculate total area of rectangles; we dont need to put the total area calculation
// code inside of rectangle. make another class for area calculation
public class AreaCalc {
    public double TotalArea(Rectangle[] rectangles) {
        double area;
        foreach(var rect in rectangles) {
            area += rect.Height * rect.Width;
        }
        return area;
    }
}

// ====================================================================================

// LISKOV SUBSTITUTION PRINCIPLE: 
// should be able to use any derived class where its base class is used
// basically an extension of the open/closed principle, and also ensure that newly
// derived classes extend base classes without changing their behaviors
public class Bird {
    public virtual void Fly() { /* implementation here */ }
    public class Penguin : Bird {
        public override void Fly()
        {
            // violates LSP by throwing exception for Fly method
            throw new NotImplementedException("Penguins can't fly!");
        }
    }
}

// we can fix this by creating an implementation specific to bird and penguins
public interface IFlyable { void Fly(); }
public class Bird : IFlyable {
    public void Fly() { /* implementation for bird */ }
}
public class Penguin : IFlyable {
    public void Fly() { throw new NotImplementedException("Penguins cannot fly"); }
}

// ====================================================================================

// INTERFACE SEGREGATION PRINCIPLE
// clients should not be forced to implement interfaces they wont use; instead of one fat
// interface, we should have many small ones. basically, the interface should be closely
// related to the code that implements it

// example: we create an interace based on TeamLead 
public interface ILead {
    void CreateSubTask();
    void AssignTask();
    void WorkOnTask();

    public class TeamLead : ILead {
        public void AssignTask() { }
        public void CreateSubTask() { }
        public void WorkOnTask() { }
    }
}

// we are now looking to add managers and programmers, we need to divide responsibility
// create interfaces for both which only implement the responsibilities/tasks they can take on
public interface IProgrammer { void WorkOnTask(); }
public interface ILead {
    void AssignTask();
    void CreateSubTask();
}

// then we can implement a teamlead class which can manage tasks or work on them
// implements only what is needed; iprogrammer and ilead interfaces
public class TeamLead : IProgrammer, ILead {
    public void AssignTask()
    {
        //Code to assign a Task
    }
    public void CreateSubTask()
    {
        //Code to create a sub task from a task.
    }
    public void WorkOnTask()
    {
        //code to implement to work on the Task.
    }
}

// ====================================================================================

// DEPENDENCY INVERSION PRINCIPLE: high-level classes should not depend on low-level classes
// both should depend on abstractions; abstractions need not rely on details

public class LightBulb {
    public void TurnOn() { /* implementation */ }
    public void TurnOff() { /* implementation */ }
}
public class Switch {
    private LightBulb bulb;
    public Switch(LightBulb bulb) {
        this.bulb = bulb;
    }
    public void Toggle() {
        if (bulb.IsOn) { bulb.TurnOff(); }
        else { bulb.TurnOn(); }
    }
}

// this is poor design, because the switch class directly depends on concrete LightBulb class
// resulting code after fixing:

public interface ISwitchable {
    void TurnOn();
    void TurnOff();
}

public class LightBulb : ISwitchable {
    // implementation
}

public class Switch {
    private ISwitchable device;
    public Switch(ISwitchable device) { this.device = device; }
    public void Toggle() {
        if (device.IsOn) { device.TurnOff(); }
        else { device.TurnOn(); }
    }
}

// introducing the ISwitchable interface means the Switch class now depends on 
// an abstraction, which adheres to dependency inversion principle