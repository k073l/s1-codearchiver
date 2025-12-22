using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Building;
public class TileIntersection
{
    public FootprintTile footprint;
    public Tile tile;
    public static bool operator ==(TileIntersection a, TileIntersection b)
    {
        if ((object)a == b)
        {
            return true;
        }

        if ((object)a == null || (object)b == null)
        {
            return false;
        }

        if ((Object)(object)a.footprint == (Object)(object)b.footprint)
        {
            return (Object)(object)a.tile == (Object)(object)b.tile;
        }

        return false;
    }

    public static bool operator !=(TileIntersection a, TileIntersection b)
    {
        return !(a == b);
    }
}