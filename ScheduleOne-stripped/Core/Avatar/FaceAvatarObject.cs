using UnityEngine;

namespace ScheduleOne.Core.Avatar;
public class FaceAvatarObject : AvatarObject
{
    public Texture2D FaceTexture => base.Layers[0].GetTextureToApply();
}