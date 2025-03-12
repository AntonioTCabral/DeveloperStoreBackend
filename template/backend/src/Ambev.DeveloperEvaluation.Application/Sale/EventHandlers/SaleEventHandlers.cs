using Ambev.DeveloperEvaluation.Domain.Events;
using Microsoft.Extensions.Logging;
using Rebus.Handlers;

namespace Ambev.DeveloperEvaluation.Application.Sale.EventHandlers;

public class SaleEventHandlers : IHandleMessages<SaleCreatedEvent>, IHandleMessages<SaleModifiedEvent>, IHandleMessages<SaleCancelledEvent>, IHandleMessages<ItemCancelledEvent>
{


    public async Task Handle(SaleCreatedEvent message)
    {
        Console.WriteLine($"Sale created: ID {message.SaleId}, Total: {message.TotalAmount}");
        await Task.CompletedTask;
    }

    public async Task Handle(SaleModifiedEvent message)
    {
        Console.WriteLine($"Sale modified: ID {message.SaleId} at {message.ModifiedAt}");
        await Task.CompletedTask;
    }

    public async Task Handle(SaleCancelledEvent message)
    {
        Console.WriteLine($"Sale cancelled: ID {message.SaleId} at {message.CancelledAt}");
        await Task.CompletedTask;
    }

    public async Task Handle(ItemCancelledEvent message)
    {
        Console.WriteLine($"Item cancelled: SaleID {message.SaleId}, ProductID {message.ProductId} at {message.CancelledAt}");
        await Task.CompletedTask;
    }
}