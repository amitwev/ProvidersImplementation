using Api.Models;

namespace Api.Providers;

public interface IGiftCardProvider
{
    GiftCardProviderTypes ProviderType { get; }
    
    Task<ValidateGiftCardResponseModel> GetBalanceAsync(ValidateGiftCardRequestModel request);

    // Task<object> RedeemAsync(object request);
}