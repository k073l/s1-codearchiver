using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ScheduleOne;
public class UIMapItem : MonoBehaviour
{
    [SerializeField]
    private UIMapPanel mapPanel;
    [SerializeField]
    private Button button;
    private RectTransform rectTransform;
    public RectTransform GetRectTransform();
    private void Awake();
    public void SetMapPanel(UIMapPanel panel);
    public Vector2 GetMapPosition();
    public void OnClick();
    public void OnPointerEnter();
    public void OnPointerExit();
}