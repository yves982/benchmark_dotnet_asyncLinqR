namespace Benchmark;

public class DogInspectable : Inspectable
{
    public Dog Dog { get; }

    public DogInspectable(Dog dog)
    {
        Dog = dog;
    }
    
    public string Inspect()
    {
        return $"your dog: {Dog.Name} is {Dog.Age} years old.";
    }
}