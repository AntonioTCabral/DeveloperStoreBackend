using Ambev.DeveloperEvaluation.Application.Users.DTOS;
using Ambev.DeveloperEvaluation.Domain.Enums;

namespace Ambev.DeveloperEvaluation.Application.Users.UpdateUser;

/// <summary>
/// Represents the response returned after successfully updating a user.
/// </summary>
public class UpdateUserResult
{
    /// <summary>
    /// Gets or sets the unique identifier of the newly created user.
    /// </summary>
    /// <value>A GUID that uniquely identifies the created user in the system.</value>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the username of the user to be created.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the password for the user.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the phone number for the user.
    /// </summary>
    public string Phone { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the email address for the user.
    /// </summary>
    public string Email { get; set; } = string.Empty;

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