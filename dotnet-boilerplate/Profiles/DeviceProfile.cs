using AutoMapper;
using dotnet_boilerplate.Models;
using dotnet_boilerplate.ViewModels;

namespace dotnet_boilerplate.Profiles;

public class DeviceProfile : Profile
{
    public DeviceProfile()
    {
        CreateMap<IEnumerable<Device>?, IEnumerable<Device>?>();
        CreateMap<CreateDeviceViewModel, Device>();
        CreateMap<Device, DeviceViewModel>();
        CreateMap<DeviceViewModel, Device>();
    }
}