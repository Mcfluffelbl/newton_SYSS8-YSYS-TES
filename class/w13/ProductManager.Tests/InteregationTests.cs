using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
namespace ProductManager.Tests;

[TestClass]
public class IntegrationTests
{
    private readonly string conn =
        "Host=localhost;Port=5500;Username=postgres;Password=mysecretpassword;Database=productsdb";

    [TestMethod]
    [TestCategory("Integration")]
    public void GetProductsByCategory()
    {
        var inventory = new ProductInventory(conn);

        var result = inventory.GetProductsByCategory("Tech");

        Assert.IsTrue(result.Count > 0);
        Assert.IsTrue(result.All(p => p.Category == "Tech"));
    }
}
