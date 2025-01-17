namespace Task_Linq.Test;

public class TaskTests
{
    [Fact]
    public void Test_Task1()
    {
        foreach (var (collection, symbol, expected) in GetTask1Data())
        {
            var actual = Task.Task1(collection, symbol);
            Assert.Equal(expected, actual);
        }
    }
    
    [Fact]
    public void Test_Task2()
    {
        foreach (var (collection, expected) in GetTask2Data())
        {
            var actual = Task.Task2(collection);
            Assert.Equal(expected, actual);
        }
    }
    
    [Fact]
    public void Test_Task3()
    {
        foreach (var (collection, expected) in GetTask3Data())
        {
            var actual = Task.Task3(collection);
            Assert.Equal(expected, actual);
        }
    }
    
    [Fact]
    public void Test_Task4()
    {
        foreach (var (collection, expected) in GetTask4Data())
        {
            var actual = Task.Task4(collection);
            Assert.Equal(expected, actual);
        }
    }
    
    [Fact]
    public void Test_Task4_ThrowsException()
    {
        foreach (var collection in GetTask4ThrowsExceptionData())
        {
            var exceptionHandler = () => (object)Task.Task4(collection);
            Assert.Throws<InvalidOperationException>(exceptionHandler);
        }
    }
    
    [Fact]
    public void Test_Task5()
    {
        foreach (var (collection, word, expected) in GetTask5Data())
        {
            var actual = Task.Task5(collection, word);
            Assert.Equal(expected, actual);
        }
    }

    private IEnumerable<(IEnumerable<string> collection, char symbol, IEnumerable<string> expected)> GetTask1Data()
    {
        yield return (["alaska", "umbrella", "alabama", "a", "an", "", "rocket"], 'a', ["alaska", "alabama", "a"]);
        yield return (["b task b", "be the b", "b c d", " bllb ", "bear raeb"], 'b', ["b task b", "be the b", "bear raeb"]);
        yield return (["Can you maC", "can you mac", "Cc", "cC", "something with CC"], 'C', ["Can you maC"]);
        yield return (["c++", "+-+", "+6987/", "+478+"], '+', ["+-+", "+478+"]);
    }
    
    private IEnumerable<(IEnumerable<string> collection, IEnumerable<int> expected)> GetTask2Data()
    {
        yield return (["alaska", "umbrella", "alabama", "a", "an", "", "rocket"],  [0, 1, 2, 6, 6, 7, 8]);
        yield return (["turn", "cap", "the string dudududu", "some sentence with B", "fertility", "the sharp", "some string", ""], [0, 3, 4, 9, 9, 11, 19, 20]);
    }
    
    private IEnumerable<(IEnumerable<DateTime> collection, IEnumerable<string> expected)> GetTask3Data()
    {
        yield return (
        [
            new DateTime(2025, 1, 1),
            new DateTime(2024, 10, 11),
            new DateTime(2025, 5, 15),
            new DateTime(2026, 8, 13),
            new DateTime(2025, 4, 9),
            new DateTime(2013, 10, 8),
            new DateTime(2025, 11, 19),
            new DateTime(2026, 9, 18),
            new DateTime(2025, 7, 21),
        ], 
        ["Friday", "Thursday", "Wednesday", "Monday", "Thursday", "Wednesday"]);
    }
    
    private IEnumerable<(IEnumerable<string> collection, int expected)> GetTask4Data()
    {
        yield return (["one", "13.9", "twenty two", "o", "100", "three", "50", "14.000001"], 100);
        yield return (["-13", "13", "0", "130"], -13);
    }
    
    private IEnumerable<IEnumerable<string>> GetTask4ThrowsExceptionData()
    {
        yield return ["one", "13.9", "twenty two", "o", "three", "14.000001"];
        yield return ["13.8", "14.78", "0.0056"];
        yield return ["one", "two", "three"];
        yield return [];
    }
    
    private IEnumerable<(IEnumerable<string> collection, string word, string expected)> GetTask5Data()
    {
        yield return (["hello there", "hllo ", "", "hello", "+hello", "hello my friend"], "hello", "+hello");
        yield return (["a", "", "aaaaaaaaaa", "ba", "ra", "alla"], "a", "ba");
        yield return (["hello", "hell7", "<7>", "7 out of 7", "172637283778", "77777"], "7", "<7>");
    }
}