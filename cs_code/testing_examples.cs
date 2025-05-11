EXAMPLES OF TESTING IN C#/DOTNET
=======================================================================

--> XUnit

// simple implementation of an add method inside calculator class
public class Calculator {
    public int Add(int a, int b) { return a + b; }
}

// write unit test for add method by creating new test class in project
// decorate with [Fact] attribute
public class CalculatorTests {
    [Fact]
    public void Add_PositiveNums_ReturnsExpectedResult() {
        var calc = new Calculator();
        int a = 3; int b = 5;
        int expectedResult = 8;

        // act
        int actualResult = calc.Add(a, b);
        // assert
        Assert.Equal(expectedResult, actualResult);
    }
}

// example of using constructor and disposable
// in xunit, test class constructor used for setup, and IDisposable 
// interface implementation used for teardown
public class MyTestFixture : IDisposable
{
    public MyTestFixture()
    {
        // test setup code here
    }

    public void Dispose()
    {
        // test teardown code here
    }
}

// using theory and inlinedata for robust test cases
[Theory]
[InlineData(1, 2, 3)]
[InlineData(-1, -2, -3)]
public void Add_TwoNumbers_ReturnsSum(int a, int b, int expectedResult)
{
    // test implementation
}

=======================================================================

--> NUnit

namespace Bookstore.Test.NUnit
{
    public class BookTests
    {
        BookDbLessRepository books;

        [SetUp]
        public void Setup()
        {
            // Set up common resources or logic before each test
            books = new BookDbLessRepository();
        }

        [Test]
        public void GetBooks()
        {
            var count = books.GetBooks().Result.Count();

            Assert.That(3 == count);
        }
    }
}

=======================================================================

--> MSUnit

namespace Bookstore.Test.MSUnit
{
    [TestClass]
    public class BookTests
    {
        BookDbLessRepository books;

        [TestInitialize]
        public void TestInitialize()
        {
            // Set up common resources or logic before each test
            books = new BookDbLessRepository();
        }

        [TestMethod]
        public void GetBooks()
        {
            var count = books.GetBooks().Result.Count();

            Assert.AreEqual(3, count);
        }
    }
}

=======================================================================

--> Moq 