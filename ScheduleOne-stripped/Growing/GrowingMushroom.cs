using EasyButtons;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Growing;
public class GrowingMushroom : MonoBehaviour
{
    private const float CapExpansionThreshold;
    [HideInInspector]
    public float LateralScaleMultiplier;
    [HideInInspector]
    public float VerticalScaleMultiplier;
    [HideInInspector]
    public float MaxCapExpansion;
    [SerializeField]
    private Transform _modelContainer;
    [SerializeField]
    private SkinnedMeshRenderer[] _meshRenderers;
    [SerializeField]
    private AudioSourceController _harvestSound;
    private ShroomColony _parentColony;
    private int _alignmentIndex;
    private void Awake();
    public void Initialize(ShroomColony parentColony, int alignmentIndex);
    public void SetGrowthPercent(float percent);
    [Button]
    public void Harvest();
}