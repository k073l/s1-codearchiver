using System;
using UnityEngine;

namespace ScheduleOne.Levelling;
[Serializable]
public struct FullRank
{
    public const int TIER_COUNT;
    public ERank Rank;
    [Range(1f, 5f)]
    public int Tier;
    public FullRank(ERank rank, int tier);
    public override string ToString();
    public FullRank NextRank();
    public float ToFloat();
    public int GetRankIndex();
    public static string GetString(FullRank rank);
    public static bool operator>(FullRank a, FullRank b)
    {
        if (a.Rank > b.Rank)
        {
            return true;
        }

        if (a.Rank == b.Rank)
        {
            return a.Tier > b.Tier;
        }

        return false;
    }

    public static bool operator <(FullRank a, FullRank b)
    {
        if (a.Rank < b.Rank)
        {
            return true;
        }

        if (a.Rank == b.Rank)
        {
            return a.Tier < b.Tier;
        }

        return false;
    }

    public static bool operator <=(FullRank a, FullRank b)
    {
        if (!(a < b))
        {
            return a == b;
        }

        return true;
    }

    public static bool operator >=(FullRank a, FullRank b)
    {
        if (!(a > b))
        {
            return a == b;
        }

        return true;
    }

    public static bool operator ==(FullRank a, FullRank b)
    {
        if (a.Rank == b.Rank)
        {
            return a.Tier == b.Tier;
        }

        return false;
    }

    public static bool operator !=(FullRank a, FullRank b)
    {
        if (a.Rank == b.Rank)
        {
            return a.Tier != b.Tier;
        }

        return true;
    }

    public override bool Equals(object obj);
    public override int GetHashCode();
    public int CompareTo(FullRank other);
}