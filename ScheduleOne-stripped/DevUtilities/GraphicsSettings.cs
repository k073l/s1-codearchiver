using System;

namespace ScheduleOne.DevUtilities;
[Serializable]
public class GraphicsSettings
{
    public enum EAntiAliasingMode
    {
        Off,
        FXAA,
        SMAA
    }

    public enum EGraphicsQuality
    {
        Low,
        Medium,
        High,
        Ultra
    }

    public EGraphicsQuality GraphicsQuality;
    public EAntiAliasingMode AntiAliasingMode;
    public float FOV;
    public bool SSAO;
    public bool GodRays;
}