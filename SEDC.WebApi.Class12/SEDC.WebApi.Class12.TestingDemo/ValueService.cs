namespace SEDC.WebApi.Class12.TestingDemo
{
    public class ValueService
    {
        public int? Sum(int num1, int num2)
        {
            var res = num1 + num2;
            if (num1 < 0 && num2 < 0 && res < 0)
            {
                return null;
            }
            return res;
        }

        public bool isFirstLarger(int num1, int num2)
        {
            return num1 > num2;
        }

        public string GetDigitName(int num)
        {
            List<string> digitNames = new()
            {
                "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"
            };
            return digitNames[num];
        }
    }

    [TestClass]
    public class ValueTests
    {
        private ValueService _valueService;

        public ValueTests()
        {
            _valueService = new ValueService();
        }

        [TestMethod]
        public void Sum_PositiveIntegers_ResultNumber()
        {
            // Arange
            var num1 = 5;
            var num2 = 5;
            var res = 10;

            // act
            var testResult = _valueService.Sum(num1, num2);

            // Assert
            Assert.AreEqual(res, testResult);
        }

        [TestMethod]
        public void Sum_NegativeIntegers_ResultNumber()
        {
            // Arrange
            var num1 = -10;
            var num2 = -5;

            //act
            var testResult = _valueService.Sum(num1, num2);

            //Assert
            Assert.IsNull(testResult);
        }

        [TestMethod]
        public void GetDigits_Result()
        {
            // Arrange
            var num = 10;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => _valueService.GetDigitName(num));
        }
    }
}
