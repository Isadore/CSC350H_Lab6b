class Test {
    public static void Main(string[] args) {
        BankAccount customer = new("Isadore", 5, 39.50);
        customer.display();
        customer.deposit(100);
        customer.deposit(123.89);
        customer.display();
        customer.withdraw(49.99);
        try {
            customer.withdraw(500);
        } catch(Exception ex) {
            Console.WriteLine(ex.Message);
        }
        customer.display();
        customer.deposit(1000);
        customer.display();
    }
}