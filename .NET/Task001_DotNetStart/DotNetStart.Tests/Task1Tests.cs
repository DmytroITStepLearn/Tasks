using System.Text.RegularExpressions;
using Task001_DotNetStart;

namespace DotNetStart.Tests
{
    public class Task1Tests
    {
        private char[] _specialCharacters = ['\n', '\r', '\t'];

        [Fact]
        public void AddNumbersTogetherTest()
        {
            var algorithms = new Algorithms();
            Console.SetIn(new StringReader("1\n2\n3\n4"));
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            var expected = "1234";

            algorithms.AddNumbersTogether();
            var result = RemoveSpecialCharacters(stringWriter.ToString());

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("2024.11.13", "Autumn Wednesday")]
        [InlineData("2024.12.09", "Winter Monday")]
        [InlineData("2024.08.02", "Summer Friday")]
        [InlineData("2025.03.02", "Spring Sunday")]
        public void ShowDateStringTest(string date, string expected)
        {
            var algorithms = new Algorithms();
            Console.SetIn(new StringReader(date));
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);

            algorithms.ShowDateString();
            var result = RemoveSpecialCharacters(stringWriter.ToString());

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(100, 10, 10)]
        [InlineData(50, 50, 25)]
        [InlineData(56, 30, 16.8)]
        [InlineData(148, 8, 11.84)]
        [InlineData(59_986, 99, 59_386.14)]
        [InlineData(300, 0, 0)]
        public void CalculatePercentTest(int number, int percent, double expected)
        {
            var algorithms = new Algorithms();
            
            var result = algorithms.CalculatePercent(number, percent);

            Assert.Equal(expected, result, 5);
        }

        private string RemoveSpecialCharacters(string text)
        {
            return Regex.Replace(text, string.Join("|", _specialCharacters), "");
        }
    }
}