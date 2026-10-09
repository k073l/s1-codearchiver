using System;
using System.Collections.Generic;
using ScheduleOne.Economy;
using ScheduleOne.ItemFramework;
using ScheduleOne.Product;

namespace ScheduleOne.UI.Handover;
public class HandoverScreenSampleMode : HandoverScreenMode
{
    private Customer _customer;
    private event Action<List<ItemInstance>> _onSubmitCallback;
    private event Action _onCancelCallback;
    private event Func<List<ItemInstance>, float> _successChanceMethod;
    public void Open(Customer customer, Action<List<ItemInstance>> onSubmitCallback, Action onCancelCallback, Func<List<ItemInstance>, float> getSuccessChance);
    protected override void OnClose();
    protected override void OnHandoverItemsChanged(List<ItemInstance> items);
    private void Refresh();
    private float GetSuccessChance();
    private bool GetError(out string errorMessage);
    private bool GetWarning(out string warningMessage);
    public override void Submit();
    public override void Cancel();
}