using TMPro;
using UnityEngine;

namespace ScheduleOne;
public class UISelectable_ContextMenu : UISelectable
{
    [SerializeField]
    private TMP_Text labelText;
    public void Setup(string label);
}