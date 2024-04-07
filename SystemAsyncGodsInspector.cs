namespace Benchmark;

public class SystemAsyncGodsInspector : DogsInspector
{
    public SystemAsyncGodsInspector(IAsyncEnumerable<DogInspectable> dogs)
    {
        Dogs = dogs;
    }

    public IAsyncEnumerable<DogInspectable> Dogs { get; }

    public async Task<object?> InspectWithPartialName(string partialName)
    {
        await foreach (DogInspectable dog in Dogs.Where( d => d.Dog.Name.IndexOf(partialName, StringComparison.InvariantCulture) != -1))
        {
            dog.Inspect();
        }

        return null;
    }
}