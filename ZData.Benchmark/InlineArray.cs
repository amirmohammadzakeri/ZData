using System.Runtime.CompilerServices;
namespace ZData.Benchmark;

[InlineArray(100)]
public struct InlineArray<T>
{
    private T _element;
}