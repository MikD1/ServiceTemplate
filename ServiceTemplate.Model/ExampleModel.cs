namespace ServiceTemplate.Model;

public class ExampleModel
{
    public ExampleModel(string property1, string property2)
        : this(default, property1, property2)
    {
    }

    public ExampleModel(int id, string property1, string property2)
    {
        Id = id;
        Property1 = property1;
        Property2 = property2;
    }

    public int Id { get; private set; }

    public string Property1 { get; private set; }

    public string Property2 { get; private set; }

    public void UpdateProperties(string property1, string property2)
    {
        Property1 = property1;
        Property2 = property2;
    }
}