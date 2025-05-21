using Api.Models;

namespace Api.Mappers;

public static class CoreApiMappers
{
    public static ValidateGiftCardRequestModel ToValidateGiftCardRequestModel(this CoreApiRequest request)
    {
        return new ValidateGiftCardRequestModel
        {
            Guid = request.MerchantGuid,
            CustomerId = request.CustomerId,
            CartTokenMerchant = request.MerchantCartToken
        };
    }
}