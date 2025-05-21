using Api.Models;

namespace Api.Providers;

public class HaperNumberOneProvider : IGiftCardProvider
{
    public GiftCardProviderTypes ProviderType { get; } = GiftCardProviderTypes.HaperNumberOne;
    public Task<ValidateGiftCardResponseModel> GetBalanceAsync(ValidateGiftCardRequestModel request)
    {
        return Task.FromResult<ValidateGiftCardResponseModel>(new ValidateGiftCardResponseModel
        {
            CustomerId = request.CustomerId,
            IsValid = true,
            Balance = 22,
            ProviderType = ProviderType
        });
    }
}