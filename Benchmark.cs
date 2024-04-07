using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Benchmark;

[SimpleJob(RuntimeMoniker.Net70)]
[HtmlExporter]
public class Benchmark
{
    private char[] _characters = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
    private IList<DogInspectable> _dogs = null!;
    private Random _rand = new ();
    private StringBuilder _sb = new ();
    
    [Params(1000, 20_000, 40_000, 50_000)]
    public int N;
    
    [GlobalSetup]
    public void Setup()
    {
        _dogs = new List<DogInspectable>(N);
        for (int i = 0; i < N; i++)
        {
            _dogs.Add(new DogInspectable(new Dog
            {
                Age = _rand.Next(1, 16), 
                Name = _generateName()
            }));
        }
    }

    private string _generateName()
    {
        int length = _rand.Next(20, 26);
        // makes sure all names are matched
        _sb.Append("a");
        for (int i = 0; i < length; i++)
        {
            _sb.Append(_characters[_rand.Next(0, 26)]);
        }
        return _sb.ToString();
    }
    
    private async IAsyncEnumerable<T> _toAsync<T>(IEnumerable<T> collection) where T : class 
    {
        foreach (var it in collection)
        {
            yield return it;
            await Task.Delay(150);
        }        
    }

    [Benchmark]
    public void WithAsyncLinqR()
    {
        DogsInspector inspector = new AsyncLinqRDogsInspector(_toAsync(_dogs));
        inspector.InspectWithPartialName("a");
    }

    [Benchmark]
    public void WithSystemAsyncLinq()
    {
        DogsInspector inspector = new SystemAsyncGodsInspector(_toAsync(_dogs));
        inspector.InspectWithPartialName("a");
    }
}