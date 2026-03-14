using System;
using System.Collections;
using ScheduleOne.Core.Items.Framework;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Variables;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.ItemFramework;
[RequireComponent(typeof(InteractableObject))]
public class ItemPickup : MonoBehaviour
{
    public ItemDefinition ItemToGive;
    public bool DestroyOnPickup;
    public bool ConditionallyActive;
    public Condition ActiveCondition;
    [Header("References")]
    public InteractableObject IntObj;
    public UnityEvent onPickup;
    protected virtual void Awake();
    private void Start();
    private void Init();
    protected virtual void Hovered();
    private void Interacted();
    protected virtual bool CanPickup();
    protected virtual void Pickup();
    public void Destroy();
}