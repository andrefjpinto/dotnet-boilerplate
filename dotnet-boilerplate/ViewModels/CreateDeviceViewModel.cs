using System.ComponentModel.DataAnnotations;

namespace dotnet_boilerplate.ViewModels;

public class CreateDeviceViewModel
{
    [Required]
    public string? Name { get; set; }
    [Required]
    public string? Brand { get; set; }
}