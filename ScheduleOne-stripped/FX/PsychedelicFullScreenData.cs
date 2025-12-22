using UnityEngine;

namespace ScheduleOne.FX;
[CreateAssetMenu(fileName = "PsychedelicFullScreenData", menuName = "ScriptableObjects/FX/Psychedelic FullScreen Data", order = 1)]
public class PsychedelicFullScreenData : ScriptableObject
{
    [Header("Properties")]
    public float NoiseScale;
    public float Blend;
    public Vector2 PanSpeed;
    public bool DoesBounce;
    public float Amplitude;
    public PsychedelicFullScreenFeature.MaterialProperties ConvertToMaterialProperties();
}