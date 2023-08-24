using Microsoft.AspNetCore.Mvc;
using Domain;
using Domain.Repositories;
using Domain.Entity;
using Web.DTO;

namespace webCrypto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CryptoController : ControllerBase
    {
        private readonly ICryptoRepository _cryptoRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CryptoController(ICryptoRepository cryptoRepository, IUnitOfWork unitOfWork)
        {
            _cryptoRepository = cryptoRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet(Name = "GetCrypto")]
        public IEnumerable<Crypto> Get()
        {
            return _cryptoRepository.GetCryptos();
        }

        [HttpPost("GetCrypto")]
        public String Get(CryptoDtoGet cryptoDto)
        {
            return _cryptoRepository.GetCryptos().FirstOrDefault(x => x.Id == cryptoDto.Id).Original;
        }

        [HttpPost(Name = "SaveCryptos")]                                                                                                          
        public IActionResult SaveCrypto(CryptoDtoPost cryptoDto)
        {
            Crypto crypto = new Crypto();
            crypto.Original = cryptoDto.Original;
            crypto.Key = cryptoDto.Key;
            crypto.codeWord();
            _cryptoRepository.AddCrypto(crypto);
            _unitOfWork.Commit();

            return new OkResult();
        }
    }
}