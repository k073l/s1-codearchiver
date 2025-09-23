using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using UnityEngine;

namespace ScheduleOne.Tools;
[Serializable]
public class HDRColorSmoother
{
    [Serializable]
    public class Override
    {
        public Color Value;
        public int Priority;
        public string Label;
    }

    [ColorUsage(true, true)]
    [SerializeField]
    private Color DefaultValue;
    [SerializeField]
    private float SmoothingSpeed;
    [SerializeField]
    private List<Override> overrides;
    private Override activeOverride;
    private int activeCount;
    public Color CurrentValue { get; private set; } = Color.white;
    public float Multiplier { get; private set; } = 1f;

    public void Initialize();
    public void Destroy();
    public void SetDefault(Color value);
    public void SetMultiplier(float value);
    public void AddOverride(Color value, int priority, string label);
    public void RemoveOverride(string label);
    public void Update();
}