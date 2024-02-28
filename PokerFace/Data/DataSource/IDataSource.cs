using PokerFace.Models;

namespace PokerFace.Data.DataSource
{
    public interface IDataSource
    {
        IEnumerable<Hand> GetHands();
    }
}
