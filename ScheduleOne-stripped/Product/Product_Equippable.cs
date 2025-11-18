using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Equipping;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using TMPro;
using UnityEngine;

namespace ScheduleOne.Product;
public class Product_Equippable : Equippable_Viewmodel
{
    [Header("References")]
    public ProductVisualsSetter Visuals;
    public Transform ModelContainer;
    private FirstPersonProductConsumeAnimation consumeAnimation;
    private bool isConsumable;
    private float consumeTime;
    private bool consumingInProgress;
    private Vector3 defaultModelPosition;
    private Coroutine consumeRoutine;
    public string ConsumeDescription => consumeAnimation.ConsumeDescription;
    public float ConsumeTime => consumeAnimation.ConsumeTime;
    public float EffectsApplyDelay => consumeAnimation.EffectsApplyDelay;

    public override void Equip(ItemInstance item);
    protected virtual void ApplyProductVisuals(ProductItemInstance product);
    public override void Unequip();
    protected override void Update();
    protected virtual void StartPrepare();
    protected virtual void CancelPrepare();
    protected virtual void Consume();
    protected virtual void ApplyEffects();
}