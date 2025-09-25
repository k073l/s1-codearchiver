using System;
using EasyButtons;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.Tools;
public class OptimizedColliderGroup : MonoBehaviour
{
    public const int UPDATE_DISTANCE;
    public Collider[] Colliders;
    public float ColliderEnableMaxDistance;
    private float sqrColliderEnableMaxDistance;
    private bool collidersEnabled;
    private void OnEnable();
    private void OnDestroy();
    private void RegisterEvent();
    [Button]
    public void GetColliders();
    public void Start();
    private void Refresh();
    private void SetCollidersEnabled(bool enabled);
}