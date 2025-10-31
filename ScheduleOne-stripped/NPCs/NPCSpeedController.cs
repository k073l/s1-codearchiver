using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScheduleOne.NPCs;
public class NPCSpeedController : MonoBehaviour
{
    [Serializable]
    public class SpeedControl
    {
        public string id;
        public int priority;
        public float speed;
        public SpeedControl(string id, int priority, float speed);
    }

    [Header("Settings")]
    [Range(0f, 1f)]
    public float DefaultWalkSpeed;
    [SerializeField]
    [FormerlySerializedAs("SpeedMultiplier")]
    private float _SpeedMultiplier;
    [Header("References")]
    public NPCMovement Movement;
    protected List<SpeedControl> speedControlStack;
    public SpeedControl ActiveSpeedControl;
    public float SpeedMultiplier { get; set; }

    private void Awake();
    public void AddSpeedControl(SpeedControl control);
    public SpeedControl GetSpeedControl(string id);
    public bool DoesSpeedControlExist(string id);
    public void RemoveSpeedControl(string id);
    private void UpdateActiveSpeedControl();
}