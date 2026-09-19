using ScheduleOne.Core;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.Money;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Interaction;
[RequireComponent(typeof(InteractableObject))]
public class InteractablePurchaseableItem : MonoBehaviour
{
    [Header("Item and Price")]
    [SerializeField]
    private ECurrencyType _paymentType;
    [SerializeField]
    private bool _useItemDefaultPrice;
    [SerializeField]
    [Conditional("_useItemDefaultPrice", true)]
    private int _setPrice;
    [SerializeField]
    private StorableItemDefinition _item;
    [SerializeField]
    [Range(0f, 10f)]
    private int _itemQuantity;
    [Header("Other Settings")]
    [SerializeField]
    private bool _showNameInMessage;
    [SerializeField]
    private bool _playCashSoundOnPurchase;
    [SerializeField]
    private float _purchaseCooldown;
    private float _lastPurchaseTime;
    private InteractableObject _interactableObject;
    private int _price { get; }

    protected virtual void Awake();
    private void OnHovered();
    private void OnInteracted();
    private void Buy();
    protected ItemInstance GetItemToGive(int quantity);
    protected virtual bool CanBuy(out string cantBuyReason);
    private bool HasSpaceInInventory();
    private bool HasEnoughFunds();
    private bool IsOnPurchaseCooldown();
}