ZData is a fast non-allocating data structure written in C#. <br/>
Benchmark Result: <br/>

| Method                    | Mean          | Error         | StdDev        | Gen0    | Gen1    | Allocated |
|-------------------------- |--------------:|--------------:|--------------:|--------:|--------:|----------:|
| ArrayRecordBenchmark      |      23.12 ns |      3.658 ns |      1.913 ns |  0.0280 |       - |      88 B |
| DictionaryRecordBenchmark |     142.81 ns |     11.243 ns |      7.437 ns |  0.1121 |       - |     352 B |
| ZRecordBenchmark          |      51.69 ns |     11.961 ns |      7.911 ns |       - |       - |         - |
| ArrayTableBenchmark       |  39,671.51 ns |  9,227.405 ns |  6,103.357 ns | 30.5786 | 10.1318 |   96056 B |
| DictionaryTableBenchmark  | 179,708.52 ns | 15,899.356 ns | 10,516.440 ns | 82.2754 | 39.0625 |  360056 B |
| ZTableBenchmark           |  27,926.38 ns |    920.680 ns |    481.533 ns |       - |       - |      84 B |