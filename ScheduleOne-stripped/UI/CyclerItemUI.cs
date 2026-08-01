using UnityEngine;

namespace ScheduleOne.UI;
public class CyclerItemUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private string _label;
    [SerializeField]
    private GameObject _content;
    [Header("Screens")]
    [SerializeField]
    private UIPanel _contentPanel;
    public UIPanel ContentPanel => _contentPanel;
    public GameObject Content => _content;
    public string Label => _label;
}