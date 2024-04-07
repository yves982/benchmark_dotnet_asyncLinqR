using AsyncLinqR;

namespace Benchmark;

public class AsyncLinqRDogsInspector : DogsInspector
{
    public AsyncLinqRDogsInspector(IAsyncEnumerable<DogInspectable> dogs)
    {
        Dogs = dogs;
    }

    public IAsyncEnumerable<DogInspectable> Dogs { get; }
    public async Task<object?> InspectWithPartialName(string partialName)
    {
        await foreach (DogInspectable dog in Dogs.WhereAsync(d =>
                           d.Dog.Name.IndexOf(partialName, StringComparison.InvariantCulture) != -1))
        {
            dog.Inspect();
        }

        return null;
    }
}