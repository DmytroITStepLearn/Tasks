namespace Task_Linq;

public static class Task
{
    // Example how to implement tasks
    // Use only LINQ syntax
    public static IEnumerable<int> Example(IEnumerable<int> collection)
    {
        return collection.Select(x => x * x);
    }
    
    /// <summary>
    /// Returns elements of the collection that starts and ends with the symbol
    /// </summary>
    public static IEnumerable<string> Task1(IEnumerable<string> collection, char symbol)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns length of the elements of the collection sorted by length ascending
    /// </summary>
    public static IEnumerable<int> Task2(IEnumerable<string> collection)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns the day of week in string representation for dates that greater than 01.01.2025
    /// and sorted by date value descending 
    /// </summary>
    public static IEnumerable<string> Task3(IEnumerable<DateTime> collection)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns the first element of the collection if it can be converted to int.
    /// Throws exception if no value was found
    /// </summary>
    public static int Task4(IEnumerable<string> collection)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns the smallest by length element of the collection that contains word parameter in it and
    /// the length of the element is greater than the length of the word parameter
    /// </summary>
    public static string Task5(IEnumerable<string> collection, string word)
    {
        throw new NotImplementedException();
    }
}