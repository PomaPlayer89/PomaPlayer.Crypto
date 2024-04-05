using System.ComponentModel.DataAnnotations;

namespace PomaPlayer.Crypto.Web.Features.DtoModels;

/// <summary>
/// Сообщение для верификации
/// </summary>
public sealed class VerifyMessageDto
{
    /// <summary>
    /// Открытый ключ
    /// </summary>
    [Required]
    public string PublicKey { get; set; }

    /// <summary>
    /// Сообщение
    /// </summary>
    [Required]
    public string OriginalMessage { get; set; }

    /// <summary>
    /// Подпись к сообщению
    /// </summary>
    [Required]
    public string SignedMessage { get; set; }
}
