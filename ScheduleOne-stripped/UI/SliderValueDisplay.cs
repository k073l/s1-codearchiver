using ScheduleOne.Money;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class SliderValueDisplay : MonoBehaviour
{
    public enum EDisplayMode
    {
        Normal,
        Percentage,
        Money
    }

    [SerializeField]
    private Text _label;
    [SerializeField]
    private TextMeshProUGUI _tmpLabel;
    [SerializeField]
    private Slider _slider;
    [Header("Settings")]
    [SerializeField]
    private EDisplayMode _displayMode;
    [SerializeField]
    private bool showDecimalPlaces;
    private void Awake();
    private void OnEnable();
    private void SliderChanged(float value);
}