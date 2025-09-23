using System;
using ScheduleOne.AvatarFramework;
using ScheduleOne.Clothing;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI.Items;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

namespace ScheduleOne.UI;
public class CharacterDisplay : Singleton<CharacterDisplay>
{
    [Serializable]
    public class SlotAlignmentPoint
    {
        public EClothingSlot SlotType;
        public Transform Point;
    }

    public SlotAlignmentPoint[] AlignmentPoints;
    [Header("References")]
    public Transform Container;
    public Avatar ParentAvatar;
    public Avatar Avatar;
    public Transform AvatarContainer;
    private float targetRotation;
    public bool IsOpen { get; private set; }

    protected override void Awake();
    public void SetOpen(bool open);
    private void Update();
    public void SetAppearance(AvatarSettings settings);
}