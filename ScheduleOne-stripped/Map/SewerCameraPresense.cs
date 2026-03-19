using Funly.SkyStudio;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Tools;
using UnityEngine;
using UnityEngine.Rendering;

namespace ScheduleOne.Map;
public class SewerCameraPresense : Singleton<SewerCameraPresense>
{
    public Transform FullPresenseVolumesContainer;
    public Transform FadeVolumesContainer;
    public SkyProfileOverride SewerSkyProfileOverride;
    public Volume SewerPPVolume;
    private BoxCollider[] fullPresenceVolumes;
    private FadeVolume[] fadeVolumes;
    public float CameraPresenceInSewerArea { get; private set; }
    public float SmoothedCameraPresenceInSewerArea { get; private set; }

    protected override void Awake();
    private void LateUpdate();
    private void UpdatePresense();
    public bool IsPointInSewerArea(Vector3 point);
}