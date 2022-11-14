using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using dotnet_boilerplate.Models;
using dotnet_boilerplate.Interfaces;
using dotnet_boilerplate.ViewModels;

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

    // GET: api/Device
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Device>>> GetDevice([FromQuery(Name = "brand")] string? brand)
    {
        IEnumerable<Device> devices;
        
        if (brand != null)
        {
            devices = _deviceRepository.FindByCondition(x => x.Brand!.Equals((brand)));
        }
        else
        { 
            devices = await _deviceRepository.GetAllAsync();
        }

        var result = _mapper.Map<IEnumerable<DeviceViewModel>>(devices);
        return Ok(result);
    }
    
    // GET: api/Device/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Device>> GetDevice(Guid id)
    {
        var device = await _deviceRepository.GetByIdAsync(id);
        
        if (device == null)
        {
            return NotFound();
        }
        
        return device;
    }

    // // PUT: api/Device/5
    // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    // [HttpPut("{id}")]
    // public async Task<IActionResult> PutDevice(Guid id, Device device)
    // {
    //     if (id != device.Id)
    //     {
    //         return BadRequest();
    //     }

    //     _context.Entry(device).State = EntityState.Modified;

    //     try
    //     {
    //         await _context.SaveChangesAsync();
    //     }
    //     catch (DbUpdateConcurrencyException)
    //     {
    //         if (!DeviceExists(id))
    //         {
    //             return NotFound();
    //         }
    //         else
    //         {
    //             throw;
    //         }
    //     }

    //     return NoContent();
    // }

    // POST: api/Device
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<DeviceViewModel>> PostDevice(CreateDeviceViewModel device)
    {
        var newDevice = _mapper.Map<Device>(device);
        _deviceRepository.Add(newDevice);
        await _deviceRepository.SaveChangesAsync();
        var result = _mapper.Map<DeviceViewModel>(newDevice);
        return Ok(result);
    }

    // DELETE: api/Device/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDevice(Guid id)
    {
        var device = await _deviceRepository.GetByIdAsync(id);
        
        if (device == null) return BadRequest();

        _deviceRepository.Delete(device);
        await _deviceRepository.SaveChangesAsync();

        return NoContent();
    }
}