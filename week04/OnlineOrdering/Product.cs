using System;

class Program
{
    static void Main()
    {
        // Addresses
        Address address1 = new Address("123 Main St", "Los Angeles", "CA", "USA");
        Customer customer1 = new Customer("Alice Johnson", address1);

        Address address2 = new Address("456 High St", "Toronto", "ON", "Canada");
        Customer customer2 = new Customer("Bob Smith", address2);

        // Products
        Product product1 = new Product("Laptop", "P1001", 1200.0, 1);
        Product product2 = new Product("Mouse", "P1002", 25.0, 2);
        Product product3 = new Product("Keyboard", "P1003", 50.0, 1);

        Product product4 = new Product("Headphones", "P2001", 150.0, 1);
        Product product5 = new Product("Charger", "P2002", 20.0, 3);

        // Orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        // Display Orders
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order1.CalculateTotalPrice()}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Price: ${order2.CalculateTotalPrice()}\n");
    }
}
