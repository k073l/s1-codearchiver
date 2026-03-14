using UnityEngine;

namespace ScheduleOne;
public abstract class UIPopupScreen : UIScreen
{
    [SerializeField]
    [Tooltip("Identifier of the PopupScreen when you called OpenPopupScreen from UIScreenManager")]
    private string popupID;
    public string PopupID => popupID;

    public virtual void Open(params object[] args);
    public virtual void Close();
}