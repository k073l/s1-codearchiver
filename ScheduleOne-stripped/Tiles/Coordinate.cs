using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Tiles;
[Serializable]
public class Coordinate
{
    public int x;
    public int y;
    public static implicit operator Vector2(Coordinate c)
    {
        //IL_000e: Unknown result type (might be due to invalid IL or missing references)
        return new Vector2((float)c.x, (float)c.y);
    }

    public Coordinate();
    public Coordinate(int _x, int _y);
    public Coordinate(Vector2 vector);
    public override int GetHashCode();
    public override bool Equals(object obj);
    public static Coordinate operator +(Coordinate a, Coordinate b)
    {
        return new Coordinate(a.x + b.x, a.y + b.y);
    }

    public static Coordinate operator -(Coordinate a, Coordinate b)
    {
        return new Coordinate(a.x - b.x, a.y - b.y);
    }

    private int CantorPair(int x, int y);
    private int SignedCantorPair(int x, int y);
    public override string ToString();
    public static List<CoordinatePair> BuildCoordinateMatches(Coordinate originCoord, int sizeX, int sizeY, float rot);
    public static Coordinate RotateCoordinates(Coordinate coord, float angle);
    private static int MathMod(int a, int b);
}