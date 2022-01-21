using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceTemplate.Dto;
using ServiceTemplate.Model;
using ServiceTemplate.WebApi;

namespace ServiceTemplate.Tests.WebApi;

[TestClass]
public class DtoMappingProfileTest
{
    [TestInitialize]
    public void TestInitialize()
    {
        _configuration = new MapperConfiguration(cfg => { cfg.AddMaps(typeof(DtoMappingProfile)); });
        _mapper = _configuration.CreateMapper();
    }

    [TestMethod]
    public void ConfigurationIsValid()
    {
        _configuration.AssertConfigurationIsValid();
    }

    [TestMethod]
    public void MapModelToDtoIsCorrect()
    {
        ExampleModel model = new(42, "one", "two");
        ExampleModelDto dto = _mapper.Map<ExampleModelDto>(model);

        Assert.AreEqual(42, dto.Id);
        Assert.AreEqual("one", dto.Property1);
        Assert.AreEqual("two", dto.Property2);
    }

    [TestMethod]
    public void MapCreateDtoToModelIsCorrect()
    {
        ExampleModelCreateDto dto = new("one", "two");
        ExampleModel model = _mapper.Map<ExampleModel>(dto);

        Assert.AreEqual(0, model.Id);
        Assert.AreEqual("one", model.Property1);
        Assert.AreEqual("two", model.Property2);
    }

    private MapperConfiguration _configuration = default!;
    private IMapper _mapper = default!;
}