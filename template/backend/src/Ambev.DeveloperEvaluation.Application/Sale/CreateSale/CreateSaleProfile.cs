using Ambev.DeveloperEvaluation.Domain.Entities;
using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Sale.CreateSale;

public class CreateSaleProfile : Profile
{
    public CreateSaleProfile()
    {
        CreateMap<CreateSaleCommand, Domain.Entities.Sale>();
        CreateMap<SaleItem, Domain.ValueObjects.SaleItemValueObject>().ReverseMap();
        CreateMap<Domain.Entities.Sale, CreateSaleResult>();
    }
}