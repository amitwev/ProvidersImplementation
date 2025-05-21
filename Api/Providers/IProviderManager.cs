namespace Api.Providers;

public interface IProviderManager
{
    IGiftCardProvider GetProvider(GiftCardProviderTypes type);
}