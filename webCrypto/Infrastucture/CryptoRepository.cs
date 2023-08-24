using Domain.Entity;
using Domain.Repositories;


namespace Infrastucture;
internal class CryptoRepository: ICryptoRepository
{
    private readonly ApplicationContext _context;

    public CryptoRepository( ApplicationContext context )
    {
        _context = context;
    }

    public void AddCrypto(Crypto crypto)
    {
        _context.Cryptos.Add(crypto);
    }

    public List<Crypto> GetCryptos()
    {
        return _context.Cryptos.ToList();
    }
}
