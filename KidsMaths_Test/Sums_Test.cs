using Microsoft.VisualStudio.TestTools.UnitTesting;
using KidsMaths;

namespace KidsMaths_Test
{
    [TestClass]
    public class Sums_Test
    {
        [TestMethod]
        public void TestAdd()
        {
            // Arrange
            Sums sums = new Sums(0, 20, Operator.Addition);

            // Act
            SumDisplay sumDisplay = sums.GetAdditionAndSubtraction();

            // Assert
            Assert.AreEqual("+", sumDisplay.Operator);
            Assert.AreEqual(sumDisplay.Answer, (sumDisplay.FirstNumber + sumDisplay.SecondNumber));
        }

        [TestMethod]
        public void TestSubtract()
        {
            // Arrange
            Sums sums = new Sums(0, 20, Operator.Subtraction);

            // Act
            SumDisplay sumDisplay = sums.GetAdditionAndSubtraction();

            // Assert
            Assert.AreEqual("-", sumDisplay.Operator);
            Assert.AreEqual(sumDisplay.Answer, (sumDisplay.FirstNumber - sumDisplay.SecondNumber));
        }
    }
}
