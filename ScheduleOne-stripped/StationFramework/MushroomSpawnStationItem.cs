using UnityEngine;

namespace ScheduleOne.StationFramework;
public class MushroomSpawnStationItem : StationItem
{
    [SerializeField]
    private MeshRenderer[] _renderers;
    [SerializeField]
    private int _materialIndex;
    [SerializeField]
    private GameObject _injectionPortHighlight;
    [field: SerializeField]
    public Collider InjectionPortCollider { get; private set; }

    protected override void Awake();
    public void SetInocculationAmount(float amount);
    public void SetInjectionPortHighlightActive(bool active);
}