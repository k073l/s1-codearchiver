using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Core.Weather;
public class WorldEnclosure : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private List<BasicEnclosure> _enclosures;
    public float _stereoPanLimit;
    private float _blendChangeSpeed;
    private float _targetBlend;
    private float _currentBlend;
    private float _currentPan;
    private float _targetPan;
    private void Start();
    private void Update();
    public bool WithinEnclosure(Vector3 targetPosition, Vector3 targetRight, out float blend, out float pan);
    private float ConvertLeftRightToPan(float left, float right);
}