using System;
using UnityEngine;

namespace ScheduleOne.Temperature;
public class TemperatureEmitter : MonoBehaviour
{
    public const int DefaultAmbientTemperature;
    public const int MinTemperature;
    public const int MaxTemperature;
    public Action OnEmitterChanged;
    [field: SerializeField]
    public float Temperature { get; private set; } = 20f;

    [field: SerializeField]
    public float Range { get; private set; } = 5f;
    public Vector3 EmissionPoint => ((Component)this).transform.position;

    public void SetPosition(Vector3 position);
    public void SetTemperature(float temperature);
    public void SetRange(float range);
    public void NotifyChanged();
}