using MediatR;
using Microsoft.AspNetCore.Mvc;
using PomaPlayer.Crypto.Logic.DtoModels;
using PomaPlayer.Crypto.Web.Features.Commands;
using PomaPlayer.Crypto.Web.Features.Queries;

namespace PomaPlayer.Crypto.Web.Controllers;

[ApiController]
[Produces("application/json")]
[Route("api/crypto")]
public class CryptoController : Controller
{
    private readonly IMediator _mediator;

    public CryptoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    /// <summary>
    /// Генерация открытого ключа для пользователя
    /// </summary>
    /// <param name="command">Dto параметр</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <remarks>Получаем и сохранение сообщение из стороннего api, возвращаем публичный ключ</remarks>
    /// <returns>Открытый ключ для пользователя</returns>
    [HttpPost(nameof(CreatePublicKey), Name = nameof(CreatePublicKey))]
    public async Task<ActionResult<string>> CreatePublicKey(CreatePublicKeyCommand command, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var key = await _mediator.Send(command, cancellationToken);
        return Ok(key);
    }

    /// <summary>
    /// Верификации сообщения
    /// </summary>
    /// <param name="command">Dto параметр</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <returns>True - сообщение валидно</returns>
    [HttpPost(nameof(VerifyMessage), Name = nameof(VerifyMessage))]
    public async Task<ActionResult<bool>> VerifyMessage(VerifyMessageCommand command, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await _mediator.Send(command, cancellationToken);
        return Ok(result);
    }

    /// <summary>
    /// Подписать текст пользователю
    /// </summary>
    /// <param name="query">Dto параметр</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <remarks>По ключу находим полученное сообщение из сторонней api в памяти, подписываем его и возвращаем</remarks>
    /// <returns>Подписанный текст пользователя</returns>
    [HttpPost(nameof(MessageWithCertificate), Name = nameof(MessageWithCertificate))]
    public async Task<ActionResult<CertificateMessageDto>> MessageWithCertificate(GetMessageWithCertificateQuery query, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var message = await _mediator.Send(query, cancellationToken);
        return Ok(message);
    }

    /// <summary>
    /// Подписать сообщение пользователя
    /// </summary>
    /// <param name="command">Dto параметр</param>
    /// <param name="cancellationToken">Токен отмены</param>
    /// <remarks>Берем сообщение пользователя, подписываем его и возвращаем подписанное сообщение</remarks>
    /// <returns>Подписанный текст пользователя</returns>
    [HttpPost(nameof(SingMessage), Name = nameof(SingMessage))]
    public async Task<ActionResult<CertificateMessageDto>> SingMessage(SingMessageCommand command, CancellationToken cancellationToken)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var message = await _mediator.Send(command, cancellationToken);
        return Ok(message);
    }
}
