using System;
using System.Collections;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using UnityEngine;

namespace ScheduleOne.Lighting;
[RequireComponent(typeof(ReflectionProbe))]
public class ReflectionProbeUpdater : MonoBehaviour
{
    public ReflectionProbe Probe;
    private static List<ReflectionProbe> renderQueue;
    private static Coroutine RenderRoutine;
    private void OnValidate();
    private void Start();
    private void UpdateProbe();
    private IEnumerator ProcessQueue();
}