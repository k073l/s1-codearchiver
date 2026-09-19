using System.Collections.Generic;
using ScheduleOne.Effects;
using ScheduleOne.Money;
using ScheduleOne.Product;
using TMPro;
using UnityEngine;

namespace ScheduleOne.UI.Handover;
public class HandoverScreenSpecialCustomerPanel : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private GameObject _container;
    [SerializeField]
    private TextMeshProUGUI _groupNameText;
    [SerializeField]
    private TextMeshProUGUI _acceptedDrugsText;
    [SerializeField]
    private TextMeshProUGUI _favouriteEffectstext;
    [SerializeField]
    private TextMeshProUGUI _totalPriceText;
    [SerializeField]
    private ProgressBarUI _progressBar;
    [SerializeField]
    private LabelValueUI _basePriceVL;
    [SerializeField]
    private LabelValueUI _bonusPriceVL;
    public void SetInfo(string groupName, List<EDrugType> acceptedDrugs, List<Effect> favouriteEffects);
    public void SetProgressBar(float currentProgress, float newProgress, string label);
    public void SetBasePrice(float basePrice);
    public void SetBonusPrice(float bonusPrice);
    public void SetTotalPrice(float totalPrice);
    public void Open();
    public void Close();
}