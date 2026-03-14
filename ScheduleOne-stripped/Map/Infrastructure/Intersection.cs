using System.Collections;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Map.Infrastructure;
public class Intersection : MonoBehaviour
{
    private const float AmberTime;
    [Header("References")]
    [SerializeField]
    protected List<TrafficLight> path1Lights;
    [SerializeField]
    protected List<TrafficLight> path2Lights;
    [SerializeField]
    protected List<GameObject> path1Obstacles;
    [SerializeField]
    protected List<GameObject> path2Obstacles;
    [Header("Settings")]
    [SerializeField]
    protected float path1Time;
    [SerializeField]
    protected float path2Time;
    [SerializeField]
    protected float timeOffset;
    protected virtual void Start();
    protected IEnumerator Run();
    protected void SetPath1Lights(TrafficLight.State state);
    protected void SetPath2Lights(TrafficLight.State state);
}