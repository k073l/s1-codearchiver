using System.Collections;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Lighting;
public class PoliceLight : MonoBehaviour
{
    public bool IsOn;
    [Header("References")]
    public MeshRenderer[] RedMeshes;
    public MeshRenderer[] BlueMeshes;
    public OptimizedLight[] RedLights;
    public OptimizedLight[] BlueLights;
    public AudioSourceController Siren;
    [Header("Settings")]
    public float CycleDuration;
    public Material RedOffMat;
    public Material RedOnMat;
    public Material BlueOffMat;
    public Material BlueOnMat;
    public AnimationCurve RedBrightnessCurve;
    public AnimationCurve BlueBrightnessCurve;
    public float LightBrightness;
    private Coroutine cycleRoutine;
    public void SetIsOn(bool isOn);
    private void FixedUpdate();
    protected IEnumerator CycleCoroutine();
}