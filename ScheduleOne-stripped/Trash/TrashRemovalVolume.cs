using System;
using System.Collections.Generic;
using FishNet;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using UnityEngine;

namespace ScheduleOne.Trash;
[RequireComponent(typeof(BoxCollider))]
public class TrashRemovalVolume : MonoBehaviour
{
    public BoxCollider Collider;
    public float RemovalChance;
    public void Awake();
    private void OnDestroy();
    private void SleepStart();
    private TrashItem[] GetTrash();
}