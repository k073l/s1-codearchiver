using UnityEngine;

namespace ScheduleOne.AvatarFramework.Impostors;
public class AvatarImpostor : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public bool HasTexture { get; private set; }

    public void SetAvatarSettings(AvatarSettings settings);
    public void EnableImpostor();
    public void DisableImpostor();
    public void SetRotation(float rotation);
}