using System;
using UnityEngine;

namespace ScheduleOne.NPCs;
[Serializable]
public class SpeedControl
{
    public enum EType
    {
        Normalized,
        Absolute
    }

    private string _id;
    private int _priority;
    private float _speed;
    private EType _type;
    public string Id => _id;
    public int Priority => _priority;
    public float Speed => _speed;
    public EType Type => _type;

    public event Action OnSpeedChanged;
    public event Action OnPriorityChanged;
    public SpeedControl(string id, int priority, float speed, EType type = EType.Normalized);
    public void SetSpeed(float speed);
    public void SetSpeed(float speed, EType type);
    public void SetPriority(int priority);
}