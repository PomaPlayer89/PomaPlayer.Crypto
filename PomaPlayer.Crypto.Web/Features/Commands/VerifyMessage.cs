using MediatR;
using Microsoft.AspNetCore.Mvc;
using PomaPlayer.Crypto.Logic.Interfaces.Services;
using PomaPlayer.Crypto.Web.Features.DtoModels;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace PomaPlayer.Crypto.Web.Features.Commands;

/// <summary>
/// Верификации сообщения
/// </summary>
public sealed class VerifyMessageCommand : IRequest<bool>
{
    /// <summary>
    /// Сообщение
    /// </summary>
    [Required]
    [FromBody]
    public VerifyMessageDto VerifyMessage { get; set; }
}

public sealed class VerifyMessageCommandHandler : IRequestHandler<VerifyMessageCommand, bool>
{
    private readonly IRSACryptoService _cryptoService;
    private readonly ILogger<VerifyMessageCommandHandler> _logger;

    public VerifyMessageCommandHandler(
        IRSACryptoService cryptoService,
        ILogger<VerifyMessageCommandHandler> logger)
    {
        _logger = logger;
        _cryptoService = cryptoService;
    }

    public async Task<bool> Handle(VerifyMessageCommand request, CancellationToken cancellationToken)
    {
        return await Task.Run(() =>
        {
            bool success = false;
            var encoder = new UTF8Encoding();

            var byteContent = encoder.GetBytes(request.VerifyMessage.OriginalMessage);
            var publicKey = _cryptoService.GetPublicKey(request.VerifyMessage.PublicKey);
            var byteSignedContent = Convert.FromBase64String(request.VerifyMessage.SignedMessage);

            using (var provider = new RSACryptoServiceProvider())
            {
                try
                {
                    provider.ImportParameters(publicKey);
                    success = provider.VerifyData(byteContent, CryptoConfig.MapNameToOID("SHA256"), byteSignedContent);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
            }

            return success;

        }, cancellationToken);
    }
}
