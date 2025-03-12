namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.Requests
{
    /// <summary>
    /// Represents the name details of the user.
    /// </summary>
    public class NameRequest
    {
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
    }
}
