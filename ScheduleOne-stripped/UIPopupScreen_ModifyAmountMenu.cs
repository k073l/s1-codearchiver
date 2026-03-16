using System;
using System.Collections;
using ScheduleOne.DevUtilities;
using ScheduleOne.UI.Shop;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne;
public class UIPopupScreen_ModifyAmountMenu : UIPopupScreen
{
    public enum ModifyAmountMenuMode
    {
        Store
    }

    [SerializeField]
    private TMP_Text titleText;
    [SerializeField]
    private TMP_Text topMessageText;
    [SerializeField]
    private TMP_Text bottomMessageText;
    [SerializeField]
    private TMP_InputField amountInputField;
    [SerializeField]
    private Image itemImage;
    [SerializeField]
    private TMP_Text itemNameText;
    [SerializeField]
    private TMP_Text itemCostText;
    [SerializeField]
    private UITrigger confirmButton;
    [SerializeField]
    private UITrigger cancelButton;
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Button tier1DecreaseButton;
    [SerializeField]
    private Button tier2DecreaseButton;
    [SerializeField]
    private Button tier3DecreaseButton;
    [SerializeField]
    private Button tier1IncreaseButton;
    [SerializeField]
    private Button tier2IncreaseButton;
    [SerializeField]
    private Button tier3IncreaseButton;
    [SerializeField]
    private TMP_Text tier1DecreaseText;
    [SerializeField]
    private TMP_Text tier2DecreaseText;
    [SerializeField]
    private TMP_Text tier3DecreaseText;
    [SerializeField]
    private TMP_Text tier1IncreaseText;
    [SerializeField]
    private TMP_Text tier2IncreaseText;
    [SerializeField]
    private TMP_Text tier3IncreaseText;
    [SerializeField]
    private float holdThreshold;
    [SerializeField]
    private float repeatInterval;
    private UIInputDetectBehaviour tier1InputDetect;
    private UIInputDetectBehaviour tier2InputDetect;
    private UIInputDetectBehaviour tier3InputDetect;
    private ModifyAmountMenuMode modifyAmountMenuMode;
    private float itemPrice;
    private float minAmount;
    private float tier1Amount;
    private float tier2Amount;
    private float tier3Amount;
    protected override void OnAwake();
    protected override void OnStarted();
    protected override void Update();
    public override void Close();
    private void Open();
    private IEnumerator SelectInputField();
    public override void Open(params object[] args);
    private IEnumerator RegisterInput(Action<float> onConfirm, Action onCancel);
    private void UpdateStoreBottomMessage();
    private float GetCurrentAmount();
    private void ChangeCurrentAmountBasedOnInputDetectTier1(float inputValue);
    private void ChangeCurrentAmountBasedOnInputDetectTier2(float inputValue);
    private void ChangeCurrentAmountBasedOnInputDetectTier3(float inputValue);
    private void ChangeCurrentAmountBasedOnInputDetect(float inputValue, float tierAmount);
    private void ChangeCurrentAmount(float increment);
    private void SetCurrentAmount(float amount);
    private void CapAmount(float amount);
}