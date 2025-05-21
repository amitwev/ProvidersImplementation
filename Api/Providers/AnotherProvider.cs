using Api.Models;

namespace Api.Providers;

public class AnotherProvider : IGiftCardProvider
{
    public GiftCardProviderTypes ProviderType { get; } = GiftCardProviderTypes.Another;
    public Task<ValidateGiftCardResponseModel> GetBalanceAsync(ValidateGiftCardRequestModel request)
    {
        return Task.FromResult<ValidateGiftCardResponseModel>(new ValidateGiftCardResponseModel
        {
            CustomerId = request.CustomerId,
            IsValid = true,
            Balance = 33,
            ProviderType = ProviderType
        });
    }
}