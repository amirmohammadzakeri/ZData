using System.Buffers;

namespace ZData;

public readonly struct ZRecord : IDisposable
{
    private static readonly ArrayPool<ZCell> Pool = ArrayPool<ZCell>.Shared;
    private readonly ZCell[] _data;

    public ZRecord(int recordLength)
    {
        _data = Pool.Rent(recordLength);
    }

    public Span<ZCell> GetSpan()
    {
        return _data.AsSpan();
    }
    
    public void Dispose()
    {
        Pool.Return(_data);
    }
}