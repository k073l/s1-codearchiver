using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Product;
public class FirstPersonProductConsumeAnimation : MonoBehaviour
{
    [Header("Settings")]
    public string ConsumeDescription;
    public float ConsumeTime;
    public float EffectsApplyDelay;
    public string ConsumeAnimationBool;
    public string ConsumeAnimationTrigger;
    public string ConsumeEquippableAssetPath;
    [Header("Events")]
    public UnityEvent onPrepareStart;
    public UnityEvent onPrepareCancel;
    public UnityEvent onConsume;
    public void StartPrepare();
    public void CancelPrepare();
    public void StartConsume();
    public void StopConsume();
}