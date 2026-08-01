using System;
using ScheduleOne.DevUtilities;
using ScheduleOne.Money;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.Casino.UI;
public class CasinoGameBetPanel : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private GameObject _container;
    [SerializeField]
    private TextMeshProUGUI _betTitleLabel;
    [SerializeField]
    private Slider _betSlider;
    [SerializeField]
    private TextMeshProUGUI _betAmount;
    [SerializeField]
    private Button _readyButton;
    [SerializeField]
    private TextMeshProUGUI _readyLabel;
    [SerializeField]
    private UIPanel _panel;
    private CasinoGameController _gameController;
    private void Awake();
    public void Open(CasinoGameController game);
    public void Close();
    private void Update();
    private void BetSliderChanged(float value);
    private void RefreshDisplayedBet();
    private void RefreshReadyButton();
    private float GetBetFromSliderValue(float sliderVal);
    private void ReadyToggled();
}