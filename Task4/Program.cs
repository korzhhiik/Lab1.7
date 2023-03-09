
class Program
{
    delegate int StringLengthDelegate(string str);

    static void Main(string[] args)
    {
        var strings = new List<string>
        {
            "apple",
            "banana",
            "cherry",
            "date"
        };
        
        StringLengthDelegate stringLength = str => str.Length;
        
        foreach (var str in strings)
        {
            Console.WriteLine("{0}: {1}", str, stringLength(str));
        }
    }
}