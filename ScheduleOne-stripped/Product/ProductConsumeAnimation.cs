using ScheduleOne.Audio;
using ScheduleOne.AvatarFramework.Equipping;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace ScheduleOne.Product;
public class ProductConsumeAnimation : MonoBehaviour
{
    [FormerlySerializedAs("ConsumeAnimationBool")]
    [SerializeField]
    private string _thirdPersonAnimationBool;
    [FormerlySerializedAs("ConsumeAnimationTrigger")]
    [SerializeField]
    private string _thirdPersonAnimationTrigger;
    [SerializeField]
    private AvatarEquippable _thirdPersonEquippable;
    [Header("References")]
    public AudioSourceController ConsumeSound;
    [Header("Events")]
    public UnityEvent onPrepareStart;
    public UnityEvent onPrepareCancel;
    public UnityEvent onConsume;
    [field: SerializeField]
    public string ConsumeDescription { get; private set; } = "Smoke";

    [field: SerializeField]
    public float PrepareDuration { get; private set; } = 1.5f;

    [field: SerializeField]
    public float EffectsApplyDelay { get; private set; } = 2f;

    public void StartPrepare();
    public void CancelPrepare();
    public void StartConsume();
    public void StopConsume();
}