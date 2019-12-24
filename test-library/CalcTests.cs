using NUnit.Framework;
using library;
using Moq;
 
namespace test_library
{
    [TestFixture]
    public class CalcTests
    {
        private Calculator calculator;
        private Mock<IDiscountProvider> mockedProvider;
        private void SetStubProvider()
        {
            mockedProvider = new Mock<IDiscountProvider>();
            mockedProvider.Setup(x => x.GetDiscountByCode("XMAS")).Returns(10);
            mockedProvider.Setup(x => x.GetDiscountByCode("BLACKFRIDAY")).Returns(20);
        }

        [SetUp]
        public void Setup()
        {
            SetStubProvider();
            calculator = new Calculator();
            calculator.SetProvider(mockedProvider.Object);
        }

        [Test]
        /// <summary>
        /// STUB: Asserts that the Calculator class calculates the total applying the XMAS code.
        /// </summary>
        public void ApplyDiscount_WhenCodeIsXMAS_TenPercentIsApplied()
        {
            // Arrange
            var code = "XMAS";

            // Act
            var total = calculator.CalculateTotal(100, code);
            
            // Assert
            Assert.AreEqual(90, total);
        }

        [Test]
        /// <summary>
        /// STUB: Asserts that the Calculator class calculates the total applying the BLACKFRIDAY code.
        /// </summary>
        public void ApplyDiscount_WhenCodeIsBLACKFRIDAY_TwentyPercentIsApplied()
        {
            // Arrange
            var code = "BLACKFRIDAY";
            
            // Act
            var total = calculator.CalculateTotal(100, code);
            
            // Assert
            Assert.AreEqual(80, total);
        }

        [Test]
        /// <summary>
        /// MOCK: Asserts that the GetDiscountByCode is called by the Calculator passing the corresponding discount code.
        /// </summary>
        public void ApplyDiscount_WhenACodeIsProvided_ACallToProviderIsPerformed()
        {
            // Arrange
            var code = "BLACKFRIDAY";
            var mockedObject = mockedProvider.Object;

            // Act
            var total = calculator.CalculateTotal(100, code);

            // Assert
            mockedProvider.Verify(mock => mock.GetDiscountByCode(code), Times.Once());
        }
    }
}
