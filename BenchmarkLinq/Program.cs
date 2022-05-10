using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace BenchmarkLinq;

class Program
{
    static void Main()
    {
        var summary = BenchmarkRunner.Run(typeof(LinqPerformance).Assembly);
    }
}

[MarkdownExporter]
[MemoryDiagnoser]
public class LinqPerformance
{
    static List<object?> list = new List<object?>(new object[] { null, null, null });

    [Benchmark]
    public int UsingCountProperty()
    {
        var count = list.Count;

        return count;
    }

    [Benchmark]
    public int UsingLinq()
    {
        var count = list.Count();

        return count;
    }

    [Benchmark]
    public int ForeachAndCount()
    {
        var count = 0;

        foreach (var item in list)
        {
            foreach (var item2 in list)
            {
                foreach (var item3 in list)
                {
                    count += list.Count();
                }
            }
        }

        return count;
    }

    [Benchmark]
    public int ForAndCount()
    {
        var count = 0;

        for (var i = 0; i < list.Count; i++)
        {
            for (var j = 0; j < list.Count; j++)
            {
                for (var k = 0; k < list.Count; k++)
                {
                    count += list.Count;
                }
            }
        }

        return count;
    }
}