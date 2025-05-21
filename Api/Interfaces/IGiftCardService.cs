using Api.Models;

namespace Api.Interfaces;

public interface IGiftCardService
{
    /// <summary>
    /// Validates that gift card has sufficient balance
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<ValidateGiftCardResponseModel> ValidateGiftCardAsync(ValidateGiftCardRequestModel request);

    /// <summary>
    /// Redeems amount from gift cards
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    Task<RedeemGiftCardResponseModel> RedeemGiftCardAsync(RedeemGiftCardRequestModel request);
}