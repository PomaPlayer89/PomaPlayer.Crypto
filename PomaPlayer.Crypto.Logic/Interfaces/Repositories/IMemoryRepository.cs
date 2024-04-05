using PomaPlayer.Crypto.Logic.DtoModels;

namespace PomaPlayer.Crypto.Logic.Interfaces.Repositories;

public interface IMemoryRepository
{
    int Count { get; }

    Task<string> AddKeyAsync(string text, CancellationToken cancellationToken);

    Task<CertificateMessageDto> AddKeyWithInstanceAsync(string text, CancellationToken cancellationToken);

    CertificateMessageDto GetMessageWithCertificate(string id);
}
