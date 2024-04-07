```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.3374/23H2/2023Update/SunValley3)
Intel Core i7-10700 CPU 2.90GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK 7.0.203
  [Host]   : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2
  .NET 7.0 : .NET 7.0.5 (7.0.523.17405), X64 RyuJIT AVX2

Job=.NET 7.0  Runtime=.NET 7.0  

```
| Method              | N     | Mean     | Error    | StdDev    |
|-------------------- |------ |---------:|---------:|----------:|
| **WithAsyncLinqR**      | **1000**  | **19.52 μs** | **0.655 μs** |  **1.860 μs** |
| WithSystemAsyncLinq | 1000  | 32.00 μs | 1.886 μs |  5.561 μs |
| **WithAsyncLinqR**      | **20000** | **30.86 μs** | **4.039 μs** | **11.846 μs** |
| WithSystemAsyncLinq | 20000 | 31.34 μs | 1.914 μs |  5.645 μs |
| **WithAsyncLinqR**      | **40000** | **26.10 μs** | **2.260 μs** |  **6.629 μs** |
| WithSystemAsyncLinq | 40000 | 44.54 μs | 4.236 μs | 12.491 μs |
| **WithAsyncLinqR**      | **50000** | **37.74 μs** | **2.772 μs** |  **8.129 μs** |
| WithSystemAsyncLinq | 50000 | 43.61 μs | 4.539 μs | 13.312 μs |
