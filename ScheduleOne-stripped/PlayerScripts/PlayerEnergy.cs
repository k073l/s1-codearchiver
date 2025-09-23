using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.PlayerScripts.Health;
using ScheduleOne.UI;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.PlayerScripts;
public class PlayerEnergy : MonoBehaviour
{
    public const float CRITICAL_THRESHOLD;
    public const float MAX_ENERGY;
    public const float SPRINT_DRAIN_MULTIPLIER;
    public bool DEBUG_DISABLE_ENERGY;
    [Header("Settings")]
    public float EnergyDuration_Hours;
    public float EnergyRechargeTime_Hours;
    public UnityEvent onEnergyChanged;
    public UnityEvent onEnergyDepleted;
    public float CurrentEnergy { get; protected set; } = 100f;
    public int EnergyDrinksConsumed { get; protected set; }

    protected virtual void Start();
    private void MinPass();
    private void ChangeEnergy(float change);
    public void SetEnergy(float newEnergy);
    public void RestoreEnergy();
    private void SleepEnd();
    public void IncrementEnergyDrinks();
    private void ResetEnergyDrinks();
}