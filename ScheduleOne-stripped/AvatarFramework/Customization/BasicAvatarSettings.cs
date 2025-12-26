using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace ScheduleOne.AvatarFramework.Customization;
[Serializable]
[CreateAssetMenu(fileName = "BasicAvatarSettings", menuName = "ScriptableObjects/BasicAvatarSettings", order = 1)]
public class BasicAvatarSettings : ScriptableObject
{
    public const float GenderScaleMultiplier;
    public const string MaleUnderwearPath;
    public const string FemaleUnderwearPath;
    public int Gender;
    public float Weight;
    public Color SkinColor;
    public string HairStyle;
    public Color HairColor;
    public string Mouth;
    public string FacialHair;
    public string FacialDetails;
    public float FacialDetailsIntensity;
    public Color EyeballColor;
    public float UpperEyeLidRestingPosition;
    public float LowerEyeLidRestingPosition;
    public float PupilDilation;
    public float EyebrowScale;
    public float EyebrowThickness;
    public float EyebrowRestingHeight;
    public float EyebrowRestingAngle;
    public string Top;
    public Color TopColor;
    public string Bottom;
    public Color BottomColor;
    public string Shoes;
    public Color ShoesColor;
    public string Headwear;
    public Color HeadwearColor;
    public string Eyewear;
    public Color EyewearColor;
    public List<string> Tattoos;
    public T SetValue<T>(string fieldName, T value);
    public T GetValue<T>(string fieldName);
    public AvatarSettings GetAvatarSettings();
    public virtual string GetJson(bool prettyPrint = true);
}