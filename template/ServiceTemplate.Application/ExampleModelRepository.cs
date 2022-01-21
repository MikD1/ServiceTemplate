using Microsoft.EntityFrameworkCore;
using ServiceTemplate.Model;

namespace ServiceTemplate.Application;

public class ExampleModelRepository : IExampleModelRepository
{
    public ExampleModelRepository(ServiceDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ExampleModel>> GetAllAsync()
    {
        return await _dbContext.ExampleModels
            .OrderBy(x => x.Id)
            .ToListAsync();
    }

    public async Task<ExampleModel> GetByIdAsync(int id)
    {
        return await _dbContext.ExampleModels.FirstAsync(x => x.Id == id);
    }

    public async Task<ExampleModel> SaveAsync(ExampleModel exampleModel)
    {
        if (exampleModel.Id == 0)
        {
            await _dbContext.ExampleModels.AddAsync(exampleModel);
        }
        else
        {
            _dbContext.Entry(exampleModel).State = EntityState.Modified;
        }

        await _dbContext.SaveChangesAsync();
        return exampleModel;
    }

    public async Task DeleteAsync(int id)
    {
        ExampleModel exampleModel = await _dbContext.ExampleModels.FirstAsync(x => x.Id == id);
        _dbContext.ExampleModels.Remove(exampleModel);
        await _dbContext.SaveChangesAsync();
    }

    private readonly ServiceDbContext _dbContext;
}