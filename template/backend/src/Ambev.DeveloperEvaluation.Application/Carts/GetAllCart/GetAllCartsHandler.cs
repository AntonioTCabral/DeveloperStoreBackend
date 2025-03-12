using Ambev.DeveloperEvaluation.Application.DTOs;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetAllCart
{
    /// <summary>
    /// Handler for processing GetAllCartsCommand requests
    /// </summary>
    public class GetAllCartsHandler : IRequestHandler<GetAllCartsCommand, GetAllCartsResult>
    {
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of GetAllCartsHandler
        /// </summary>
        /// <param name="cartRepository">The cart repository</param>
        /// <param name="mapper">The AutoMapper instance</param>
        public GetAllCartsHandler(ICartRepository cartRepository, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Handles the GetAllCartsCommand request
        /// </summary>
        /// <param name="request">The GetAllCartsCommand</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>The paginated list of carts</returns>
        public async Task<GetAllCartsResult> Handle(GetAllCartsCommand request, CancellationToken cancellationToken)
        {
            var carts = await _cartRepository.GetAllAsync(request.Order, cancellationToken);
            var result = new GetAllCartsResult
            {
                Carts = _mapper.Map<List<CartDTO>>(carts)
            };

            return result;
        }
    }
}
