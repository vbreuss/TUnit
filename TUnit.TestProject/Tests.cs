using TUnit.Assertions;
using TUnit.Core;
using TUnit.Core.Attributes;

namespace TUnit.TestProject;

public class Tests
{
    // [SetUp]
    // public void Setup()
    // {
    // }

    [Test]
    public void Test1()
    {
        var value = "1";
        Assert.That(value, Is.EqualTo("1"));
    }
    
    [Test]
    public void Test2()
    {
        var value = "2";
        Assert.That(value, Is.EqualTo("1"));
    }
    
    [Test]
    public async Task Test3()
    {
        await Task.Yield();
        var value = "1";
        Assert.That(value, Is.EqualTo("1"));
    }
    
    [Test]
    public async Task Test4()
    {
        await Task.Yield();
        var value = "2";
        Assert.That(value, Is.EqualTo("1"));
    }
    
    [TestWithData("1")]
    [TestWithData("2")]
    public void ParameterisedTests1(string value)
    {
        Assert.That(value, Is.EqualTo("1"));
    }
    
    [TestWithData("1")]
    [TestWithData("2")]
    public async Task ParameterisedTests2(string value)
    {
        await Task.Yield();
        Assert.That(value, Is.EqualTo("1"));
    }

    [Test, Skip("Reason1")]
    public void Skip1()
    {
        var value = "1";
        Assert.That(value, Is.EqualTo("1"));
    }
    
    [Test, Skip("Reason2")]
    public async Task Skip2()
    {
        await Task.Yield();
        var value = "1";
        Assert.That(value, Is.EqualTo("1"));
    }
    
    [TestDataSource(nameof(One))]
    public void TestDataSource1(int value)
    {
        Assert.That(value, Is.EqualTo(1));
    }
    
    [TestDataSource(nameof(One))]
    public async Task TestDataSource2(int value)
    {
        await Task.Yield();
        Assert.That(value, Is.EqualTo(1));
    }
    
    [TestDataSource(nameof(Two))]
    public void TestDataSource3(int value)
    {
        Assert.That(value, Is.EqualTo(1));
    }
    
    [TestDataSource(nameof(Two))]
    public async Task TestDataSource4(int value)
    {
        await Task.Yield();
        Assert.That(value, Is.EqualTo(1));
    }
    
    [TestDataSource(nameof(TestDataSources), nameof(One))]
    public void TestDataSource5(int value)
    {
        Assert.That(value, Is.EqualTo(1));
    }
    
    [TestDataSource(nameof(TestDataSources), nameof(One))]
    public async Task TestDataSource6(int value)
    {
        await Task.Yield();
        Assert.That(value, Is.EqualTo(1));
    }
    
    [TestDataSource(nameof(TestDataSources), nameof(Two))]
    public void TestDataSource7(int value)
    {
        Assert.That(value, Is.EqualTo(1));
    }
    
    [TestDataSource(nameof(TestDataSources), nameof(Two))]
    public async Task TestDataSource8(int value)
    {
        await Task.Yield();
        Assert.That(value, Is.EqualTo(1));
    }

    [Test]
    public void TestContext1()
    {
        Assert.That(TestContext.Current.TestName, Is.EqualTo(nameof(TestContext1)));
    }
    
    [Test]
    public void TestContext2()
    {
        Assert.That(TestContext.Current.TestName, Is.EqualTo(nameof(TestContext1)));
    }
    
    public static int One() => 1;
    public static int Two() => 2;
}