using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Effects;
[Serializable]
public class EffectState
{
    [Header("Controller Settings")]
    public EffectController controller;
    [Header("Effect Settings")]
    public List<EffectSettings> ActiveSettings;
    [Header("Audio Settings")]
    public List<AudioSettings> AudioSettings;
}