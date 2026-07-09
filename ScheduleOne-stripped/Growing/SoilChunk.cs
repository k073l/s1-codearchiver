using System.Collections;
using ScheduleOne.PlayerTasks;
using UnityEngine;

namespace ScheduleOne.Growing;
public class SoilChunk : Clickable
{
    public Transform EndTransform;
    public float LerpTime;
    private Vector3 localPos_Start;
    private Vector3 localEulerAngles_Start;
    private Vector3 localScale_Start;
    private Coroutine lerpRoutine;
    public Collider _collider;
    public float CurrentLerp { get; protected set; }
    public override bool RegisterDefaultLureWhenEmpty => true;
    protected override Vector3 LurePositionOffset { get; set; } = new Vector3(0f, 0.01f, 0f);

    protected virtual void Awake();
    public void SetLerpedTransform(float _lerp);
    public override void StartClick(RaycastHit hit);
    public void StopLerp();
    public void SetChunkClickable(bool clickable);
    public void SetColliderEnabled(bool enabled);
}