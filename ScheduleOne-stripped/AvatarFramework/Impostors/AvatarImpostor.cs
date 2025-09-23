using ScheduleOne.DevUtilities;
using ScheduleOne.PlayerScripts;
using UnityEngine;

namespace ScheduleOne.AvatarFramework.Impostors;
public class AvatarImpostor : MonoBehaviour
{
    public MeshRenderer meshRenderer;
    public Transform AnchorBone;
    private Transform cachedCamera;
    private Vector3 anchorBoneOffset;
    public bool HasTexture { get; private set; }
    private Transform Camera { get; }

    private void Awake();
    public void SetAvatarSettings(AvatarSettings settings);
    private void LateUpdate();
    private void Realign();
    public void EnableImpostor();
    public void DisableImpostor();
}