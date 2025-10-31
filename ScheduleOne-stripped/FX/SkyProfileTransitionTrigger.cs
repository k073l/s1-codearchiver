using Funly.SkyStudio;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.FX;
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class SkyProfileTransitionTrigger : MonoBehaviour
{
    public SkyProfile TransitionToOnEnter;
    public SkyProfile TransitionToOnExit;
    public float TransitionDuration;
    public void OnTriggerEnter(Collider other);
    public void OnTriggerExit(Collider other);
}