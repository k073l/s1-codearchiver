using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Items;
public class ItemEntryUI : MonoBehaviour
{
    [Header("Components")]
    [SerializeField]
    private Text _nameLabel;
    [SerializeField]
    private Text _quantityLabel;
    [SerializeField]
    private Image _icon;
    public void Set(string name, int quantity, Sprite icon);
    public void SetLabelOnly(string name);
}