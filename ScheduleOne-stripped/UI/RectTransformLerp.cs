using System.Collections;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.UI;
[RequireComponent(typeof(RectTransform))]
public class RectTransformLerp : MonoBehaviour
{
    [SerializeField]
    protected float _defaultLerpDuration;
    [SerializeField]
    private bool _lerpPosition;
    protected RectTransform _rectTransform;
    private Coroutine _positionRoutine;
    private Coroutine _scaleRoutine;
    protected virtual void Awake();
    public void LerpLocalPosition(Vector3 endLocalPosition, float duration = -1f);
    public void LerpLocalScale(Vector3 endLocalscale, float duration = -1f);
}