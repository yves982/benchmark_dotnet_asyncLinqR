namespace Benchmark;

public interface DogsInspector
{
    public IAsyncEnumerable<DogInspectable> Dogs { get; }

    public Task<object?> InspectWithPartialName(string partialName);
}