using System;
using FishNet.Object;
using ScheduleOne.EntityFramework;
using UnityEngine;

namespace ScheduleOne.Tiles;
[Serializable]
public struct CoordinateProceduralTilePair
{
    public Coordinate coord;
    public NetworkObject tileParent;
    public int tileIndex;
    public ProceduralTile tile => ((Component)tileParent).GetComponent<IProceduralTileContainer>().ProceduralTiles[tileIndex];
}