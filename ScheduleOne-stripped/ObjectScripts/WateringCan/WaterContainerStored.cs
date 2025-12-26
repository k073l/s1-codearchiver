using ScheduleOne.ItemFramework;
using ScheduleOne.Storage;
using ScheduleOne.Tools;
using UnityEngine;

namespace ScheduleOne.ObjectScripts.WateringCan;
public class WaterContainerStored : StoredItem
{
    [SerializeField]
    private WaterContainerVisualizer _visuals;
    public override void InitializeStoredItem(StorableItemInstance _item, StorageGrid grid, Vector2 _originCoordinate, float _rotation);
    public override void Destroy();
}