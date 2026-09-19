using System;
using System.Collections.Generic;
using System.Linq;
using ScheduleOne.AvatarFramework;
using ScheduleOne.Core.Avatar;
using ScheduleOne.Core.Avatar.Properties;
using UnityEngine;

namespace ScheduleOne.Avatar;
public class AvatarAppearance : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private ScheduleOne.AvatarFramework.Avatar _avatar;
    [SerializeField]
    private AttachmentAnchorProviderComponent _attachmentAnchorProvider;
    [SerializeField]
    private SkinnedMeshRenderer[] _bodyMeshes;
    [SerializeField]
    private SkinnedMeshRenderer _faceMesh;
    [SerializeField]
    private EyeController _eyeController;
    [SerializeField]
    private EyebrowController _eyebrowController;
    [SerializeField]
    private Transform _avatarObjectsContainer;
    private NakedAppearance _appliedNakedAppearance;
    private List<AvatarObject> _appliedObjects;
    private List<AvatarObject> _nakedObjects;
    private List<AvatarObject> _wornObjects;
    private Color _appliedSkinColor;
    private Color _appliedEmissionColor;
    private float _appliedWeight;
    private float _appliedGender;
    public EGender Gender { get; }
    public ESkinTone PrimarySkinTone { get; }
    public NakedAppearance AppliedNakedAppearance => _appliedNakedAppearance;

    public event Action<NakedAppearance> OnNakedAppearanceChanged;
    public event Action<List<SerializedAvatarObject>> OnOutfitChanged;
    private void Awake();
    public void ApplyNakedAppearance(NakedAppearance nakedAppearance);
    public void ClearNakedAppearance();
    public void ApplyOutfit(Outfit outfit);
    public void ApplyOutfit(List<SerializedAvatarObject> wornObjects);
    public void RemoveOutfit();
    public bool IsAvatarObjectApplied(string objectId);
    public void SetSkinColor(Color color);
    public void SetSkinEmission(Color color);
    public void SetWeight(float weight);
    public void SetGender(float gender);
    public void SetHairVisible(bool visible);
    public void SetHairColor(Color color);
    public void SetHairColorToDefault();
    public void SetEyeShadowVisible(bool visible);
    public void SetWetness(float wetness);
    private void ApplyNakedAppearanceExcludingAvatarObjects(NakedAppearance nakedAppearance, bool notify = true);
    private void ApplyHairColor(Color color);
    private void ClearNakedAppearance(bool notify);
    private void RemoveAllWornObjects(bool notify);
    private void OnFaceChanged(FaceAvatarObject newFace);
    private void SetFace(SerializedAvatarObject newFace);
    private AvatarObject ApplyNakedObject(SerializedAvatarObject obj, bool repaintLayers = true);
    private AvatarObject ApplyWornObject(SerializedAvatarObject obj, bool repaintLayers = true);
    private AvatarObject ApplyAvatarObject(SerializedAvatarObject obj, bool repaintLayers = true);
    private void RemoveNakedObject(AvatarObject objectReference, bool repaintLayers = true);
    private void RemoveWornObject(AvatarObject objectReference, bool repaintLayers = true);
    private void RemoveAvatarObject(AvatarObject objectReference, bool repaintLayers = true);
    private void SetSkinColorInternal(Color color);
    private void SetSkinEmissionInternal(Color color);
    private void ApplyWeight(float weight);
    private void ApplyGender(float gender);
    private void RecalculateFootShrink();
    private void RepaintLayers();
    private void RepaintLayers(ScheduleOne.Core.Avatar.AvatarLayer.EType type);
    private void RefreshHairBlocked();
}