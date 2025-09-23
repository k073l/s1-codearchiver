using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI.Handover;
public class HandoverScreenPriceSelector : MonoBehaviour
{
    public const float MinPrice;
    public const float MaxPrice;
    public InputField InputField;
    public UnityEvent onPriceChanged;
    public float Price { get; private set; } = 1f;

    public void SetPrice(float price);
    public void RefreshPrice();
    public void OnPriceInputChanged(string value);
    public void ChangeAmount(float change);
}