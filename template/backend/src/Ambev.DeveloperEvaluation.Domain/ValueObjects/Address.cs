namespace Ambev.DeveloperEvaluation.Domain.ValueObjects;

public class Address
{
    public string City { get; set; }
    public string Street { get; set; }
    public int Number { get; set; }
    public string Zipcode { get; set; }
    public Geolocation Geolocation { get; set; }
}