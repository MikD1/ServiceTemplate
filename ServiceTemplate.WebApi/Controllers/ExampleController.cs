using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceTemplate.Dto;
using ServiceTemplate.Model;

namespace ServiceTemplate.WebApi.Controllers;

[ApiController]
[Route("api/example")]
public class ExampleController : ControllerBase
{
    public ExampleController(ILogger<ExampleController> logger, IMapper mapper, IExampleModelRepository repository)
    {
        _logger = logger;
        _mapper = mapper;
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<List<ExampleModelDto>>> Get()
    {
        List<ExampleModel> model = await _repository.GetAllAsync();
        List<ExampleModelDto> dto = _mapper.Map<List<ExampleModelDto>>(model);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<ActionResult<ExampleModelDto>> Post([FromBody] ExampleModelCreateDto createDto)
    {
        ExampleModel model = _mapper.Map<ExampleModel>(createDto);
        model = await _repository.SaveAsync(model);

        _logger.Log(LogLevel.Information, $"Created new model: '{model.Id}' | '{model.Property1} | {model.Property2}'");

        ExampleModelDto dto = _mapper.Map<ExampleModelDto>(model);
        return Ok(dto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ExampleModelDto>> Put(int id, [FromBody] ExampleModelUpdateDto updateDto)
    {
        ExampleModel model = await _repository.GetByIdAsync(id);
        model.UpdateProperties(updateDto.Property1, updateDto.Property2);
        model = await _repository.SaveAsync(model);

        _logger.Log(LogLevel.Information, $"Updated model: '{model.Id}' | '{model.Property1} | {model.Property2}'");

        ExampleModelDto dto = _mapper.Map<ExampleModelDto>(model);
        return Ok(dto);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await _repository.DeleteAsync(id);
        _logger.Log(LogLevel.Information, $"Deleted model: '{id}'");
        return NoContent();
    }

    private readonly ILogger<ExampleController> _logger;
    private readonly IMapper _mapper;
    private readonly IExampleModelRepository _repository;
}