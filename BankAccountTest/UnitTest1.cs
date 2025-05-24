namespace BankAccountTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestInitialization()
    {
        BankAccount account = new BankAccount("Test", 3, 0);
        Assert.AreEqual(0, account.Balance);
        Assert.AreEqual(0, account.TransactionCount);
        Assert.AreEqual("Test", account.CustomerName);
        Assert.AreEqual(3, account.Id);
        var account2 = new BankAccount("Test1", 4, 123.40);
        Assert.AreEqual(123.40, account2.Balance);
        Assert.AreEqual(4, account2.Id);
    }

    [TestMethod]
    public void TestWithdrawal()
    {
        BankAccount account = new BankAccount("Test", 3, 50);
        Assert.AreEqual(50, account.Balance);
        account.withdraw(23.50);
        account.withdraw(.50);
        Assert.AreEqual(26, account.Balance);
        Assert.ThrowsException<Exception>(() => account.withdraw(27));
    }

    [TestMethod]
    public void TestDeposit()
    {
        BankAccount account = new BankAccount("Test", 5, 75);
        Assert.AreEqual(75, account.Balance);
        account.withdraw(23.50);
        Assert.AreEqual(51.50, account.Balance);
        Assert.ThrowsException<Exception>(() => account.withdraw(65));
    }

}