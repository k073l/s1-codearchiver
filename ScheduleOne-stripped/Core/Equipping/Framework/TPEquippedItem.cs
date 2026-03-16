using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.Core.Equipping.Framework;
public class TPEquippedItem : MonoBehaviour
{
    public enum EAnchorHand
    {
        Right,
        Left
    }

    [Tooltip("Which hand bone should the equipped item be anchored/parented to?")]
    [SerializeField]
    private EAnchorHand _anchorHand;
    [Tooltip("This item will be positioned/rotated so that this transform aligns with the appropriate hand anchor point.")]
    [SerializeField]
    private Transform _alignmentPoint;
    [Header("Animation Settings")]
    [Tooltip("Set an animation bool to true while this item is equipped? Resets to false on unequip.")]
    [SerializeField]
    private bool _useEquipBool;
    [Conditional("_useEquipBool", false)]
    [SerializeField]
    private EThirdPersonAnimationEquipBool _equipBool;
    [Conditional("_equipBool", EThirdPersonAnimationEquipBool.Custom, false)]
    [SerializeField]
    private string _customEquipAnimationBool;
    [Tooltip("Set an animation trigger when this item is first equipped?")]
    [SerializeField]
    private bool _useEquipTrigger;
    [Conditional("_useEquipTrigger", false)]
    [SerializeField]
    private string _equipAnimationTrigger;
    [Tooltip("Set an animation trigger when this item is unequipped")]
    [SerializeField]
    private bool _useUnequipTrigger;
    [Conditional("_useUnequipTrigger", false)]
    [SerializeField]
    private string _unequipAnimationTrigger;
    [Header("Events")]
    [SerializeField]
    private UnityEvent OnEquip;
    [SerializeField]
    private UnityEvent OnUnequip;
    public EAnchorHand AnchorHand => _anchorHand;
    protected IEquippedItemHandler _handler { get; private set; }

    public virtual void Equip(IEquippedItemHandler handler);
    protected virtual void Unequip();
    private void Align();
    private void SetVisible(bool visible);
    private string GetEquipBoolParameterName();
    private static Transform GetEquippableParent(IThirdPersonReferencesProvider references, EAnchorHand anchorHand);
    private static Transform GetEquippableAlignmentTarget(IThirdPersonReferencesProvider references, EAnchorHand anchorHand);
    [Button("CreateAlignmentPoint", "!_alignmentPoint")]
    public void CreateAlignmentPoint();
}