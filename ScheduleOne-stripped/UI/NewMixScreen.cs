using System;
using System.Collections.Generic;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Money;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using ScheduleOne.Product;
using ScheduleOne.Properties;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class NewMixScreen : Singleton<NewMixScreen>
{
    public const int MAX_PROPERTIES_DISPLAYED;
    [Header("References")]
    [SerializeField]
    protected Canvas canvas;
    public RectTransform Container;
    [SerializeField]
    protected TMP_InputField nameInputField;
    [SerializeField]
    protected GameObject mixAlreadyExistsText;
    [SerializeField]
    protected RectTransform editIcon;
    [SerializeField]
    protected Button randomizeNameButton;
    [SerializeField]
    protected Button confirmButton;
    [SerializeField]
    protected TextMeshProUGUI PropertiesLabel;
    [SerializeField]
    protected TextMeshProUGUI MarketValueLabel;
    public AudioSourceController Sound;
    [Header("Prefabs")]
    [SerializeField]
    protected GameObject attributeEntryPrefab;
    [Header("Name Library")]
    [SerializeField]
    protected List<string> name1Library;
    [SerializeField]
    protected List<string> name2Library;
    public Action<string> onMixNamed;
    public bool IsOpen => ((Behaviour)canvas).enabled;

    protected override void Awake();
    private void Exit(ExitAction action);
    protected virtual void Update();
    public void Open(List<ScheduleOne.Properties.Property> properties, EDrugType drugType, float productMarketValue);
    public void Close();
    public void RandomizeButtonClicked();
    public void ConfirmButtonClicked();
    public string GenerateUniqueName(ScheduleOne.Properties.Property[] properties = null, EDrugType drugType = EDrugType.Marijuana);
    protected void RefreshNameButtons();
    public void OnNameValueChanged(string newVal);
}