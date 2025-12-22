using ScheduleOne.Audio;
using UnityEngine;

namespace ScheduleOne.Tools;
public class FillableWaterContainer : MonoBehaviour
{
    [Range(0f, 1f)]
    public float MaxTapOpenValue;
    public WaterContainerVisualizer Visuals;
    public AudioSourceController FillSound;
}