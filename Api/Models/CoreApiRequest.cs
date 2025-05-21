
namespace Api.Models;

public class CoreApiRequest
{
    public required string MerchantGuid { get; set; }
    
    public required string MerchantCartToken { get; set; }
    
    public required string CustomerId { get; set; }
    
    public string? ShippingCountryCode { get; set; }

    public Dictionary<string, string>? CardFields { get; set; }
    
    public string? CustomerEmail { get; set; }
    
    public string? WebStoreCode { get; set; }
    
    public string? WebStoreInstanceCode { get; set; }
    
    public string? CartToken { get; set; }
}