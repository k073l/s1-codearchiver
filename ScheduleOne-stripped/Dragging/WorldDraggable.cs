using System;
using ScheduleOne.Core;
using ScheduleOne.Interaction;
using UnityEngine;

namespace ScheduleOne.Dragging;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(InteractableObject))]
public class WorldDraggable : Draggable, IGUIDRegisterable
{
    public string BakedGUID;
    [Button]
    public void RegenerateGUID();
    protected override void Awake();
}