using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace ScheduleOne.StationFramework;
public class Fillable : MonoBehaviour
{
    public class Content
    {
        public string Label;
        public float Volume_L;
        public Color Color;
    }

    [Header("References")]
    public LiquidContainer LiquidContainer;
    [Header("Settings")]
    public bool FillableEnabled;
    public float LiquidCapacity_L;
    public List<Content> contents { get; protected set; } = new List<Content>();

    private void Awake();
    public void AddLiquid(string label, float volume, Color color);
    public void ResetContents();
    private void UpdateLiquid();
    public float GetLiquidVolume(string label);
    public float GetTotalLiquidVolume();
}