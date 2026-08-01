using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI.Phone.Messages;
public class MessageBubble : MonoBehaviour
{
    public enum Alignment
    {
        Center,
        Left,
        Right
    }

    private static Color32 OtherBubbleColor;
    private static Color32 OtherTextColor;
    public const float BaseBubbleSpacing;
    [Header("Settings")]
    public string text;
    public Alignment alignment;
    public bool showTriangle;
    public float bubble_MinWidth;
    public float bubble_MaxWidth;
    public bool alignTextCenter;
    public bool autosetPosition;
    [Header("References")]
    [SerializeField]
    protected RectTransform container;
    [SerializeField]
    protected Image bubble;
    [SerializeField]
    protected Text content;
    [SerializeField]
    protected Image triangle_Left;
    [SerializeField]
    protected Image triangle_Right;
    [SerializeField]
    protected Button button;
    private string displayedText;
    private bool triangleShown;
    public float Height { get; private set; }
    public float SpacingAbove { get; set; }
    public RectTransform Container => container;
    public Button Button => button;

    public void SetupBubble(string _text, Alignment _alignment, bool interactable, bool alignCenter = false);
    protected virtual void Update();
    public virtual void RefreshDisplayedText();
    protected virtual void RefreshTriangle();
}