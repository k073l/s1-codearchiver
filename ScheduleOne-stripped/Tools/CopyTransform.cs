using UnityEngine;

namespace ScheduleOne.Tools;
public class CopyTransform : MonoBehaviour
{
    public enum EUpdateMode
    {
        Update,
        LateUpdate,
        FixedUpdate
    }

    public Transform Target;
    public EUpdateMode UpdateMode;
    public bool CopyPosition;
    public bool CopyRotation;
    public bool CopyScale;
    public Vector3 GlobalPositionOffset;
    public Vector3 LocalPositionOffset;
    public Vector3 RotationOffset;
    private void FixedUpdate();
    private void Update();
    private void LateUpdate();
    private void Copy();
}