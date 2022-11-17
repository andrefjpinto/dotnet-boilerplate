using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using dotnet_boilerplate.Models;
using dotnet_boilerplate.Interfaces;
using dotnet_boilerplate.ViewModels;
using Microsoft.AspNetCore.JsonPatch;

namespace dotnet_boilerplate.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeviceController : ControllerBase
{
    private readonly IRepository<Device> _deviceRepository;
    private readonly IMapper _mapper;

    public DeviceController(IMapper mapper, IRepository<Device> deviceRepository)
    {
        _mapper = mapper;
        _deviceRepository = deviceRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<DeviceViewModel>>> GetDevice([FromQuery(Name = "brand")] string? brand)
    {
        IEnumerable<Device> devices;

        if (brand != null)
        {
            devices = await _deviceRepository
                .FindByConditionAsync(device 
                    => device.Brand!.Equals((brand)));
        }
        else
        {
            devices = await _deviceRepository.FindAllAsync();
        }

        return Ok(_mapper.Map<IEnumerable<DeviceViewModel>>(devices));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<DeviceViewModel>> GetDevice(Guid id)
    {
        var device = (await _deviceRepository
                .FindByConditionAsync(device => device.Id.Equals(id)))
            .FirstOrDefault();
        if (device == null) return NotFound();
        
        return _mapper.Map<DeviceViewModel>(device);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<DeviceViewModel>> UpdateDevice(Guid id, [FromBody]DeviceViewModel deviceViewModel)
    {
        if(id != deviceViewModel.Id) return BadRequest();
        _deviceRepository.Update(_mapper.Map<Device>(deviceViewModel));
        await _deviceRepository.SaveChangesAsync();
        return NoContent();
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchDevice(Guid id, JsonPatchDocument<DeviceViewModel> patch)
    {
        var device = (await _deviceRepository
                .FindByConditionAsync(device => device.Id.Equals(id)))
            .FirstOrDefault();
        if (device == null) return NotFound();
        
        var deviceViewModel = _mapper.Map<DeviceViewModel>(device);
        patch.ApplyTo(deviceViewModel);
        
        device = _mapper.Map<Device>(deviceViewModel);
        _deviceRepository.Update(device);
        await _deviceRepository.SaveChangesAsync();

        return Ok(deviceViewModel);
    }

    [HttpPost]
    public async Task<ActionResult> PostDevice(CreateDeviceViewModel device)
    {
        _deviceRepository.Create(_mapper.Map<Device>(device));
        var result = await _deviceRepository.SaveChangesAsync();
        
        return StatusCode((result) 
            ? StatusCodes.Status201Created 
            : StatusCodes.Status500InternalServerError);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDevice(Guid id)
    {
        var device = (await _deviceRepository
                .FindByConditionAsync(device => device.Id.Equals(id)))
            .FirstOrDefault();
        if (device == null) return BadRequest();
        
        _deviceRepository.Delete(device);
        await _deviceRepository.SaveChangesAsync();
        
        return NoContent();
    }
}