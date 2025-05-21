namespace Api.Models;

public class ValidateGiftCardRequestModel
{
    public required string Guid { get; set; }
    
    public required string CartTokenMerchant { get; set; }
    
    public required string CustomerId { get; set; }
}