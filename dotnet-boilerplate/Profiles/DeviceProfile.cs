using AutoMapper;
using dotnet_boilerplate.Models;
using dotnet_boilerplate.ViewModels;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;

namespace dotnet_boilerplate.Profiles;

public class DeviceProfile : Profile
{
    public DeviceProfile()
    {
        CreateMap<IEnumerable<Device>?, IEnumerable<Device>?>();
        CreateMap<CreateDeviceViewModel, Device>();
        CreateMap<Device, DeviceViewModel>();
        CreateMap<DeviceViewModel, Device>();
        CreateMap<JsonPatchDocument<UpdateDeviceViewModel>, JsonPatchDocument<Device>>();
        CreateMap<Operation<UpdateDeviceViewModel>, Operation<Device>>();

    }
}