using Api.Models;

namespace Api.Providers;

public class PraxellProvider : IGiftCardProvider
{
    public GiftCardProviderTypes ProviderType { get; } = GiftCardProviderTypes.Praxell;
    
    public Task<ValidateGiftCardResponseModel> GetBalanceAsync(ValidateGiftCardRequestModel request)
    {
        // do request

        return Task.FromResult(new ValidateGiftCardResponseModel
        {
            IsValid = false,
            Balance = 11m,
            CustomerId = request.CustomerId,
            ProviderType = ProviderType,
        });
    }
}