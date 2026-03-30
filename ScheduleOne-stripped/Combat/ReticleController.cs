using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.UI;
using UnityEngine;

namespace ScheduleOne.Combat;
public class ReticleController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private ReticleUI _reticleUI;
    [Header("Settings")]
    [SerializeField]
    private float _fadeDuration;
    private bool _isActive;
    private Coroutine _fadeCo;
    public bool IsActive => _isActive;

    private void Awake();
    public void ShowReticle(float duration = -1f);
    public void HideReticle(float duration = -1f);
    public void SetReticle(float spreadAngle);
    private IEnumerator DoRecticleFade(float endAlpha, float duration);
}