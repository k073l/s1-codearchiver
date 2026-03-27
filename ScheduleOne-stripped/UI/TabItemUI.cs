using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class TabItemUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private ButtonUI _button;
    [SerializeField]
    private Text _label;
    [SerializeField]
    private GameObject _content;
    [Header("Additionals")]
    [SerializeField]
    private GameObject _indicator;
    [SerializeField]
    private Text _indicatorLabel;
    public ButtonUI Button => _button;
    public Text Label => _label;
    public GameObject Content => _content;

    public void SetIndicator(string text);
    public void HideIndicator();
}