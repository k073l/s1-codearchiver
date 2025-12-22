using System;
using UnityEngine;

namespace ScheduleOne.Tools;
[Serializable]
public class TransformLerp
{
    [SerializeField]
    private Transform _transform;
    [SerializeField]
    private Transform _min;
    [SerializeField]
    private Transform _max;
    [Header("Settings")]
    [SerializeField]
    private bool _lerpPosition;
    [SerializeField]
    private bool _lerpRotation;
    [SerializeField]
    private bool _lerpScale;
    [SerializeField]
    private bool _disableOnZero;
    private float _currentLerpValue;
    public void SetLerpValue(float lerpValue);
}