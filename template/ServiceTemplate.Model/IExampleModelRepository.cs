namespace ServiceTemplate.Model;

public interface IExampleModelRepository
{
    Task<List<ExampleModel>> GetAllAsync();

    Task<ExampleModel> GetByIdAsync(int id);

    Task<ExampleModel> SaveAsync(ExampleModel exampleModel);

    Task DeleteAsync(int id);
}