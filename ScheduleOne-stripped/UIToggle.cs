using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace ScheduleOne;
public class UIToggle : UIOption
{
    [SerializeField]
    private TextMeshProUGUI buttonText;
    [SerializeField]
    private Image toggleImage;
    private const string ONTEXT;
    private const string OFFTEXT;
    public UnityEvent<bool> OnChanged;
    private bool state;
    protected override void Awake();
    protected override void OnUpdate();
    public void SetState(bool state);
    public void SetStateWithoutNotify(bool state);
    private void SetStateInternal(bool state);
    private void SetButtonState(bool state);
}