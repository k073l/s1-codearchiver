using System.Collections.Generic;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Storage;
public class StorageGrid : MonoBehaviour
{
    public static float gridSize;
    public List<StorageTile> storageTiles;
    public List<StorageTile> freeTiles;
    public List<CoordinateStorageTilePair> coordinateStorageTilePairs;
    protected Dictionary<Coordinate, StorageTile> coordinateToTile;
    protected virtual void Awake();
    private void ProcessCoordinateTilePairs();
    public void RegisterTile(StorageTile tile);
    public void DeregisterTile(StorageTile tile);
    public bool IsItemPositionValid(StorageTile primaryTile, FootprintTile primaryFootprintTile, StoredItem item);
    public Coordinate GetMatchedCoordinate(FootprintTile tileToMatch);
    public bool IsGridPositionValid(Coordinate gridCoord, FootprintTile tile);
    public StorageTile GetTile(Coordinate coord);
    public int GetUserEndCapacity();
    public int GetActualY();
    public int GetActualX();
    public int GetTotalFootprintSize();
    public bool TryFitItem(int sizeX, int sizeY, List<Coordinate> lockedCoordinates, out Coordinate originCoordinate, out float rotation);
}