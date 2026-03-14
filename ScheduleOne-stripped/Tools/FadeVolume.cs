using ScheduleOne.DevUtilities;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.Tools;
public class FadeVolume : MonoBehaviour
{
    [SerializeField]
    [FormerlySerializedAs("StartPoint")]
    private Transform _startPoint;
    [SerializeField]
    [FormerlySerializedAs("EndPoint")]
    private Transform _endPoint;
    [SerializeField]
    [FormerlySerializedAs("BoxCollider")]
    private BoxCollider _boxCollider;
    private void Awake();
    private void OnDrawGizmos();
    public float GetPositionScalar(Vector3 point);
}