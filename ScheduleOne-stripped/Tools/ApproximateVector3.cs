using UnityEngine;

namespace ScheduleOne.Tools;
public struct ApproximateVector3
{
    public short X;
    public short Y;
    public short Z;
    public ApproximateVector3(float x, float y, float z);
    public ApproximateVector3(Vector3 vector);
    public Vector3 ToVector3();
}