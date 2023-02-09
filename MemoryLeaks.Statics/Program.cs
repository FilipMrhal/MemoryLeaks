Console.WriteLine(GC.GetTotalAllocatedBytes());
var tc = new TestClass();
Console.ReadLine();
for (var i = 0; i < 100000000; i++)
{
    tc.AddFilter(Guid.NewGuid().ToString());
}
Console.WriteLine(GC.GetTotalAllocatedBytes());
GC.Collect();
GC.WaitForPendingFinalizers();
GC.Collect();
Console.WriteLine(GC.GetTotalAllocatedBytes());
Console.ReadLine();

public class TestClass
{
    private static readonly List<Filter> _filters = new();
    
    public void AddFilter(string filterString)
    {
        _filters.Add(new Filter(filterString));
    }
}

public class Filter
{
    public Filter(string filterString)
    {
        FilterString = filterString;
    }

    public string FilterString { get; }
}