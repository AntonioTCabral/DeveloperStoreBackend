using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;

public class UpdateSaleProfile : Profile
{
    public UpdateSaleProfile()
    {
        CreateMap<Domain.Entities.Sale, UpdateSaleResult>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.SaleDate, opt => opt.MapFrom(src => src.SaleDate))
            .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
            .ForMember(dest => dest.TotalAmount, opt => opt.MapFrom(src => src.TotalAmount))
            .ForMember(dest => dest.BranchId, opt => opt.MapFrom(src => src.BranchId))
            .ForMember(dest => dest.IsCancelled, opt => opt.MapFrom(src => src.IsCancelled))
            .ForMember(dest => dest.SaleItems, opt => opt.MapFrom(src => src.SaleItems)).ReverseMap();
        
        CreateMap<UpdateSaleCommand, Domain.Entities.Sale>();
    }
}