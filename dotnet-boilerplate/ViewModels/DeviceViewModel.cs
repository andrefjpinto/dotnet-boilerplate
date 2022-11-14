namespace dotnet_boilerplate.ViewModels;

public class DeviceViewModel
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public string? Name { get; set; }
    public string? Brand { get; set; }
}