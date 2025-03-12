using System.Net;
using System.Net.Http.Json;
using Ambev.DeveloperEvaluation.Integration.Factory;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.CreateSale;
using Ambev.DeveloperEvaluation.WebApi.Features.Sale.GetSale;
using FluentAssertions;
using FluentValidation.Results;
using Xunit;

namespace Ambev.DeveloperEvaluation.Integration;

public class SaleControllerTests : IClassFixture<ApplicationFactory>
{
    private readonly HttpClient _client;

    public SaleControllerTests(HttpClient client)
    {
        _client = client;
    }
    
    [Fact]
    public async Task CreateSale_ShouldReturn_Created_WhenRequestIsValid()
    {
        // Arrange
        var request = new CreateSaleRequest
        {
            CustomerId = Guid.NewGuid(),
            CartId = Guid.NewGuid(),
            BranchId = Guid.NewGuid(),
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/sales", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Created);

        
        var apiResponse = await response.Content.ReadFromJsonAsync<ApiResponseWithData<CreateSaleResponse>>();
        apiResponse.Should().NotBeNull();
        apiResponse!.Success.Should().BeTrue();
        apiResponse.Data.Should().NotBeNull();

        
        apiResponse.Data.Id.Should().NotBe(Guid.Empty);
        apiResponse.Data.CustomerId.Should().Be(request.CustomerId);
        apiResponse.Data.Branch.Should().NotBeNullOrEmpty();
    }
    
    [Fact]
    public async Task CreateSale_ShouldReturn_BadRequest_WhenRequestIsInvalid()
    {
        // Arrange
        var request = new CreateSaleRequest
        {
            CustomerId = Guid.Empty,
            CartId = Guid.Empty,
            BranchId = Guid.Empty,
        };

        // Act
        var response = await _client.PostAsJsonAsync("/api/sales", request);

        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
    
      
        var errors = await response.Content.ReadFromJsonAsync<List<ValidationFailure>>();
        errors.Should().NotBeEmpty();
    }
    
    [Fact]
    public async Task GetSale_ShouldReturn_Ok_WhenSaleExists()
    {
        
        var createRequest = new CreateSaleRequest
        {
            CustomerId = Guid.NewGuid(),
            CartId = Guid.NewGuid(),
            BranchId = Guid.NewGuid(),
        };
        var createResponse = await _client.PostAsJsonAsync("/api/sales", createRequest);
        createResponse.EnsureSuccessStatusCode();
        var createdApiResponse = await createResponse.Content.ReadFromJsonAsync<ApiResponseWithData<CreateSaleResponse>>();
    
        var saleId = createdApiResponse!.Data.Id;

        // 2) Agora chamar GET /api/sales/{id}
        var getResponse = await _client.GetAsync($"/api/sales/{saleId}");
        getResponse.StatusCode.Should().Be(HttpStatusCode.OK);

        var getApiResponse = await getResponse.Content.ReadFromJsonAsync<ApiResponseWithData<GetSaleResponse>>();
        getApiResponse.Should().NotBeNull();
        getApiResponse!.Data.Should().NotBeNull();
        getApiResponse.Data.Id.Should().Be(saleId);
    }
}