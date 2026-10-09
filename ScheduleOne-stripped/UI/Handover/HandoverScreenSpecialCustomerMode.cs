using System;
using System.Collections.Generic;
using ScheduleOne.ItemFramework;
using ScheduleOne.NPCs;
using ScheduleOne.Product;
using UnityEngine;

namespace ScheduleOne.UI.Handover;
public class HandoverScreenSpecialCustomerMode : HandoverScreenMode
{
    [Header("Components")]
    [SerializeField]
    private HandoverScreenSpecialCustomerPanel _specialCustomerPanel;
    private SpecialCustomerLeader _groupLeader;
    private SpecialCustomerLeader.ProductEvaluationResult _productEvaluationResult;
    private event Action<List<ItemInstance>> _onSubmitCallback;
    private event Action _onCancelCallback;
    private event Func<List<ItemInstance>, float> _successChanceMethod;
    public void Open(SpecialCustomerLeader groupLeader, Action<List<ItemInstance>> onSubmitCallback, Action onCancelCallback);
    protected override void OnClose();
    protected override void OnHandoverItemsChanged(List<ItemInstance> items);
    private void Refresh();
    private bool GetError(out string errorMessage);
    private bool GetWarning(out string warningMessage);
    public override void Submit();
    public override void Cancel();
}