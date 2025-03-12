using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Events;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;
using Rebus.Bus;
using KeyNotFoundException = System.Collections.Generic.KeyNotFoundException;

namespace Ambev.DeveloperEvaluation.Application.Sale.UpdateSale;

public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;
    private readonly IMapper _mapper;
    private readonly IBus _bus;


    public UpdateSaleHandler(ISaleRepository saleRepository, IMapper mapper, IBus bus)
    {
        _saleRepository = saleRepository;
        _mapper = mapper;
        _bus = bus;
    }

    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetWithIncludeAsync(request.Id, cancellationToken);
        
        if (sale == null)
            throw new KeyNotFoundException($"Sale with ID {request.Id} not found");
        
        bool wasCancelled = sale.IsCancelled;
        bool isNowCancelled = request.IsCancelled;
        
        _mapper.Map(request, sale);
        
        sale.SaleItems.Clear();
        sale.SaleItems = _mapper.Map<List<SaleItem>>(request.SaleItems);
        
        await _saleRepository.UpdateAsync(sale, cancellationToken);
        
        await _bus.SendLocal(new SaleModifiedEvent
        {
            SaleId = sale.Id,
            ModifiedAt = DateTime.UtcNow
        });
        
        if (!wasCancelled && isNowCancelled)
        {
            await _bus.SendLocal(new SaleCancelledEvent
            {
                SaleId = sale.Id,
                CancelledAt = DateTime.UtcNow
            });
        }
        
        var teste = _mapper.Map<UpdateSaleResult>(sale);
        
        return _mapper.Map<UpdateSaleResult>(sale);
    }
}