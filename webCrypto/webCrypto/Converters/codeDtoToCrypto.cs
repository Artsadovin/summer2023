using Web.DTO;
using Domain.Entity;
using System.Runtime.CompilerServices;

namespace webCrypto.Converters
{
    public class codeDtoToCrypto : Crypto
    {
        public static Crypto toCrypto(CryptoDtoCode cryptoDto)
        {
            Crypto crypto = new Crypto();
            crypto.Original = cryptoDto.Original;
            crypto.Key = cryptoDto.Key;
            crypto.codeWord();
            return crypto;
        }
    }
}
