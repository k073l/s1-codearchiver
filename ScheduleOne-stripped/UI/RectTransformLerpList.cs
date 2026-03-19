using UnityEngine;

namespace ScheduleOne.UI;
public class RectTransformLerpList : RectTransformLerp
{
    [SerializeField]
    private RectTransform[] _targetPositions;
    [SerializeField]
    private bool _scaleDurationWithDistance;
    [SerializeField]
    private bool _lerpLocalPosition;
    [SerializeField]
    private bool _lerpScale;
    private float _longestDistance;
    protected override void Awake();
    public void LerpTo(int index, float duration);
    public void LerpTo(int index);
    private float GetDurationMultiplier(Vector2 start, Vector2 end);
}