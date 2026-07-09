using UnityEngine;
using UnityEngine.InputSystem.Layouts;

namespace ScheduleOne.UI.Input;
[CreateAssetMenu(fileName = "InputPromptsBindingData", menuName = "ScheduleOne/Input/Input Binding Data", order = 1)]
public class InputPromptsBindingData : ScriptableObject
{
    public enum ESpriteSettingType
    {
        Auto,
        Custom
    }

    public GameInput.InputDeviceType ControlScheme;
    public EPlatformType PlatformType;
    [InputControl]
    public string ControlPath;
    public Sprite Sprite;
    public Vector2 SpriteSize;
    public ESpriteSettingType SpriteLabelSettingType;
    public string SpriteLabel;
    public float SpritePixelMultiplier;
    public bool EnableSpriteBackdrop;
    public Color SpriteColor;
    public string InlineId;
    public string InlineLabel;
}