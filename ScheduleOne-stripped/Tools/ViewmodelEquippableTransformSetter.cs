using UnityEngine;

namespace ScheduleOne.Tools;
[ExecuteInEditMode]
public class ViewmodelEquippableTransformSetter : MonoBehaviour
{
    private static Vector3 lastRecordedLocalPosition;
    private static Vector3 lastRecordedLocalEulerAngles;
    private static Vector3 lastRecordedLocalScale;
    private static bool transformChangedApplied;
}