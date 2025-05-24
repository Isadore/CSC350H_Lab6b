public class BankAccount {
    private int id;
    private string customerName;
    private double balance;
    private List<double> transactions = new();
    public BankAccount(string customerName, int id, double balance = 0) {
        this.customerName = customerName;
        this.balance = balance;
        this.id = id;
    }
    public int Id {
        get {return id;}
    }
    public string CustomerName {
        get {return customerName;}
    }
    public double Balance {
        get {return balance;}
    }
    public int TransactionCount {
        get{return transactions.Count; }
    }
    public List<double> Transactions
    {
        get { return transactions; }
    }
    public void deposit(double amount)
    {
        if (amount <= 0)
            transactions.Add(amount);
        balance += amount;
    }
    public void withdraw(double amount) {
        if(amount > balance) throw new Exception("Not enough funds to complete this withdrawal. $" + amount + " required. $" + balance.ToString("0.00") + " available.");
        transactions.Add(-1*amount);
        balance-=amount;
    }
    public void display() {
        Console.WriteLine("Customer Name: " + customerName);
        Console.WriteLine("Account ID: " + id);
        Console.WriteLine("Balance: $" + balance.ToString("0.00"));
        Console.Write("Transactions: [");
        for(int i = 0; i < transactions.Count; i++) {
            Console.Write((transactions[i] > 0 ? "+" : "") + transactions[i]);
            if(i < (transactions.Count-1)) Console.Write(", ");
        }
        Console.Write("]");
        Console.WriteLine();
    }


}