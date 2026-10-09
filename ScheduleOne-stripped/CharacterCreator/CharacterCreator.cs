using System;
using System.Collections;
using System.Collections.Generic;
using ScheduleOne.Avatar.Player;
using ScheduleOne.AvatarFramework;
using ScheduleOne.Clothing;
using ScheduleOne.Core;
using ScheduleOne.Core.Avatar;
using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using ScheduleOne.State;
using UnityEngine;

namespace ScheduleOne.CharacterCreator;
public class CharacterCreator : Singleton<CharacterCreator>
{
    private const float DelayBeforeDisablingContainerOnClose;
    [Header("Starting/Default Values")]
    [SerializeField]
    private PlayerAppearanceObject _startingAppearance;
    [SerializeField]
    private ClothingDefinition _startingTop;
    [SerializeField]
    private EClothingColor _startingTopColor;
    [SerializeField]
    private ClothingDefinition _startingBottom;
    [SerializeField]
    private EClothingColor _startingBottomColor;
    [SerializeField]
    private ClothingDefinition _startingShoes;
    [SerializeField]
    private EClothingColor _startingShoesColor;
    [Header("References")]
    [SerializeField]
    private Transform _container;
    [SerializeField]
    private Transform _cameraPosition;
    [SerializeField]
    private Transform _avatarContainer;
    [SerializeField]
    private ScheduleOne.AvatarFramework.Avatar _avatar;
    [SerializeField]
    private MonoState _state;
    private CharacterCreatorState _currentState;
    private float _rigTargetY;
    public bool IsOpen { get; protected set; }

    public event Action<CharacterCreatorState> OnOpen;
    public event Action OnClose;
    public event Action<CharacterCreatorState> OnComplete;
    protected override void Awake();
    private void Update();
    [Button]
    public void Open();
    public void Done();
    private void Close();
    public void SetAvatarRotation(float rotation);
    public void SetGender(EGender _gender);
    public void SetWeight(float weight);
    public void SetSkinColor(Color color);
    public void SetHair(HairAvatarObject hair);
    public void SetHairColor(Color color);
    public void SetFace(FaceAvatarObject face);
    public void SetFacialHair(AvatarObject facialHair);
    public void SetFacialDetail(AvatarObject facialDetail);
    public void SetFacialDetailIntensity(float intensity);
    public void SetEyeballColor(Color color);
    public void SetPupilDilation(float dilation);
    public void SetUpperEyelidRestingPosition(float position);
    public void SetLowerEyelidRestingPosition(float position);
    public void SetEyebrowScale(float scale);
    public void SetEyebrowThickness(float thickness);
    public void SetEyebrowHeight(float height);
    public void SetEyebrowAngle(float angle);
    public void SetTopClothing(ClothingDefinition topClothing);
    public void SetTopClothingColor(EClothingColor color);
    public void SetBottomClothing(ClothingDefinition bottomClothing);
    public void SetBottomClothingColor(EClothingColor color);
    public void SetShoes(ClothingDefinition shoes);
    public void SetShoesColor(EClothingColor color);
    private void ApplyNakedAppearance();
    private void ApplyClothing();
}