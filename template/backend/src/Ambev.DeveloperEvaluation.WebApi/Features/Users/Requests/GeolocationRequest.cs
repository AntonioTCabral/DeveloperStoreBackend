namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.Requests
{
    /// <summary>
    /// Represents the geolocation details of an address.
    /// </summary>
    public class GeolocationRequest
    {
        public string Lat { get; set; } = string.Empty;
        public string Long { get; set; } = string.Empty;
    }
}
