namespace BankAccountTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestInitialization()
    {
        //Test default balance, name and id
        BankAccount account = new BankAccount("Test", 3, 0);
        Assert.AreEqual(0, account.Balance);
        Assert.AreEqual(0, account.TransactionCount);
        Assert.AreEqual("Test", account.CustomerName);
        Assert.AreEqual(3, account.Id);
        //Check a second time with a decimal balance and different name and id
        var account2 = new BankAccount("Test1", 4, 123.40);
        Assert.AreEqual(123.40, account2.Balance);
        Assert.AreEqual(4, account2.Id);
    }

    [TestMethod]
    public void TestWithdrawal()
    {
        BankAccount account = new BankAccount("Test", 3, 50);
        //Test withdrawals
        account.withdraw(23.50);
        account.withdraw(.50);
        Assert.AreEqual(26, account.Balance);
        //Test withdrawal of more money than is in account
        Assert.ThrowsException<Exception>(() => account.withdraw(27));
        //Ensure withdrawal amount is non negative
        Assert.ThrowsException<Exception>(() => account.withdraw(0));
        Assert.ThrowsException<Exception>(() => account.withdraw(-12));
    }

    [TestMethod]
    public void TestDeposit()
    {
        BankAccount account = new BankAccount("Test", 5, 75);
        Assert.AreEqual(75, account.Balance);
        account.withdraw(23.50);
        Assert.AreEqual(51.50, account.Balance);
        //Ensure deposit is greater than 0
        Assert.ThrowsException<Exception>(() => account.deposit(0));
        Assert.ThrowsException<Exception>(() => account.deposit(-5));
    }

    [TestMethod]
    public void TestTransactions()
    {
        //Test default empty transactions
        BankAccount account = new BankAccount("Test", 6, 150);
        Assert.AreEqual(0, account.TransactionCount);
        //Test 1 transaction
        account.deposit(23);
        Assert.AreEqual(1, account.TransactionCount);
        Assert.AreEqual(23, account.Transactions[0]);
        //Test 2 transactions
        account.deposit(24);
        Assert.AreEqual(2, account.TransactionCount);
        Assert.AreEqual(24, account.Transactions[1]);
        //Test 3 transactions and withdrawal
        account.withdraw(30);
        Assert.AreEqual(3, account.TransactionCount);
        Assert.AreEqual(-30, account.Transactions[2]);
    }

}