``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22000
Intel Core i5-10300H CPU 2.50GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK=6.0.202
  [Host]     : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT
  DefaultJob : .NET 6.0.4 (6.0.422.16404), X64 RyuJIT


```
|             Method |        Mean |     Error |    StdDev | Allocated |
|------------------- |------------:|----------:|----------:|----------:|
| UsingCountProperty |   0.2312 ns | 0.0143 ns | 0.0127 ns |         - |
|          UsingLinq |   3.6970 ns | 0.0415 ns | 0.0388 ns |         - |
|    ForeachAndCount | 179.8995 ns | 1.3227 ns | 1.2372 ns |         - |
|        ForAndCount |  11.1418 ns | 0.0849 ns | 0.0753 ns |         - |
