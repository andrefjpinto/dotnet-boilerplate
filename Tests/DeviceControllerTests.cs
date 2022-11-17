using System.Linq.Expressions;
using AutoMapper;
using dotnet_boilerplate.Controllers;
using dotnet_boilerplate.Interfaces;
using dotnet_boilerplate.Models;
using dotnet_boilerplate.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace Tests;

public class DeviceControllerTests
{
    [Fact]
    public async Task GetDevice_Should_Return_ListOfDevices()
    {
        // Arrange
        IEnumerable<Device> getAllResult = new List<Device>()
        {
            new Device() { Brand = "iPhone", Name = "XS Pro" }
        };

        IEnumerable<DeviceViewModel> mapResult = new List<DeviceViewModel>()
        {
            new DeviceViewModel() { Brand = "iPhone", Name = "XS Pro" }
        };

        var mockMapper = new Mock<IMapper>();
        var mockRepository = new Mock<IRepository<Device>>();

        mockRepository
            .Setup(repo => repo.FindAllAsync())
            .ReturnsAsync(getAllResult);

        mockMapper
            .Setup(repo =>
                repo.Map<IEnumerable<DeviceViewModel>>(It.IsAny<IEnumerable<Device>>()))
            .Returns(mapResult);

        var controller = new DeviceController(mockMapper.Object, mockRepository.Object);

        // Act
        var result = await controller.GetDevice(null);

        // Assert
        var model = Assert
            .IsAssignableFrom<IEnumerable<DeviceViewModel>>((result.Result as OkObjectResult)?.Value);
        var deviceViewModels = model.ToList();
        Assert.Single(deviceViewModels);
        Assert.Equal("iPhone", deviceViewModels.First().Brand);
        Assert.Equal("XS Pro", deviceViewModels.First().Name);
    }

    [Fact]
    public async Task GetDevice_ShouldReturn_ListOfDevicesFilteredByName()
    {
        // Arrange
        IEnumerable<Device> findByCondition = new List<Device>()
        {
            new Device() { Brand = "iPhone", Name = "XS Pro" }
        };

        IEnumerable<DeviceViewModel> mapResult = new List<DeviceViewModel>()
        {
            new DeviceViewModel() { Brand = "iPhone", Name = "XS Pro" }
        };

        var mockMapper = new Mock<IMapper>();
        var mockRepository = new Mock<IRepository<Device>>();

        mockRepository
            .Setup(repo => repo.FindByConditionAsync(It.IsAny<Expression<Func<Device, bool>>>()))
            .Returns(Task.FromResult(findByCondition));

        mockMapper
            .Setup(repo =>
                repo.Map<IEnumerable<DeviceViewModel>>(It.IsAny<IEnumerable<Device>>()))
            .Returns(mapResult);

        var controller = new DeviceController(mockMapper.Object, mockRepository.Object);

        // Act
        var result = await controller.GetDevice("iPhone");

        // Assert
        var model = Assert
            .IsAssignableFrom<IEnumerable<DeviceViewModel>>((result.Result as OkObjectResult)?.Value);
        var deviceViewModels = model.ToList();
        Assert.Single(deviceViewModels);
        Assert.Equal("iPhone", deviceViewModels.First().Brand);
        Assert.Equal("XS Pro", deviceViewModels.First().Name);
        mockRepository
            .Verify(mock =>
                    mock.FindByConditionAsync(x => x.Brand!.Equals("iPhone")),
                Times.Once());
    }
}