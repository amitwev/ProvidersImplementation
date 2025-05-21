using Api.Providers;

namespace Api.Models;

public class ValidateGiftCardResponseModel
{
    public required string CustomerId { get; set; }
    public decimal Balance { get; set; }
    public bool IsValid { get; set; }
    public GiftCardProviderTypes ProviderType { get; set; }
}