using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.UI.WorldspacePopup;
public class WorldspacePopupCanvas : MonoBehaviour
{
    public const float WORLDSPACE_ICON_SCALE_MULTIPLIER;
    [Header("References")]
    public RectTransform WorldspaceContainer;
    public RectTransform HudContainer;
    [Header("Prefabs")]
    public GameObject HudIconContainerPrefab;
    private List<WorldspacePopupUI> activeWorldspaceUIs;
    private List<RectTransform> activeHUDUIs;
    private List<WorldspacePopup> popupsWithUI;
    private void Update();
    private void LateUpdate();
    private bool ShouldCreateUI(WorldspacePopup popup);
    private WorldspacePopupUI CreateWorldspaceIcon(WorldspacePopup popup);
    private RectTransform CreateHUDIcon(WorldspacePopup popup);
    private void DestroyWorldspaceIcon(WorldspacePopup popup);
    private void DestroyHUDIcon(WorldspacePopup popup);
}