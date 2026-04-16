using ArrayProcessor.Application.Interfaces;

namespace Application.Registrations;

public sealed class UseCaseResolver : IUseCaseResolver
{
    private readonly Dictionary<string, IUseCase> _useCases;

    public UseCaseResolver(IEnumerable<IUseCase> useCases)
    {
        _useCases = useCases.ToDictionary(p => p.Name, p => p, StringComparer.OrdinalIgnoreCase);
    }

    public IUseCase Resolve(string name)
    {
        if (_useCases.TryGetValue(name, out var useCase))
            return useCase;

        throw new Exception($"Unknown use case '{name}'.");
    }
}