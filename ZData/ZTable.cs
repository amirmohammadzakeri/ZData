using System.Buffers;

namespace ZData;

public readonly struct ZTable : IDisposable
{
    private static readonly ArrayPool<ZCell> Pool = ArrayPool<ZCell>.Shared;
    private readonly ZCell[]? _data;
    
    private readonly int _recordLength;
    private readonly int _numRecords;
    
    public ZTable(int recordLength,int numRecords)
    {
        _numRecords = numRecords;
        _recordLength = recordLength;
        _data = Pool.Rent(_recordLength * _numRecords);
    }
    
    public Span<ZCell> GetRecordSpan(int recordNum)
    {
        return _data.AsSpan().Slice(recordNum * _recordLength, _recordLength);
    }

    public IEnumerable<Memory<ZCell>> GetEnumerable()
    {
        for (int i = 0; i < _numRecords; i++)
        {
            yield return _data.AsMemory().Slice(i * _recordLength, _recordLength);
        }
    }
    
    public void Dispose()
    {
        if (_data != null) Pool.Return(_data);
    }
}