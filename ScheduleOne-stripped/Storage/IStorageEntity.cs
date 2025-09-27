using System.Collections;
using System.Collections.Generic;
using ScheduleOne.Employees;
using ScheduleOne.Tiles;
using UnityEngine;

namespace ScheduleOne.Storage;
public interface IStorageEntity
{
    Transform storedItemContainer { get; }

    Dictionary<StoredItem, Employee> reservedItems { get; }

    List<StoredItem> GetStoredItems();
    List<StorageGrid> GetStorageGrids();
    List<StoredItem> GetStoredItemsByID(string ID);
    void ReserveItem(StoredItem item, Employee employee);
    void DereserveItem(StoredItem item);
    bool IsItemReserved(StoredItem item);
    Employee WhoIsReserving(StoredItem item);
    List<StoredItem> GetNonReservedItemsByPrefabID(string prefabID, Employee whosAskin);
    IEnumerator ClearReserve(StoredItem item);
    bool TryFitItem(int sizeX, int sizeY, out StorageGrid grid, out Coordinate originCoordinate, out float rotation);
    int HowManyCanFit(int sizeX, int sizeY, int limit = int.MaxValue);
}