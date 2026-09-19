using System;
using System.Collections.Generic;
using ScheduleOne.AvatarFramework;
using ScheduleOne.Clothing;
using ScheduleOne.Core.Avatar;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI.Items;
using UnityEngine;
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
    [SerializeField]
    private Player _player;
    [SerializeField]
    private Transform Container;
    [SerializeField]
    private ScheduleOne.AvatarFramework.Avatar Avatar;
    [SerializeField]
    private Transform AvatarContainer;
    private float targetRotation;
    public bool IsOpen { get; private set; }

    protected override void Awake();
    public void SetOpen(bool open);
    private void Update();
    private void SetNakedAppearance(NakedAppearance appearance);
    private void SetOutfit(List<SerializedAvatarObject> outfit);
    private void ApplyMeshSettings();
}