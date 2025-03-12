using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Users.CreateUser;
using Ambev.DeveloperEvaluation.Application.Users.DTOS;
using Ambev.DeveloperEvaluation.WebApi.Features.Users.Requests;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.CreateUser;

/// <summary>
/// Profile for mapping between Application and API CreateUser responses
/// </summary>
public class CreateUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for CreateUser feature
    /// </summary>
    public CreateUserProfile()
    {
        CreateMap<NameRequest, NameDto>().ReverseMap();
        CreateMap<AddressRequest, AddressDto>().ReverseMap();
        CreateMap<GeolocationRequest, GeolocationDto>().ReverseMap();
        CreateMap<CreateUserRequest, CreateUserCommand>();
        CreateMap<CreateUserResult, CreateUserResponse>();
    }
}
