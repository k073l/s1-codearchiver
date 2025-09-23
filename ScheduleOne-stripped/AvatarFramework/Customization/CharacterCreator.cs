using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FishNet;
using ScheduleOne.Clothing;
using ScheduleOne.DevUtilities;
using ScheduleOne.GameTime;
using ScheduleOne.Networking;
using ScheduleOne.PlayerScripts;
using ScheduleOne.UI;
using ScheduleOne.UI.CharacterCreator;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.AvatarFramework.Customization;
public class CharacterCreator : Singleton<CharacterCreator>
{
    public enum ECategory
    {
        Body,
        Hair,
        Face,
        Eyes,
        Eyebrows,
        Clothing,
        Accessories
    }

    public List<BaseCharacterCreatorField> Fields;
    [Header("References")]
    public Transform Container;
    public Transform CameraPosition;
    public Transform RigContainer;
    public Avatar Rig;
    public Canvas Canvas;
    public Animation CanvasAnimation;
    [Header("Settings")]
    public bool DemoCreator;
    public BasicAvatarSettings DefaultSettings;
    public List<BasicAvatarSettings> Presets;
    public UnityEvent<BasicAvatarSettings> onComplete;
    public UnityEvent<BasicAvatarSettings, List<ClothingInstance>> onCompleteWithClothing;
    private Dictionary<string, ClothingDefinition> lastSelectedClothingDefinitions;
    private float rigTargetY;
    public bool IsOpen { get; protected set; }
    public BasicAvatarSettings ActiveSettings { get; protected set; }

    protected override void Awake();
    protected override void Start();
    private void Update();
    public void Open(BasicAvatarSettings initialSettings, bool showUI = true);
    public void ShowUI();
    public void Close();
    public void DisableStuff();
    public void Done();
    public void SliderChanged(float newVal);
    public T SetValue<T>(string fieldName, T value, ClothingDefinition definition);
    public void SelectPreset(string presetName);
    public void RefreshCategory(ECategory category);
}