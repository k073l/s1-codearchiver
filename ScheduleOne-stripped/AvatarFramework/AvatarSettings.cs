using System;
using System.Collections.Generic;
using System.Reflection;
using FishNet.Serializing.Helping;
using UnityEngine;

namespace ScheduleOne.AvatarFramework;
[Serializable]
[CreateAssetMenu(fileName = "Avatar Settings", menuName = "ScriptableObjects/Avatar Settings", order = 1)]
public class AvatarSettings : ScriptableObject
{
    [Serializable]
    public struct LayerSetting
    {
        public string layerPath;
        public Color layerTint;
    }

    [Serializable]
    public class AccessorySetting
    {
        public string path;
        public Color color;
    }

    public Color SkinColor;
    public float Height;
    public float Gender;
    public float Weight;
    public string HairPath;
    public Color HairColor;
    public float EyebrowScale;
    public float EyebrowThickness;
    public float EyebrowRestingHeight;
    public float EyebrowRestingAngle;
    public Color LeftEyeLidColor;
    public Color RightEyeLidColor;
    public Eye.EyeLidConfiguration LeftEyeRestingState;
    public Eye.EyeLidConfiguration RightEyeRestingState;
    public string EyeballMaterialIdentifier;
    public Color EyeBallTint;
    public float PupilDilation;
    public List<LayerSetting> FaceLayerSettings;
    public List<LayerSetting> BodyLayerSettings;
    public List<AccessorySetting> AccessorySettings;
    [CodegenExclude]
    public bool UseCombinedLayer;
    [CodegenExclude]
    public AvatarLayer CombinedLayer;
    [CodegenExclude]
    public Texture2D ImpostorTexture;
    public float UpperEyelidRestingPosition => LeftEyeRestingState.topLidOpen;
    public float LowerEyelidRestingPosition => LeftEyeRestingState.bottomLidOpen;
    public string FaceLayer1Path { get; }
    public Color FaceLayer1Color { get; }
    public string FaceLayer2Path { get; }
    public Color FaceLayer2Color { get; }
    public string FaceLayer3Path { get; }
    public Color FaceLayer3Color { get; }
    public string FaceLayer4Path { get; }
    public Color FaceLayer4Color { get; }
    public string FaceLayer5Path { get; }
    public Color FaceLayer5Color { get; }
    public string FaceLayer6Path { get; }
    public Color FaceLayer6Color { get; }
    public string BodyLayer1Path { get; }
    public Color BodyLayer1Color { get; }
    public string BodyLayer2Path { get; }
    public Color BodyLayer2Color { get; }
    public string BodyLayer3Path { get; }
    public Color BodyLayer3Color { get; }
    public string BodyLayer4Path { get; }
    public Color BodyLayer4Color { get; }
    public string BodyLayer5Path { get; }
    public Color BodyLayer5Color { get; }
    public string BodyLayer6Path { get; }
    public Color BodyLayer6Color { get; }
    public string Accessory1Path { get; }
    public Color Accessory1Color { get; }
    public string Accessory2Path { get; }
    public Color Accessory2Color { get; }
    public string Accessory3Path { get; }
    public Color Accessory3Color { get; }
    public string Accessory4Path { get; }
    public Color Accessory4Color { get; }
    public string Accessory5Path { get; }
    public Color Accessory5Color { get; }
    public string Accessory6Path { get; }
    public Color Accessory6Color { get; }
    public string Accessory7Path { get; }
    public Color Accessory7Color { get; }
    public string Accessory8Path { get; }
    public Color Accessory8Color { get; }
    public string Accessory9Path { get; }
    public Color Accessory9Color { get; }

    public object this[string propertyName]
    {
        get
        {
            FieldInfo field = ((object)this).GetType().GetField(propertyName);
            PropertyInfo property = ((object)this).GetType().GetProperty(propertyName);
            if (field != null)
            {
                return field.GetValue(this);
            }

            if (property != null)
            {
                return property.GetValue(this, null);
            }

            return null;
        }
    }

    public virtual string GetJson(bool prettyPrint = true);
}