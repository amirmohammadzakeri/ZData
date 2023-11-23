// See https://aka.ms/new-console-template for more information


using System.Security.Cryptography;
using ZData;


// ZRecord Sample :
using (var rec = new ZRecord(5))
{
    var recSpan = rec.GetSpan();
    recSpan[0].IntValue = 1;
    recSpan[1].StringValue = "hello guys.";
    
}

// ZTable Sample
using (var table = new ZTable(5, 10))
{
    foreach (var rec in table.GetEnumerable())
    {
        rec.Span[0].IntValue = 1;
        rec.Span[1].StringValue = "hello guys.";
    }
}

