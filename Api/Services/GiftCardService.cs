using Api.Interfaces;
using Api.Models;
using Api.Providers;

namespace Api.Services;

public class GiftCardService(IProviderManager providerManager) : IGiftCardService
{
    public async Task<ValidateGiftCardResponseModel> ValidateGiftCardAsync(ValidateGiftCardRequestModel request)
    {
        // Get Random provider 
        var values = Enum.GetValues<GiftCardProviderTypes>();
        var random = new Random();
        var randomProviderType = values[random.Next(values.Length)];
        
        // get provider by guid
        var provider = providerManager.GetProvider(randomProviderType);
        
        // get balance by provider
        var res = await provider.GetBalanceAsync(request);
        return res;
    }

    public Task<RedeemGiftCardResponseModel> RedeemGiftCardAsync(RedeemGiftCardRequestModel request)
    {
        throw new NotImplementedException();
    }
}