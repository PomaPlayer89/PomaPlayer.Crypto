using MediatR;
using PomaPlayer.Crypto.Logic.Interfaces.Repositories;
using PomaPlayer.Crypto.Logic.Interfaces.Services;

namespace PomaPlayer.Crypto.Web.Features.Commands;

/// <summary>
/// Генерация открытого ключа для пользователя
/// </summary>
public sealed class CreatePublicKeyCommand : IRequest<string>
{

}

public sealed class CreatePublicKeyCommandHandler : IRequestHandler<CreatePublicKeyCommand, string>
{
    private readonly IMemoryRepository _memoryRepository;
    private readonly IGenerateTestDataService _textGenerator;

    public CreatePublicKeyCommandHandler(
        IMemoryRepository memoryRepository,
        IGenerateTestDataService textGenerator)
    {
        _memoryRepository = memoryRepository;
        _textGenerator = textGenerator;
    }

    public async Task<string> Handle(CreatePublicKeyCommand request, CancellationToken cancellationToken)
    {
        var text = await _textGenerator.GetRandomShipAsync(cancellationToken);
        return await _memoryRepository.AddKeyAsync(text, cancellationToken);
    }
}
