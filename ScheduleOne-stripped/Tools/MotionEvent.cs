using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.Tools;
public class MotionEvent
{
    public List<Action> Actions;
    public Vector3 LastUpdatedDistance;
    public void Update(Vector3 newPosition);
}