using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using UnityEngine;
using UnityEngine.UI;

namespace ScheduleOne.UI;
public class CharacterInterface : MonoBehaviour
{
    public ClothingSlotUI[] ClothingSlots;
    public RectTransform Container;
    public Slider RotationSlider;
    public MonoState State;
    private Dictionary<ClothingSlotUI, Transform> SlotAlignmentPoints;
    public bool IsOpen { get; private set; }

    private void Awake();
    private void Start();
    private void LateUpdate();
    public void Open();
    public void Close();
    public void SetIsActiveGameplayScreen(bool isActive);
}