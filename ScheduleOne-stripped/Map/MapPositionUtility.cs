using EasyButtons;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Map;
public class MapPositionUtility : Singleton<MapPositionUtility>
{
    public Transform OriginPoint;
    public Transform EdgePoint;
    public float MapDimensions;
    private float conversionFactor { get; set; }

    protected override void Awake();
    public Vector2 GetMapPosition(Vector3 worldPosition);
    [Button]
    public void Recalculate();
}