using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sale.GetSale;

public class GetSaleProfile : Profile
{
    
    public GetSaleProfile()
    {
        CreateMap<Domain.Entities.Sale, GetSaleResult>()
            .ForMember(x => x.Items, opt => opt.MapFrom(x => x.SaleItems))
            .ForMember(x => x.BranchName, opt => opt.MapFrom(x => x.Branch.Name))
            .ForMember(x => x.CustomerName, opt => opt.MapFrom(x => x.Customer.Name));

    }
    
}