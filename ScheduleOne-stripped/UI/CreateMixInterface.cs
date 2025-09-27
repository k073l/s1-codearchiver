using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.ItemFramework;
using ScheduleOne.PlayerScripts;
using ScheduleOne.Product;
using ScheduleOne.Properties;
using ScheduleOne.Storage;
using ScheduleOne.UI.Compass;
using ScheduleOne.UI.Items;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class CreateMixInterface : Singleton<CreateMixInterface>
{
    public const int BEAN_REQUIREMENT;
    [Header("References")]
    public Canvas Canvas;
    public ItemSlotUI BeansSlot;
    public ItemSlotUI ProductSlot;
    public ItemSlotUI MixerSlot;
    public ItemSlotUI OutputSlot;
    public Image OutputIcon;
    public Button BeginButton;
    public WorldStorageEntity Storage;
    public TextMeshProUGUI ProductPropertiesLabel;
    public TextMeshProUGUI OutputPropertiesLabel;
    public TextMeshProUGUI BeanProblemLabel;
    public TextMeshProUGUI ProductProblemLabel;
    public TextMeshProUGUI MixerProblemLabel;
    public TextMeshProUGUI OutputProblemLabel;
    public Transform CameraPosition;
    public RectTransform UnknownOutputIcon;
    public UnityEvent onOpen;
    public UnityEvent onClose;
    public bool IsOpen { get; private set; }
    private ItemSlot beanSlot => Storage.ItemSlots[0];
    private ItemSlot mixerSlot => Storage.ItemSlots[1];
    private ItemSlot outputSlot => Storage.ItemSlots[2];
    private ItemSlot productSlot => Storage.ItemSlots[3];

    protected override void Awake();
    private void Exit(ExitAction action);
    public void Open();
    private void ContentsChanged();
    private void UpdateCanBegin();
    private void UpdateOutput();
    private void BeginPressed();
    private List<ScheduleOne.Properties.Property> GetOutputProperties(ProductDefinition product, PropertyItemDefinition mixer);
    private bool IsOutputKnown(out ProductDefinition knownProduct);
    private string GetPropertyListString(List<ScheduleOne.Properties.Property> properties);
    private string GetPropertyString(ScheduleOne.Properties.Property property);
    private bool CanBegin();
    public void Close();
    private bool HasProduct();
    private bool HasBeans();
    private bool HasMixer();
    private ProductDefinition GetProduct();
    private PropertyItemDefinition GetMixer();
}