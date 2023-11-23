using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace ZData.Benchmark;
[MemoryDiagnoser]
[SimpleJob(1,3,10)]
public class Program
{
    private static readonly int RecordLength = 5;
    private static readonly int RecordNum = 1000;
    
    [Benchmark]
    public void ArrayRecordBenchmark()
    {
        var rec = new object[RecordLength];
        rec[0] = 1;
        rec[1] = "hello guys.";
    }
    
    [Benchmark]
    public void DictionaryRecordBenchmark()
    {
        var rec = new Dictionary<string, object>(RecordLength)
        {
            ["0"] = 1,
            ["1"] = "hello guys."
        };
    }
    
    [Benchmark]
    public void ZRecordBenchmark()
    {
        using (var rec = new ZRecord(RecordLength))
        {
            var recSpan = rec.GetSpan();
            recSpan[0].IntValue = 1;
            recSpan[1].StringValue = "hello guys.";
        }
    }
    [Benchmark]
    public void ArrayTableBenchmark()
    {
        var tbl = new List<object[]>(RecordNum);
        for (int i = 0; i < RecordNum; i++)
        {
            var rec = new object[RecordLength];
            rec[0] = 1;
            rec[1] = "hello guys.";
            tbl.Add(rec);
        }
    }

    [Benchmark]
    public void DictionaryTableBenchmark()
    {
        var tbl = new List<Dictionary<string, object>>(RecordNum);
        for (int i = 0; i < RecordNum; i++)
        {
            var rec = new Dictionary<string, object>(RecordLength);
            rec["0"] = 1;
            rec["1"] = "hello guys.";
            tbl.Add(rec);
        }
    }
    
    [Benchmark]
    public void ZTableBenchmark()
    {
        using (var table = new ZTable(RecordLength, RecordNum))
        {
            foreach (var rec in table.GetEnumerable())
            {
                rec.Span[0].IntValue = 1;
                rec.Span[1].StringValue = "hello guys.";
            }
        }
    }
    
    
    
    
    public static void Main( string[] args)
    {
        BenchmarkRunner.Run<Program>();
    }
}