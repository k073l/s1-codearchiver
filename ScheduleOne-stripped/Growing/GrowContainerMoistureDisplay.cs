using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.Growing;
public class GrowContainerMoistureDisplay : MonoBehaviour
{
    public const float MaxCameraDistance;
    public const float MinCameraDistance;
    public const float FadeInDistance;
    public const float FadeOutDistance;
    public bool SnapToRightAngles;
    [Header("References")]
    public GrowContainer GrowContainer;
    public Transform WaterCanvasContainer;
    public Canvas WaterLevelCanvas;
    public CanvasGroup WaterLevelCanvasGroup;
    public Slider WaterLevelSlider;
    public GameObject NoWaterIcon;
    protected virtual void Awake();
    private void LateUpdate();
    private void UpdateCanvas();
    protected virtual void UpdateCanvasContents();
}