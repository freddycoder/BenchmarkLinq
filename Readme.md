# BenchmarkLinq

Some code to benchmark code snippet.

### Run on my laptop

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

### Run on a AKS cluster

With a CPU limit of 100m

``` ini

BenchmarkDotNet=v0.13.1, OS=debian 11 (container)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|             Method |          Mean |      Error |     StdDev |        Median | Allocated |
|------------------- |--------------:|-----------:|-----------:|--------------:|----------:|
| UsingCountProperty |     0.0054 ns |  0.0081 ns |  0.0230 ns |     0.0000 ns |         - |
|          UsingLinq |    68.8651 ns |  1.8410 ns |  4.6524 ns |    71.1570 ns |         - |
|    ForeachAndCount | 3,062.7949 ns | 48.5340 ns | 37.8922 ns | 3,073.5560 ns |         - |
|        ForAndCount |   278.9526 ns |  8.7745 ns | 25.7342 ns |   265.0045 ns |         - |

With a CPU limit of 500m

``` ini

BenchmarkDotNet=v0.13.1, OS=debian 11 (container)
Intel Xeon CPU E5-2673 v4 2.30GHz, 1 CPU, 2 logical and 2 physical cores
.NET SDK=6.0.300
  [Host]     : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT
  DefaultJob : .NET 6.0.5 (6.0.522.21309), X64 RyuJIT


```
|             Method |        Mean |      Error |     StdDev |      Median | Allocated |
|------------------- |------------:|-----------:|-----------:|------------:|----------:|
| UsingCountProperty |   0.0194 ns |  0.0564 ns |  0.0926 ns |   0.0000 ns |         - |
|          UsingLinq |  12.6004 ns |  0.3587 ns |  0.3355 ns |  12.6517 ns |         - |
|    ForeachAndCount | 722.0841 ns | 16.2050 ns | 47.5266 ns | 740.4247 ns |         - |
|        ForAndCount |  61.5632 ns |  1.2791 ns |  3.7715 ns |  59.6754 ns |         - |

## Build a docker images

Inside the BenchmarkLinq folder, run:

```
docker build -t benchmarklinq -f Dockerfile .
```

Run the images

```
docker run --rm -it benchmarklinq
```

Tag the images

```
docker tag benchmarklinq erabliereapi/benchmark-csharp-dotnet
```

Push the images

```
docker push erabliereapi/benchmark-csharp-dotnet
```