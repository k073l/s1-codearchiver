using System.Linq;
using ScheduleOne.Core;
using UnityEngine;

namespace ScheduleOne.Effects.MixMaps;
public class MixerMapGenerator : MonoBehaviour
{
    public float MapRadius;
    public string MapName;
    public Transform BasePlateMesh;
    public MixMapEffect EffectPrefab;
    private void OnValidate();
    [Button]
    public void CreateEffectPrefabs();
    [Button]
    public MixMapEffect GetEffect(Effect effect);
}