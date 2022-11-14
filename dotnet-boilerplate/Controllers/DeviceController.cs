using Microsoft.AspNetCore.Mvc;
using dotnet_boilerplate.Models;
using dotnet_boilerplate.Interfaces;

namespace dotnet_boilerplate.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DeviceController : ControllerBase
{
    private IRepository<Device> _deviceRepository;

    public DeviceController(IRepository<Device> deviceRepository)
    {
        _deviceRepository = deviceRepository;
    }

    // GET: api/Device
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Device>>> GetDevice()
    {
        return Ok(await _deviceRepository.GetAllAsync());
    }

    // // GET: api/Device/5
    // [HttpGet("{id}")]
    // public async Task<ActionResult<Device>> GetDevice(Guid id)
    // {
    //     if (_context.Device == null)
    //     {
    //         return NotFound();
    //     }
    //     var device = await _context.Device.FindAsync(id);

    //     if (device == null)
    //     {
    //         return NotFound();
    //     }

    //     return device;
    // }

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
    public async Task<ActionResult<Device>> PostDevice(Device device)
    {
        _deviceRepository.Add(device);
        return Ok(await _deviceRepository.SaveChangesAsync());
    }

    // // DELETE: api/Device/5
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteDevice(Guid id)
    // {
    //     if (_context.Device == null)
    //     {
    //         return NotFound();
    //     }
    //     var device = await _context.Device.FindAsync(id);
    //     if (device == null)
    //     {
    //         return NotFound();
    //     }

    //     _context.Device.Remove(device);
    //     await _context.SaveChangesAsync();

    //     return NoContent();
    // }

    // private bool DeviceExists(Guid id)
    // {
    //     return (_context.Device?.Any(e => e.Id == id)).GetValueOrDefault();
    // }
}