using PokerFace.Models;

namespace PokerFace.Formatters;

public interface IStringFormatter
{
    public string Format(Hand value);
}
