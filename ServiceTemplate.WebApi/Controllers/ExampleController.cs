using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServiceTemplate.Dto;
using ServiceTemplate.Model;

namespace ServiceTemplate.WebApi.Controllers;

[ApiController]
[Route("example")]
public class ExampleController : ControllerBase
{
    public ExampleController(ILogger<ExampleController> logger, IMapper mapper)
    {
        _logger = logger;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<List<ExampleModelDto>> Get()
    {
        List<ExampleModel> model = new()
        {
            new(42, "hello", "world"),
            new(235, "abc", "xyz"),
            new(782, "a1", "b2 c3")
        };

        List<ExampleModelDto> dto = _mapper.Map<List<ExampleModelDto>>(model);
        return Ok(dto);
    }

    [HttpPost]
    public ActionResult<ExampleModelDto> Post([FromBody] ExampleModelCreateDto createDto)
    {
        ExampleModel model = _mapper.Map<ExampleModel>(createDto);
        _logger.Log(LogLevel.Information, $"Created new model: '{model.Property1} - {model.Property2}'");

        ExampleModelDto dto = _mapper.Map<ExampleModelDto>(model);
        return Ok(dto);
    }

    [HttpPut("{id}")]
    public ActionResult<ExampleModelDto> Put(int id, [FromBody] ExampleModelUpdateDto updateDto)
    {
        ExampleModel model = _mapper.Map<ExampleModel>(updateDto);
        _logger.Log(LogLevel.Information, $"Updated model: '{model.Property1} - {model.Property2}'");

        ExampleModelDto dto = _mapper.Map<ExampleModelDto>(model);
        return Ok(dto);
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        _logger.Log(LogLevel.Information, $"Deleted model: '{id}'");
        return NoContent();
    }

    private readonly ILogger<ExampleController> _logger;
    private readonly IMapper _mapper;
}