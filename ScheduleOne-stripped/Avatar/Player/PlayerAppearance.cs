using System;
using System.Collections.Generic;
using ScheduleOne.Avatar.Tools;
using ScheduleOne.Core.Avatar;
using UnityEngine;

namespace ScheduleOne.Avatar.Player;
[Serializable]
public class PlayerAppearance
{
    private const float MaleGenderScalarValue;
    private const float FemaleGenderScalarValue;
    private const float EyeShadeAlpha;
    private const string MaleUnderwearId;
    private const string FemaleUnderwearId;
    private const string NipplesId;
    private const string EyeShadeId;
    public EGender Gender;
    public float Weight;
    public Color SkinColor;
    public string HairStyleId;
    public Color HairColor;
    public string FaceId;
    public string FacialHairId;
    public string FacialDetailId;
    public float FacialDetailIntensity;
    public Color EyeballColor;
    public float PupilDilation;
    public float UpperEyelidPosition;
    public float LowerEyelidPosition;
    public float EyebrowScale;
    public float EyebrowThickness;
    public float EyebrowHeight;
    public float EyebrowAngle;
    public SerializedAvatarObject[] AdditionalAvatarObjects;
    public PlayerAppearance();
    public PlayerAppearance Clone();
    public string ToJson();
    public NakedAppearance GenerateNakedAppearance();
    public bool IsValid();
    public bool HasAvatarObject(string id);
    public void AddAvatarObject(SerializedAvatarObject obj);
    public void RemoveAvatarObject(string id);
}