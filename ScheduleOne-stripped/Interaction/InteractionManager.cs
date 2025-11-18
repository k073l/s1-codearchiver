using System;
using System.Collections.Generic;
using ScheduleOne.DevUtilities;
using ScheduleOne.Dragging;
using ScheduleOne.EntityFramework;
using ScheduleOne.PlayerScripts;
using ScheduleOne.PlayerTasks;
using ScheduleOne.UI;
using ScheduleOne.UI.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace ScheduleOne.Interaction;
public class InteractionManager : Singleton<InteractionManager>
{
    public const float RayRadius;
    public const float MaxInteractionRange;
    [SerializeField]
    protected LayerMask interaction_SearchMask;
    [SerializeField]
    protected float rightClickRange;
    public EInteractionSearchType interactionSearchType;
    public bool DEBUG;
    [Header("Settings")]
    public InputActionReference InteractInput;
    [Header("Visuals Settings")]
    public Color messageColor_Default;
    public Color iconColor_Default;
    public Color iconColor_Default_Key;
    public Color messageColor_Invalid;
    public Color iconColor_Invalid;
    public Sprite icon_Key;
    public Sprite icon_LeftMouse;
    public Sprite icon_Cross;
    public static float interactCooldown;
    private float timeSinceLastInteractStart;
    private BuildableItem itemBeingDestroyed;
    private float destroyTime;
    private static float timeToDestroy;
    public LayerMask Interaction_SearchMask => interaction_SearchMask;
    public bool CanDestroy { get; set; } = true;
    public InteractableObject HoveredInteractableObject { get; protected set; }
    public InteractableObject HoveredValidInteractableObject { get; protected set; }
    public InteractableObject InteractedObject { get; protected set; }
    public string InteractKeyStr { get; protected set; } = string.Empty;

    protected override void Start();
    protected override void OnDestroy();
    private void LoadInteractKey();
    protected virtual void Update();
    protected virtual void LateUpdate();
    protected virtual void CheckHover();
    public bool IsAnythingBlockingInteraction();
    protected virtual void CheckInteraction();
    protected virtual void CheckRightClick();
    protected virtual BuildableItem GetHoveredBuildableItem();
    public void SetCanDestroy(bool canDestroy);
}