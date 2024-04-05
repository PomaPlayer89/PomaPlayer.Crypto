using MediatR;
using Microsoft.AspNetCore.Mvc;
using PomaPlayer.Crypto.Logic.DtoModels;
using PomaPlayer.Crypto.Logic.Interfaces.Repositories;
using System.ComponentModel.DataAnnotations;

namespace PomaPlayer.Crypto.Web.Features.Queries;

/// <summary>
/// Подписать текст пользователю
/// </summary>
public sealed class GetMessageWithCertificateQuery : IRequest<CertificateMessageDto>
{
    /// <summary>
    /// Публичный ключ
    /// </summary>
    [Required]
    [FromBody]
    public string Key { get; set; }
}

public sealed class GetMessageWithCertificateQueryHandler : IRequestHandler<GetMessageWithCertificateQuery, CertificateMessageDto>
{
    private readonly IMemoryRepository _memoryRepository;

    public GetMessageWithCertificateQueryHandler(IMemoryRepository memoryRepository)
    {
        _memoryRepository = memoryRepository;
    }

    public Task<CertificateMessageDto> Handle(GetMessageWithCertificateQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_memoryRepository.GetMessageWithCertificate(request.Key));
    }
}
