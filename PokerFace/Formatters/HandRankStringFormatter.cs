using PokerFace.Models;

namespace PokerFace.Formatters;

public static class HandRankStringFormatter
{
    public const string Unknown = "Unknown";
    public const string HighCard = "High card";
    public const string OnePair = "One pair";
    public const string TwoPair = "Two pair";
    public const string ThreeOfAKind = "Three of a kind";
    public const string Straight = "Straight";
    public const string Flush = "Flush";
    public const string FullHouse = "Full house";
    public const string FourOfAKind = "Four of a kind";
    public const string StraightFlush = "Straight flush";
    public const string RoyalFlush = "Royal flush";

    public static string Format(HandRank rank) => rank switch
    {
        HandRank.HighCard => HighCard,
        HandRank.OnePair => OnePair,
        HandRank.TwoPair => TwoPair,
        HandRank.ThreeOfAKind => ThreeOfAKind,
        HandRank.Straight => Straight,
        HandRank.Flush => Flush,
        HandRank.FullHouse => FullHouse,
        HandRank.FourOfAKind => FourOfAKind,
        HandRank.StraightFlush => StraightFlush,
        HandRank.RoyalFlush => RoyalFlush,
        _ => Unknown
    };
}
