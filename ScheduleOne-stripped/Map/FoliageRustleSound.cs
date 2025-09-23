using FishNet.Object;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Map;
public class FoliageRustleSound : MonoBehaviour
{
    public const float ACTIVATION_RANGE_SQUARED;
    public const float COOLDOWN;
    public AudioSourceController Sound;
    public GameObject Container;
    private float timeOnLastHit;
    private void Awake();
    public void OnTriggerEnter(Collider other);
    private void UpdateActive();
}