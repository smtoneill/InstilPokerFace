using PokerFace.Models;

namespace PokerFace.Data.Parser;

public interface IParser
{
    Hand Parse(string record);
}
