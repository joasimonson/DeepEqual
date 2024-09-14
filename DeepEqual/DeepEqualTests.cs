using DeepEqual.Syntax;
using Xunit;

namespace DeepEqualTest;

public class DeepEqualTests
{
    public record Address(string City, string State);
    public record Person(string Name, int Age, Address? Address = null);

    [Fact]
    public void DeeplyNestedObjects_ShouldBeEqual()
    {
        var person1 = new Person("Jo", 30, new Address(City: "Unknown", State: "UN"));
        var person2 = new Person("Jo", 30, new Address(City: "Unknown", State: "UN"));

        Assert.True(person1.IsDeepEqual(person2));
        person1.ShouldDeepEqual(person2);
    }

    [Fact]
    public void ReferenceTypes_ShouldBeEqualByValue()
    {
        var array1 = new int[] { 1, 2, 3 };
        var array2 = new int[] { 1, 2, 3 };

        array1.ShouldDeepEqual(array2);
    }

    [Fact]
    public void ObjectsIgnoringCertainFields_ShouldBeEqual()
    {
        var person1 = new Person("An", 25);
        var person2 = new Person("An", 30);

        Assert.True(person1.WithDeepEqual(person2).IgnoreProperty<Person>(p => p.Age).Compare());
        person1.WithDeepEqual(person2).IgnoreProperty<Person>(p => p.Age).Assert();
    }

    [Fact]
    public void ListsOfObjects_ShouldBeEqual()
    {
        var list1 = new List<Person>
        {
            new("Jo", 30),
            new("An", 25)
        };

        var list2 = new List<Person>
        {
            new("Jo", 30),
            new("An", 25)
        };

        list1.ShouldDeepEqual(list2);
    }

    [Fact]
    public void Dictionaries_ShouldBeEqual()
    {
        var dict1 = new Dictionary<string, Person>
        {
            { "Jo", new("Jo", 30) },
            { "An", new("An", 25) }
        };

        var dict2 = new Dictionary<string, Person>
        {
            { "Jo", new("Jo", 30) },
            { "An", new("An", 25) }
        };

        dict1.ShouldDeepEqual(dict2);
    }
}
