using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Effects;
[CreateAssetMenu(fileName = "EffectSettings", menuName = "ScriptableObjects/Effects/Effect Settings")]
public class EffectSettings : ScriptableObject
{
    [Header("Numeric Parameters")]
    [SerializeField]
    private string _handlerId;
    [SerializeField]
    private List<EffectItem> _effectItems;
    public string Id => _handlerId;
    public List<EffectItem> EffectItems => _effectItems;
}