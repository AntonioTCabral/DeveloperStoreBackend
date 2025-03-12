using Ambev.DeveloperEvaluation.Application.Users.DTOS;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUser;

/// <summary>
/// Response model for GetUser operation
/// </summary>
public class GetUserResult
{
    /// <summary>
    /// The unique identifier of the user
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The user's full name
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// The user's email address
    /// </summary>
    public string Email { get; set; } = string.Empty;

    /// <summary>
    /// The user's phone number
    /// </summary>
    public string Phone { get; set; } = string.Empty;


    /// <summary>
    /// Gets or sets the status of the user.
    /// </summary>
    public string Status
    {
        get => UserStatus.ToString();
        set => UserStatus = Enum.Parse<UserStatus>(value, true);
    }

    /// <summary>
    /// Gets or sets the status of the user.
    /// </summary>
    public UserStatus UserStatus { get; set; }

    /// <summary>
    /// Gets or sets the role as a string.
    /// </summary>
    public string Role
    {
        get => UserRole.ToString();
        set => UserRole = Enum.Parse<UserRole>(value, true);
    }

    /// <summary>
    /// Gets or sets the role of the user.
    /// </summary>
    private UserRole UserRole { get; set; }

    /// <summary>
    /// Gets or sets the name details of the user.
    /// </summary>
    public NameDto Name { get; set; } = new();

    /// <summary>
    /// Gets or sets the address details of the user.
    /// </summary>
    public AddressDto Address { get; set; } = new();
}
