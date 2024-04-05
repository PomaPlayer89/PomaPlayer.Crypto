using MediatR;
using Microsoft.AspNetCore.Mvc;
using PomaPlayer.Crypto.Logic.DtoModels;
using PomaPlayer.Crypto.Logic.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace PomaPlayer.Crypto.Web.Features.Commands;

/// <summary>
/// Подписать сообщение пользователя
/// </summary>
public sealed class SingMessageCommand : IRequest<CertificateMessageDto>
{
    /// <summary>
    /// Сообщение пользователя
    /// </summary>
    [Required]
    [FromBody]
    public string OriginalMessage { get; set; }
}

public sealed class SingMessageCommandHandler : IRequestHandler<SingMessageCommand, CertificateMessageDto>
{
    private readonly IMemoryRepository _memoryRepository;

    public SingMessageCommandHandler(IMemoryRepository memoryRepository)
    {
        _memoryRepository = memoryRepository;
    }

    public async Task<CertificateMessageDto> Handle(SingMessageCommand request, CancellationToken cancellationToken)
    {
        var certificate = await _memoryRepository.AddKeyWithInstanceAsync(request.OriginalMessage, cancellationToken);
        return certificate;
    }
}
