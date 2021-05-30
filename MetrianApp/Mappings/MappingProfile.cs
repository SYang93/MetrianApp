using AutoMapper;
using MetrianApp.DTO;
using MetrianApp.Core.Models;

namespace MetrianApp.Mapping
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      // Domain to DTO
      CreateMap<User, UserDTO>();

      // DTO to Domain
      CreateMap<UserDTO, User>();
    }
  }
}