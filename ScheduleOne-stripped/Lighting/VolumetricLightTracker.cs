using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Serialization;
using VLB;

namespace ScheduleOne.Lighting;
[ExecuteInEditMode]
[RequireComponent(typeof(Light))]
[RequireComponent(typeof(VolumetricLightBeamSD))]
public class VolumetricLightTracker : MonoBehaviour
{
    [SerializeField]
    [FormerlySerializedAs("Override")]
    private bool _Override;
    [SerializeField]
    [FormerlySerializedAs("Enabled")]
    private bool _Enabled;
    public Light light;
    public OptimizedLight optimizedLight;
    public VolumetricLightBeamSD beam;
    public VolumetricDustParticles dust;
    public bool Override { get; set; }
    public bool Enabled { get; set; }

    private void AssignReferences();
    private void UpdateEffectsState();
    private void Awake();
}