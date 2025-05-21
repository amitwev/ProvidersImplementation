# Gift Card Provider Implementation

This document explains the design and implementation of the gift card provider system.

## Core Components

### 1. `IGiftCardProvider` Interface

This is the central interface that all gift card providers must implement. It defines the contract for interacting with different gift card services.

```csharp
public interface IGiftCardProvider
{
    GiftCardProviderTypes ProviderType { get; }
    Task<ValidateGiftCardResponseModel> GetBalanceAsync(ValidateGiftCardRequestModel request);
    // Task<object> RedeemAsync(object request); // Example of other potential methods
}
```

-   `ProviderType`: A property of type `GiftCardProviderTypes` (enum) that uniquely identifies the provider.
-   `GetBalanceAsync`: An asynchronous method that takes a `ValidateGiftCardRequestModel` and returns a `Task<ValidateGiftCardResponseModel>`. This method is responsible for fetching the balance of a gift card from the specific provider.

### 2. `GiftCardProviderTypes` Enum

This enumeration defines the types of gift card providers available in the system.

```csharp
public enum GiftCardProviderTypes
{
    Praxell,
    Another,
    HaperNumberOne
}
```

When adding a new provider, a new value should be added to this enum.

### 3. `IProviderManager` Interface and `ProviderManager` Class

The `IProviderManager` interface defines a contract for a service that can retrieve a specific provider.

```csharp
public interface IProviderManager
{
    IGiftCardProvider GetProvider(GiftCardProviderTypes type);
}
```

The `ProviderManager` class is the concrete implementation of `IProviderManager`. It is responsible for managing and providing instances of `IGiftCardProvider`.

```csharp
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
```

-   The `ProviderManager` is injected with a collection of all registered `IGiftCardProvider` instances by the dependency injection container.
-   It stores these providers in a dictionary, keyed by their `ProviderType`.
-   The `GetProvider` method allows retrieval of a specific provider based on its `GiftCardProviderTypes` enum value.

## Existing Providers

The system currently includes the following provider implementations:

-   **`PraxellProvider.cs`**: Implements `IGiftCardProvider` for "Praxell" gift cards.
    -   `ProviderType`: `GiftCardProviderTypes.Praxell`
-   **`HaperNumberOneProvider.cs`**: Implements `IGiftCardProvider` for "HaperNumberOne" gift cards.
    -   `ProviderType`: `GiftCardProviderTypes.HaperNumberOne`
-   **`AnotherProvider.cs`**: Implements `IGiftCardProvider` for "Another" type of gift cards.
    -   `ProviderType`: `GiftCardProviderTypes.Another`

Each of these classes provides a concrete implementation for the `GetBalanceAsync` method, tailored to the specific requirements of that provider.

## How to Add a New Provider

To add a new gift card provider:

1.  **Add to `GiftCardProviderTypes` Enum**:
    Open `GiftCardProviderTypes.cs` and add a new member for your provider. For example:
    ```csharp
    public enum GiftCardProviderTypes
    {
        Praxell,
        Another,
        HaperNumberOne,
        NewProviderName // Add your new provider type here
    }
    ```

2.  **Create the Provider Class**:
    Create a new C# class in the `Providers` directory (e.g., `NewProviderNameProvider.cs`).
    This class must implement the `IGiftCardProvider` interface.

    ```csharp
    // File: NewProviderNameProvider.cs
    using Api.Models;

    namespace Api.Providers;

    public class NewProviderNameProvider : IGiftCardProvider
    {
        public GiftCardProviderTypes ProviderType { get; } = GiftCardProviderTypes.NewProviderName;

        public Task<ValidateGiftCardResponseModel> GetBalanceAsync(ValidateGiftCardRequestModel request)
        {
            // Implement the logic to get the balance from the new provider's API or service
            // For example:
            // var balance = // ... call to external service ...
            // return Task.FromResult(new ValidateGiftCardResponseModel
            // {
            //     IsValid = true, // or false based on validation
            //     Balance = balance,
            //     CustomerId = request.CustomerId,
            //     ProviderType = ProviderType,
            // });
            throw new NotImplementedException(); // Replace with actual implementation
        }

        // Implement other methods from IGiftCardProvider if any (e.g., RedeemAsync)
    }
    ```

3.  **Register the Provider for Dependency Injection**:
    In your `Program.cs` or wherever you configure your services (e.g., using the built-in .NET Core dependency injection), you need to register your new provider. This ensures that the `ProviderManager` can discover and use it.

    Typically, this involves adding a line like:
    ```csharp
    // In Program.cs or a service registration extension method
    builder.Services.AddScoped<IGiftCardProvider, NewProviderNameProvider>();
    ```
    This assumes you are registering all `IGiftCardProvider` implementations, and the `ProviderManager` receives an `IEnumerable<IGiftCardProvider>`. If you have a different registration pattern, adjust accordingly. The `ProviderManager` itself should also be registered:
    ```csharp
    builder.Services.AddScoped<IProviderManager, ProviderManager>();
    ```

After these steps, the `ProviderManager` will be able to resolve and use your new provider when requested by its `GiftCardProviderTypes` value.

