using System.Text;
using System.Text.Json;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.ValueObjects;
using Ambev.DeveloperEvaluation.Integration.Factory;
using FluentAssertions;
using Xunit;

namespace Ambev.DeveloperEvaluation.Integration;

public class UserControllerTests : IClassFixture<ApplicationFactory>
{
    private readonly HttpClient _client;

    public UserControllerTests(ApplicationFactory factory)
    {
        _client = factory.CreateClient();
        
    }
       
    [Fact]
    public async Task CreateUser_ShouldReturn201()
    {
        // Arrange
        var request = new User
        {
            Username = "João Silva",
            Email = "joao@email.com",
            Phone = "(11) 98765-4321",
            Password = "Senha@123",
            Role = UserRole.Admin,
            Status = UserStatus.Active,
            Name = new Name { Firstname = "João", Lastname = "Silva" },
            Address = new Address
            {
                City = "São Paulo",
                Street = "Rua A",
                Number = 123,
                Zipcode = "01234-567",
                Geolocation = new Geolocation { Lat = "-23.5505", Long = "-46.6333" }
            }
        };

        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PostAsync("/api/users", content);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
    }

       
    [Fact]
    public async Task GetUserById_ShouldReturn200_WhenExists()
    {
        // Criar um ID válido para teste
        var userId = Guid.NewGuid();

        // Act
        var response = await _client.GetAsync($"/api/users/{userId}");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

  
    [Fact]
    public async Task GetAllUsers_ShouldReturn200()
    {
        // Act
        var response = await _client.GetAsync("/api/users");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

   
    [Fact]
    public async Task UpdateUser_ShouldReturn200_WhenValid()
    {
       
        var userId = Guid.NewGuid();

        var request = new User
        {
            Username = "João Atualizado",
            Email = "joao.novo@email.com",
            Phone = "(11) 99999-9999",
            Password = "NovaSenha@456",
            Role = UserRole.Manager,
            Status = UserStatus.Inactive
        };

        var content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json");

        // Act
        var response = await _client.PutAsync($"/api/users/{userId}", content);

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }

 
    [Fact]
    public async Task DeleteUser_ShouldReturn200_WhenExists()
    {
       var userId = Guid.NewGuid();

        // Act
        var response = await _client.DeleteAsync($"/api/users/{userId}");

        // Assert
        response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
    }
}