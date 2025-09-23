using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Interaction;
using ScheduleOne.ItemFramework;
using ScheduleOne.Money;
using ScheduleOne.ObjectScripts.Cash;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Storage;
using UnityEngine;

namespace ScheduleOne.Building;
public class BuildUpdate_Cash : BuildUpdate_StoredItem
{
    public int amountIndex;
    protected List<Transform> bills;
    private WorldSpaceLabel amountLabel;
    private float placeAmount => Cash.amounts[amountIndex % Cash.amounts.Length];

    private void Start();
    protected override void Update();
    protected override void LateUpdate();
    private void UpdateLabel();
    private void RefreshGhostModelAppearance();
    protected override void Place();
    protected override void PostPlace();
    public override void Stop();
    public float GetRelevantCashBalane();
}