using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.Management.UI;
using ScheduleOne.Tools;
using ScheduleOne.UI;
using ScheduleOne.UI.Management;
using TMPro;
using UnityEngine;

namespace ScheduleOne.Management;
public class ManagementInterface : Singleton<ManagementInterface>
{
    [Serializable]
    public class ConfigurableTypePanel
    {
        public EConfigurableType Type;
        public ConfigPanel Panel;
    }

    public const float PANEL_SLIDE_TIME;
    [Header("References")]
    public TextMeshProUGUI NothingSelectedLabel;
    public TextMeshProUGUI DifferentTypesSelectedLabel;
    public RectTransform PanelContainer;
    public ClipboardScreen MainScreen;
    public ScheduleOne.UI.Management.ItemSelector ItemSelectorScreen;
    public NPCSelector NPCSelector;
    public ObjectSelector ObjectSelector;
    public RecipeSelector RecipeSelectorScreen;
    public TransitEntitySelector TransitEntitySelector;
    [SerializeField]
    protected ConfigurableTypePanel[] ConfigPanelPrefabs;
    public List<IConfigurable> Configurables;
    private bool areConfigurablesUniform;
    private ConfigPanel loadedPanel;
    public ManagementClipboard_Equippable EquippedClipboard { get; protected set; }

    protected override void Start();
    public void Open(List<IConfigurable> configurables, ManagementClipboard_Equippable _equippedClipboard);
    public void Close(bool preserveState = false);
    private void UpdateMainLabels();
    private void InitializeConfigPanel();
    private void DestroyConfigPanel();
    public ConfigPanel GetConfigPanelPrefab(EConfigurableType type);
}