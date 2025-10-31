using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Map;
public class SewerCameraFadeVolume : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;
    public BoxCollider BoxCollider;
    private void Awake();
    private void OnDrawGizmos();
    public float GetPresenseScalar(Vector3 point);
}