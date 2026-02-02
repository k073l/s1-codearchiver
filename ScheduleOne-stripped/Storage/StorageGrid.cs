using System;
using System.Collections.Generic;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Storage;
public class StorageGrid : MonoBehaviour
{
    public static float gridSize;
    public List<StorageTile> storageTiles;
    [HideInInspector]
    public List<CoordinateStorageTilePair> coordinateStorageTilePairs;
    private int _unoccupiedTileCount;
    private bool _unoccupiedTileCountDirty;
    public int UnoccupiedTileCount { get; }

    private void Awake();
    public void RegisterTile(StorageTile tile);
    public void DeregisterTile(StorageTile tile);
    public Coordinate GetMatchedCoordinate(FootprintTile tileToMatch);
    public StorageTile GetTile(Coordinate coord);
    public int GetUserEndCapacity();
    public int GetActualY();
    public int GetActualX();
    public int GetTotalFootprintSize();
    public bool TryFitItem(int sizeX, int sizeY, List<Coordinate> lockedCoordinates, out Coordinate originCoordinate, out float rotation);
    private int CalculateUnoccupiedTileCount();
    private void TileOccupantChanged();
}