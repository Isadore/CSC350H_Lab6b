namespace BankAccountTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public void TestInitialization()
    {
        var account = new BankAccount("Test", 3, 0);
        Assert.AreEqual(0, account.Balance);
        Assert.AreEqual(0, account.TransactionCount);
        Assert.AreEqual("Test", account.CustomerName);
        Assert.AreEqual(3, account.Id);
    }

    [TestMethod]
    public void TestWithdrawal() {
        var account = new BankAccount("Test", 3, 50);
        Assert.AreEqual(50, account.Balance);
        account.withdraw(23.50);
        account.withdraw(.50);
        Assert.AreEqual(26, account.Balance);
        Assert.ThrowsException<Exception>(() => account.withdraw(27));
    }


}