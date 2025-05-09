// model definition; includes getter and setter for each property.
// property is like a combination of variable and a method; it has get and set method
// get returns value and set assigns a value
public class Customer {
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Order> Orders { get; } = new List<Order>();
}

public class Order {
    public int Id { get; set; }
    public decimal Amount { get; set; }
}

// defining a DbContext
public class StoreDbContext : DbContext {
    // implement usage of conn string to connect to db

    // define DbSets here
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
}

// instantiate and use DbContext
using (var context = new MyDbContext()) {
    // Insert
    var customer = new Customer { Name = "John Doe" };
    context.Customers.Add(customer);

    // Query
    var customersWithOrders = context.Customers.Include(c => c.Orders).ToList();

    // Update
    customer.Name = "Jane Doe";

    // Remove
    context.Customers.Remove(customer);

    // Save changes
    context.SaveChanges();
}