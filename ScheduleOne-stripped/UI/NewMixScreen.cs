using System;
using System.Collections.Generic;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Effects;
using ScheduleOne.Money;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using ScheduleOne.Product;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class NewMixScreen : Singleton<NewMixScreen>
{
    private const int MaxDisplayedProperties;
    [Header("References")]
    [SerializeField]
    protected Canvas canvas;
    [SerializeField]
    protected RectTransform container;
    [SerializeField]
    protected TMP_InputField nameInputField;
    [SerializeField]
    protected GameObject mixAlreadyExistsText;
    [SerializeField]
    protected RectTransform editIcon;
    [SerializeField]
    protected Button confirmButton;
    [SerializeField]
    protected TextMeshProUGUI[] propertiesLabels;
    [SerializeField]
    protected TextMeshProUGUI marketValueLabel;
    [SerializeField]
    protected AudioSourceController sound;
    [SerializeField]
    protected UIScreen screen;
    [Header("Name Library")]
    [SerializeField]
    protected List<string> name1Library;
    [SerializeField]
    protected List<string> name2Library;
    public bool IsOpen => ((Behaviour)canvas).enabled;

    public event Action<string> onMixNamed;
    protected override void Awake();
    public void Open(List<Effect> properties, EDrugType drugType, float productMarketValue);
    public void Close();
    public void RandomizeButtonClicked();
    public void ConfirmButtonClicked();
    public string GenerateUniqueName(Effect[] properties = null, EDrugType drugType = EDrugType.Marijuana);
    protected void RefreshNameButtons();
    public void OnNameValueChanged(string newVal);
}