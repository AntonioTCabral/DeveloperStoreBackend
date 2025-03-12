using Ambev.DeveloperEvaluation.Application.Users.DTOS;
using Ambev.DeveloperEvaluation.Application.Users.UpdateUser;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.Requests;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser
{
    /// <summary>
    /// Profile for mapping between Application and API UpdateUser responses
    /// </summary>
    public class UpdateUserProfile : Profile
    {
        /// <summary>
        /// Initializes the mappings for UpdateUser feature
        /// </summary>
        public UpdateUserProfile()
        {
            CreateMap<NameRequest, NameDto>().ReverseMap();
            CreateMap<AddressRequest, AddressDto>().ReverseMap();
            CreateMap<GeolocationRequest, GeolocationDto>().ReverseMap();
            CreateMap<UpdateUserRequest, UpdateUserCommand>();
            CreateMap<UpdateUserResult, UpdateUserResponse>();
        }
    }
}
