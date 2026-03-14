using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.DevUtilities;
[Serializable]
public struct DisplaySettings
{
    public enum EDisplayMode
    {
        Windowed,
        FullscreenWindow,
        ExclusiveFullscreen
    }

    public int ResolutionIndex;
    public EDisplayMode DisplayMode;
    public bool VSync;
    public int TargetFPS;
    public float UIScale;
    public float CameraBobbing;
    public int ActiveDisplayIndex;
    public Settings.EUnitType UnitType;
    public static List<Resolution> GetResolutions();
    private static uint GetDenominatorSafe(RefreshRate refreshRate);
}