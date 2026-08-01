using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne;
public class UIContentPanel : UIPanel
{
    [Serializable]
    public class NavigationSettings
    {
        public float NavigationThreshold;
        public float DirectionWeight;
        public float DistanceWeight;
        public float DirectionMatchThreshold;
    }

    public enum EContentPanelType
    {
        Grid,
        Vertical,
        Horizontal
    }

    [SerializeField]
    [Tooltip("Default is ImmediateDirection. ImmediatelyDirection is suitable if selectables are placed in grid format. NearestDirectionAndDistance is suitable for non-grid format")]
    private UINavigationType uiPanelNavigationType;
    [SerializeField]
    [Tooltip("Used to determine navigation direction.")]
    private EContentPanelType contentPanelType;
    public NavigationSettings navigationSettings;
    protected override void DetectInput();
    protected override bool Navigate(Vector2 navDir);
    private bool NavigateToSelectable(UISelectable target);
}