using Funly.SkyStudio;
using UnityEngine;

namespace ScheduleOne.Weather;
public class SkyProfileFrame
{
    public Color AmbientLightSkyColor;
    public Color AmbientLightEquatorColor;
    public Color AmbientLightGroundColor;
    public Color SkyUpperColor;
    public Color SkyMiddleColor;
    public Color SkyLowerColor;
    public float SkyMiddleColorPosition;
    public float HorizonTrasitionStart;
    public float HorizonTransitionLength;
    public float StarTransitionStart;
    public float StarTransitionLength;
    public float HorizonStarScale;
    public SkyProfileFrame(SkyProfile skyProfile, float timeOfDay);
}