using Api.Interfaces;

namespace Api.Providers;

public class ProviderManager : IProviderManager
{
    private readonly Dictionary<GiftCardProviderTypes, IGiftCardProvider> _providers;

    public ProviderManager(IEnumerable<IGiftCardProvider> providers)
    {
        _providers = providers.ToDictionary(p => p.ProviderType, p => p);
    }
    
    public IGiftCardProvider GetProvider(GiftCardProviderTypes type)
    {
        if (_providers.TryGetValue(type, out var provider))
        {
            return provider;   
        }

        throw new ArgumentException($"Unknown provider: {type}");
    }
}

