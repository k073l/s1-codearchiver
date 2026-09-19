using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScheduleOne.NPCs;
public class NPCSpeedController
{
    private float _speedMultiplier;
    private float _maxSpeed;
    private List<SpeedControl> _speedControlStack;
    private Dictionary<string, SpeedControl> _speedControlDict;
    public float MoveSpeed { get; private set; }

    public event Action<float> OnMoveSpeedChanged;
    public NPCSpeedController(float defaultSpeed_Ms = 1.8f);
    public void SetDefaultSpeed(float speed_Ms);
    public void SetMaxSpeed(float maxSpeed_Ms);
    public void SetSpeedMultiplier(float multiplier);
    public void AddSpeedControl(string id, float speed, int priority = 1, SpeedControl.EType type = SpeedControl.EType.Normalized);
    public bool DoesSpeedControlExist(string id);
    public void RemoveSpeedControl(string id);
    private void AddSpeedControl(SpeedControl control);
    private SpeedControl GetSpeedControl(string id);
    private void RecalculateMoveSpeed();
    private void SortSpeedControlStack();
}